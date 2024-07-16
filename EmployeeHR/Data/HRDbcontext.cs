using EmployeeHR.Models;
using Microsoft.EntityFrameworkCore;
namespace EmployeeHR.Data
{
	public class HRDbcontext : DbContext
	{
		public HRDbcontext(DbContextOptions<HRDbcontext>options):base(options) 
		{
		
		}
		public DbSet<EmployeeModel> Employees {  get; set; }
		public DbSet<DepartmentModel> Departments { get; set; }

	}

	
}
