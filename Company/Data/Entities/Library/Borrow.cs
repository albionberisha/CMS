namespace CompanyAndLibrary.Data.Entities.Company.Library
{
    public class Borrow
    {
        public int ReaderNr { get; set; }  // FK to Reader
        public string CopyNr { get; set; }  // FK to Copy
        public DateTime ReturnDate { get; set; }

        // Navigation properties
        public Reader Reader { get; set; }
        public Copy Copy { get; set; }
    }

}
