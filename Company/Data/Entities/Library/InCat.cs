namespace CompanyAndLibrary.Data.Entities.Company.Library
{
    public class InCat
    {
        public string Isbn { get; set; }  // FK to Book
        public string CatName { get; set; }  // FK to Category

        // Navigation properties
        public Book Book { get; set; }
        public Category Category { get; set; }
    }

}
