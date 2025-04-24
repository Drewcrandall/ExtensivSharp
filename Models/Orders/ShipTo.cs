using Newtonsoft.Json;

namespace ExtensivSharp.Models.Orders
{
    public class ShipTo
    {
        [JsonProperty("retailerInfo")]
        public RetailerInfo RetailerInfo { get; set; } // Assuming RetailerInfo is defined elsewhere

        [JsonProperty("sameAs")]
        public int SameAs { get; set; }

        [JsonProperty("retailerId")]
        public int RetailerId { get; set; }

        [JsonProperty("isQuickLookup")]
        public bool IsQuickLookup { get; set; }

        [JsonProperty("contactId")]
        public int ContactId { get; set; }

        [JsonProperty("companyName")]
        public string CompanyName { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("address1")]
        public string Address1 { get; set; }

        [JsonProperty("address2")]
        public string Address2 { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("zip")]
        public string Zip { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonProperty("fax")]
        public string Fax { get; set; }

        [JsonProperty("emailAddress")]
        public string EmailAddress { get; set; }

        [JsonProperty("dept")]
        public string Dept { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("addressStatus")]
        public int AddressStatus { get; set; }
    }
}
