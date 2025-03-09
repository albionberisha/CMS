using System.ComponentModel.DataAnnotations;

namespace CompanyAndLibrary.Data.Entities.Company.Library
{
    public class Reader
    {
        [Key]
        public int ReaderNr { get; set; }
        public string City { get; set; }
        public DateTime Birthdate { get; set; }

        // Composite Attribute: Name
        public string FirstName { get; set; }
        public string FamilyName { get; set; }

        // Multi-valued Attribute: PhoneNumbers
        public ICollection<ReaderPhoneNumber> PhoneNumbers { get; set; }

        // Relationships
        public ICollection<Borrow> Borrows { get; set; }
    }

}
