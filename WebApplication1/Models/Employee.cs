using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Employee
    {
         
        [Key]
        public int Id { get; set; }
        [Required] 
        public int IdNumber { get; set; }
        [Required]
        public int empyeeType { get; set; }

        [Required]
        public string? firstName { get; set; }
        [Required]
        public string? lastName { get; set; }
        [Required]
        public string? phoneNumber { get; set; }
        [Required]
        public string? emailAddress { get; set; }
        [Required]
        public string? mailingAddress { get; set; }
        [Required]
        public int baseSalary { get; set; }

    }
}
