using Microsoft.AspNetCore.Mvc;
using EmployeeHR.Data;
using Microsoft.EntityFrameworkCore;
using EmployeeHR.Models;
namespace EmployeeHR.Controllers
{
    public class DepartmentController : Controller
    {
     private  readonly HRDbcontext _dbcontext;
        public DepartmentController(HRDbcontext hRDbcontext)
        {
            this._dbcontext = hRDbcontext;

        }

        public IActionResult Index()
        {
            var DepartmentToList= _dbcontext.Departments.ToList();
            return View(DepartmentToList);

        }

		public IActionResult Create()
		{

			return View();

		}
        [HttpPost]  
        public IActionResult Create(DepartmentModel departmentModel)
        {
            if (departmentModel != null)
            {
                _dbcontext.Departments.Add(departmentModel);
                _dbcontext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();

        }
        public IActionResult Edit(int id)
        {


            return View();

        }
    }
}
