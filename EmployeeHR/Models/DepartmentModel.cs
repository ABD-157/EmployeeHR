using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EmployeeHR.Models
{
    [Table("Departments",Schema ="dbo")]
    public class DepartmentModel
    {
        [key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Name")]
        [Column(TypeName = "NVARCHAR(50)")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Abbreviation")]
        [Column(TypeName = "CHAR(3)")]
        [StringLength(3)]
        public string Abbreviation { get; set; }
    }
}
