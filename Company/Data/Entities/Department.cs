using System.ComponentModel.DataAnnotations;

namespace Company.Data.Entities
{
    public class Department
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        // One-to-Many: A department has multiple employees
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();

        // Foreign Key for Manager
        public int? ManagerId { get; set; }

        // One-to-One: A department has one manager
        public Manager Manager { get; set; }

        // One-to-Many: A department controls multiple projects
        public ICollection<Project> Projects { get; set; } = new List<Project>();

        // One-to-Many: A department has multiple locations
        public ICollection<DepartmentLocation> Locations { get; set; } = new List<DepartmentLocation>();
    }



}
