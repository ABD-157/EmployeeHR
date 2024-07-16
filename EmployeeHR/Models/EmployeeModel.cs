using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeHR.Models
{
    public class EmployeeModel
    {
        [key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Required]
        [Display(Name = "First Name")]
        [Column(TypeName="NVARCHAR(50)")]
        [StringLength(50)]
        public string FirstName { get; set; }
     
        [Required]
        
        [Display(Name = "Last Name")]
        [Column(TypeName = "NVARCHAR(50)")]
        [StringLength(50)]
        public string LastName { get; set; }  
        [Required]
        [Display(Name = "Hiring Date")]
        [DisplayFormat(DataFormatString ="{0:MM.dd.yyyy}")]
        [Column(TypeName = "datetime")]
		[DataType(DataType.Date)]
		public DateTime HiringDate { get; set; }
        [Required]
        [Display(Name = "DOB")]
        [DisplayFormat(DataFormatString = "{0:MM.dd.yyyy}")]
        [Column(TypeName = "datetime")]
		[DataType(DataType.Date)]
		public DateTime DOB { get; set; }
        [Required]
        [Display(Name = "Salary")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,3)")]
        public decimal Salary { get; set; }
        
        [Display(Name = "IsActive")]
        [Column(TypeName = "bit")]

        public bool IsActive { get; set; }
		[Required]
		[Display(Name = "DepartmentId")]
		[Column(TypeName = "int")]
		public int DepartmentId { get; set; }

		[Display(Name = "Email")]
        [Column(TypeName = "NVARCHAR(100)")]
        [DataType(DataType.EmailAddress)]
        [StringLength(100)]
        public string? Email { get; set; }
     
        [Display(Name = "Department")]
        public virtual DepartmentModel Department { get; set; }

    }
}
