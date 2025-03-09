using System.ComponentModel.DataAnnotations;

namespace CompanyAndLibrary.Data.Entities.Company.Library
{
    public class Category
    {
        [Key]
        public string CatName { get; set; }

        // Relationships
        public ICollection<Book> Books { get; set; }
    }

}
