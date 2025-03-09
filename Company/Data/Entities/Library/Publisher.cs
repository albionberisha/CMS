using System.ComponentModel.DataAnnotations;

namespace CompanyAndLibrary.Data.Entities.Company.Library
{
    public class Publisher
    {
        [Key]
        public string PubName { get; set; }
        public string PubCity { get; set; }

        // Relationships
        public ICollection<Book> Books { get; set; }
    }

}
