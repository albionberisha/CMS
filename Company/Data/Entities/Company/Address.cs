using System.ComponentModel.DataAnnotations;

namespace CompanyAndLibrary.Data.Entities.Company
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int StreetNumber { get; set; }
        public int ApartmentNumber { get; set; }
        public int Floor { get; set; }
        public string PostalCode { get; set; }

        // Foreign Key to Employee
        public int EmployeeId { get; set; }

        
        public Employee Employee { get; set; }
    }
}
