using System.ComponentModel.DataAnnotations;

namespace CompanyAndLibrary.Data.Entities.Company.Library
{
    public class Copy
    {
        public string Isbn { get; set; }  // FK to Book
        [Key]
        public string CopyNr { get; set; }
        public string Shelf { get; set; }
        public string Position { get; set; }

        // Navigation properties
        public Book Book { get; set; }

        public ICollection<Borrow> Borrows { get; set; }
    }

}
