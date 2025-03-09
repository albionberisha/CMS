using System.ComponentModel.DataAnnotations;

namespace Company.Data.Entities
{
    public class Project
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        // One-to-Many: A project is controlled by one department
        public int DepartmentId { get; set; }
        
        public Department Department { get; set; }

        // Many-to-Many: A project can have multiple employees working on it
        public ICollection<EmployeeProject> EmployeeProjects { get; set; }
    }


}
