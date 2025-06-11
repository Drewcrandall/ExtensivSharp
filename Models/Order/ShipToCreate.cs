namespace ExtensivSharp.Models.Order
{
    public class ShipToCreate
    {
        public ShipToCreate()
        {
            CompanyName = string.Empty;
            Name = string.Empty;
            Address1 = string.Empty;
            City = string.Empty;
            State = string.Empty;
            Zip = string.Empty;
            Country = string.Empty;
            PhoneNumber = string.Empty;
            EmailAddress = string.Empty;
        }

        public string CompanyName { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string? Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
    }
}
