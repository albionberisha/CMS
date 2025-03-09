using System.ComponentModel.DataAnnotations;

namespace CompanyAndLibrary.Data.Entities.Company
{
    public class DepartmentLocation
    {
        [Key]
        public int Id { get; set; }

        public int DepartmentId { get; set; }
        
        public Department Department { get; set; }

        public string Location { get; set; }
    }

}
