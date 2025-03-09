namespace CompanyAndLibrary.Data.Entities.Company.Library
{
    public class ReaderPhoneNumber
    {
        public int ReaderNr { get; set; }
        public string PhoneNumber { get; set; }

        // Navigation property
        public Reader Reader { get; set; }
    }

}
