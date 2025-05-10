using LeaveManagementSystem.Domain;
using LeaveManagementSystem.UseCases.Contracts.Interfaces.LeaveTypeInterfaces;
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

		public LeaveTypesController(IViewLeaveTypesUseCase viewLeaveTypesUseCase, IViewLeaveTypeDetailsUseCase viewLeaveTypeDetailsUseCase,
			IAddLeaveTypeUseCase addLeaveTypeUseCase, IEditLeaveTypeUseCase editLeaveTypeUseCase,
			IDeleteLeaveTypeUseCase deleteLeaveTypeUseCase,
			IIsLeaveTypeExistUseCase isLeaveTypeExistUseCase)
		{
			this.viewLeaveTypesUseCase = viewLeaveTypesUseCase;
			this.viewLeaveTypeDetailsUseCase = viewLeaveTypeDetailsUseCase;
			this.addLeaveTypeUseCase = addLeaveTypeUseCase;
			this.editLeaveTypeUseCase = editLeaveTypeUseCase;
			this.deleteLeaveTypeUseCase = deleteLeaveTypeUseCase;
			this.isLeaveTypeExistUseCase = isLeaveTypeExistUseCase;
		}

		// GET: LeaveTypes
		public async Task<IActionResult> Index()
		{
			return View(await viewLeaveTypesUseCase.ExecuteAsync());
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

			return View(leaveType);
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
		public async Task<IActionResult> Create([Bind("Id,Name,NumberOfDays")] LeaveType leaveType)
		{
			if (ModelState.IsValid)
			{
				await addLeaveTypeUseCase.Execute(leaveType);
				return RedirectToAction(nameof(Index));
			}
			return View(leaveType);
		}

		// GET: LeaveTypes/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			// we stopped here
			if (id == null)
			{
				return NotFound();
			}

			var leaveType = await viewLeaveTypeDetailsUseCase.ExecuteAsync(id.Value);
			if (leaveType == null)
			{
				return NotFound();
			}
			return View(leaveType);
		}

		// POST: LeaveTypes/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("Id,Name,NumberOfDays")] LeaveType leaveType)
		{
			if (id != leaveType.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					await editLeaveTypeUseCase.ExecuteAsync(id, leaveType);
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!await LeaveTypeExists(leaveType.Id))
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
			return View(leaveType);
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

			return View(leaveType);
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
