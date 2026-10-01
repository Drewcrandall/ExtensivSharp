using Newtonsoft.Json;

namespace ExtensivSharp.Models.Customers
{
    /// <summary>
    /// A 3PL customer as returned by GET /customers. Only the fields needed to map an Extensiv customer
    /// to our internal customer record are modeled; the full resource carries contacts, facilities, etc.
    /// </summary>
    public class Customer
    {
        [JsonProperty("readOnly")]
        public CustomerReadOnly? ReadOnly { get; set; }

        [JsonProperty("companyInfo")]
        public CustomerCompanyInfo? CompanyInfo { get; set; }

        [JsonProperty("externalId")]
        public string? ExternalId { get; set; }
    }
}
