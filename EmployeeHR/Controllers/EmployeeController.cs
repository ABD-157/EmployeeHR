using EmployeeHR.Data;
using EmployeeHR.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EmployeeHR.Controllers
{
    public class EmployeeController : Controller
    {
		private readonly HRDbcontext _dbcontext;
	public EmployeeController(HRDbcontext dbContext)
		{ 
	this._dbcontext= dbContext;
		
		}
					
		public IActionResult Index()
		{
			//List<EmployeeModel> employeeslist = (from e in _dbcontext.Employees
			//									 join d in _dbcontext.Departments on e.DepartmentId equals d.Id
			//									 select new EmployeeModel
			//									 {
			//										 Id = e.Id,
			//										 FirstName = e.FirstName,
			//										 LastName = e.LastName,
			//										 HiringDate = e.HiringDate,
			//										 DOB = e.DOB,
			//										 Salary = e.Salary,
			//										 Email = e.Email,
			//										 IsActive = e.IsActive,
			//										 Department = d

			//									 }).ToList();

			var employeeslist = _dbcontext.Employees.Include("Department").ToList();
			return View(employeeslist);

        }
		public IActionResult Creat()
		{
			ViewBag.Departmentlist= _dbcontext.Departments;

			return View();	
		}
		[HttpPost]
        public IActionResult Creat(EmployeeModel employee)
        {
			
			if (employee != null)
			{
				_dbcontext.Employees.Add(employee);
			    
				return RedirectToAction(nameof(Index));
		  
			}
			return View();
           
        }

        [HttpGet]
		public IActionResult Edit(int id)
		{
			ViewBag.DepartmentList = _dbcontext.Departments;

			var emp = _dbcontext.Employees.Where(e => e.Id == id).FirstOrDefault();
			if (emp != null)
			{
              return View(emp);  
			}
			return RedirectToAction("Index");
			
		}
		[HttpPost]
		public IActionResult Edit(int id , EmployeeModel employee) {
			if (employee != null)
			{
				var emp = _dbcontext.Employees.Where(e => e.Id == id).FirstOrDefault();
				if (emp != null)
				{
					emp.Id = employee.Id;
					emp.FirstName = employee.FirstName;
					emp.LastName = employee.LastName;
					emp.Email = employee.Email;
					emp.IsActive = employee.IsActive;
					emp.Department = employee.Department;
					emp.Salary = employee.Salary;
					emp.DOB = employee.DOB;
				}
			}
			return RedirectToAction("Index");
			
		}
		[HttpGet]
		public IActionResult Delet(int id) 
		{

			var emp = _dbcontext.Employees.Where(e=>e.Id == id).FirstOrDefault();
			if (emp != null) 
			{
				return View(emp);
			}
			return View();


		}
		[HttpPost]
		public IActionResult Delet(int id,EmployeeModel employee)
		{

			var emp = _dbcontext.Employees.Where(e => e.Id == id).FirstOrDefault();
			if (emp != null)
			{
				_dbcontext.Employees.Remove(emp);
				return RedirectToAction(nameof(Index));
            }
		return View();


		}

	}
}
