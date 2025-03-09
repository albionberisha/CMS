namespace CompanyAndLibrary.Data.Entities.Company.Library
{
    public class Publishes
    {
        public string Isbn { get; set; }  // FK to Book
        public string PubName { get; set; }  // FK to Publisher

        // Navigation properties
        public Book Book { get; set; }
        public Publisher Publisher { get; set; }
    }

}
