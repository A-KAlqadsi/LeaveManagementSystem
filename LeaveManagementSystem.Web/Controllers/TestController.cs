using LeaveManagementSystem.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagementSystem.Web.Controllers
{
	public class TestController : Controller
	{
		public IActionResult Index()
		{
			TestViewModel testViewModel = new TestViewModel
			{
				Name = "Abdulkareem",
				Age = 20
			};

			return View(testViewModel);
		}
	}
}
