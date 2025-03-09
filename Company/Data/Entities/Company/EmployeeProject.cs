using System.ComponentModel.DataAnnotations;

namespace CompanyAndLibrary.Data.Entities.Company
{
    public class EmployeeProject
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        [Required]
        public int ProjectId { get; set; }
        public Project Project { get; set; }

        [Required]
        public DateTime StartTime { get; set; } // Changed to DateTime

        [Required]
        public DateTime EndTime { get; set; } // Changed to DateTime
    }



}
