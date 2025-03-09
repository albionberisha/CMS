using Humanizer;
using System.ComponentModel.DataAnnotations;

namespace CompanyAndLibrary.Data.Entities.Company.Library
{
    public class Book
    {
        [Key]
        public string Isbn { get; set; }
        public int PubYear { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int NumPages { get; set; }

        // Relationships
        public string CatName { get; set; }  // FK to Category
        public Category Category { get; set; }

        public string PubName { get; set; }  // FK to Publisher
        public Publisher Publisher { get; set; }

        public ICollection<Borrow> Borrows { get; set; }
        public ICollection<InCat> InCats { get; set; }
        public ICollection<Publishes> Publishes { get; set; }
    }

}
