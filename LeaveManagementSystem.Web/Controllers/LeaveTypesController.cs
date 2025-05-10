using AutoMapper;
using LeaveManagementSystem.Domain;
using LeaveManagementSystem.UseCases.Contracts.Interfaces.LeaveTypeInterfaces;
using LeaveManagementSystem.Web.Models.LeaveTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Web.Controllers
{
	public class LeaveTypesController : Controller
	{
		private readonly IViewLeaveTypesUseCase viewLeaveTypesUseCase;
		private readonly IViewLeaveTypeDetailsUseCase viewLeaveTypeDetailsUseCase;
		private readonly IAddLeaveTypeUseCase addLeaveTypeUseCase;
		private readonly IEditLeaveTypeUseCase editLeaveTypeUseCase;
		private readonly IDeleteLeaveTypeUseCase deleteLeaveTypeUseCase;
		private readonly IIsLeaveTypeExistUseCase isLeaveTypeExistUseCase;
		private readonly IIsLeaveTypeNameExistsUseCase isLeaveTypeNameExistsUseCase;
		private readonly IMapper _mapper;

		private static string _currentVacationName;
		private const string _leaveTypeExistErrorMessage = "Leave Type with this name already exists.";

		public LeaveTypesController(IViewLeaveTypesUseCase viewLeaveTypesUseCase, IViewLeaveTypeDetailsUseCase viewLeaveTypeDetailsUseCase,
			IAddLeaveTypeUseCase addLeaveTypeUseCase, IEditLeaveTypeUseCase editLeaveTypeUseCase,
			IDeleteLeaveTypeUseCase deleteLeaveTypeUseCase,
			IIsLeaveTypeExistUseCase isLeaveTypeExistUseCase,
			IIsLeaveTypeNameExistsUseCase isLeaveTypeNameExistsUseCase,
			IMapper mapper)
		{
			this.viewLeaveTypesUseCase = viewLeaveTypesUseCase;
			this.viewLeaveTypeDetailsUseCase = viewLeaveTypeDetailsUseCase;
			this.addLeaveTypeUseCase = addLeaveTypeUseCase;
			this.editLeaveTypeUseCase = editLeaveTypeUseCase;
			this.deleteLeaveTypeUseCase = deleteLeaveTypeUseCase;
			this.isLeaveTypeExistUseCase = isLeaveTypeExistUseCase;
			this.isLeaveTypeNameExistsUseCase = isLeaveTypeNameExistsUseCase;
			this._mapper = mapper;
		}

		// GET: LeaveTypes
		public async Task<IActionResult> Index()
		{
			var data = await viewLeaveTypesUseCase.ExecuteAsync();

			var viewData = _mapper.Map<IReadOnlyList<LeaveTypeReadOnlyVM>>(data);

			return View(viewData);
		}

		// GET: LeaveTypes/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var leaveType = await viewLeaveTypeDetailsUseCase.ExecuteAsync(id.Value);
			if (leaveType == null)
			{
				return NotFound();
			}

			var leaveTypeView = _mapper.Map<LeaveTypeReadOnlyVM>(leaveType);

			return View(leaveTypeView);
		}

		// GET: LeaveTypes/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: LeaveTypes/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(LeaveTypeCreateVM leaveTypeCreate)
		{

			if (await isLeaveTypeNameExistsUseCase.ExecuteAsync(leaveTypeCreate.Name))
			{
				ModelState.AddModelError(nameof(leaveTypeCreate.Name), _leaveTypeExistErrorMessage);
			}

			if (ModelState.IsValid)
			{
				leaveTypeCreate.Name = leaveTypeCreate.Name.Trim();

				var leaveType = _mapper.Map<LeaveType>(leaveTypeCreate);

				await addLeaveTypeUseCase.Execute(leaveType);
				return RedirectToAction(nameof(Index));
			}

			return View(leaveTypeCreate);
		}

		// GET: LeaveTypes/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{

			if (id == null)
			{
				return NotFound();
			}

			var leaveType = await viewLeaveTypeDetailsUseCase.ExecuteAsync(id.Value);
			if (leaveType == null)
			{
				return NotFound();
			}

			leaveType.Name = leaveType.Name.Trim();
			var viewData = _mapper.Map<LeaveTypeEditVM>(leaveType);

			_currentVacationName = viewData.Name;
			return View(viewData);
		}

		// POST: LeaveTypes/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, LeaveTypeEditVM leaveTypeEdit)
		{
			if (id != leaveTypeEdit.Id)
			{
				return NotFound();
			}

			if (_currentVacationName != leaveTypeEdit.Name && await isLeaveTypeNameExistsUseCase.ExecuteAsync(leaveTypeEdit.Name))
			{
				ModelState.AddModelError(nameof(leaveTypeEdit.Name), _leaveTypeExistErrorMessage);
			}

			if (ModelState.IsValid)
			{
				try
				{
					var leaveType = _mapper.Map<LeaveType>(leaveTypeEdit);
					await editLeaveTypeUseCase.ExecuteAsync(id, leaveType);
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!await LeaveTypeExists(leaveTypeEdit.Id))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
				return RedirectToAction(nameof(Index));
			}

			return View(leaveTypeEdit);
		}

		// GET: LeaveTypes/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var leaveType = await viewLeaveTypeDetailsUseCase.ExecuteAsync(id.Value);
			if (leaveType == null)
			{
				return NotFound();
			}
			var viewData = _mapper.Map<LeaveTypeReadOnlyVM>(leaveType);
			return View(viewData);
		}

		// POST: LeaveTypes/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var leaveType = await viewLeaveTypeDetailsUseCase.ExecuteAsync(id);
			if (leaveType != null)
			{
				await deleteLeaveTypeUseCase.ExecuteAsync(id);
			}

			return RedirectToAction(nameof(Index));
		}

		private async Task<bool> LeaveTypeExists(int id)
		{
			return await isLeaveTypeExistUseCase.ExecuteAsync(id);
		}

	}
}
