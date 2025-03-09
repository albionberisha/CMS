using System.ComponentModel.DataAnnotations;

namespace CompanyAndLibrary.Data.Entities.Company
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string Gender { get; set; }

        // Foreign Key for Department
        public int? DepartmentId { get; set; }
        
        public Department Department { get; set; }

        public Manager Manager { get; set; }

        // Many-to-Many: Employee works on multiple projects
        public ICollection<EmployeeProject> EmployeeProjects { get; set; }
    }
}
