using Newtonsoft.Json;

namespace ExtensivSharp.Models.Customers
{
    /// <summary>The customer's company contact (customer.contact1). Only the name is modeled here.</summary>
    public class CustomerCompanyInfo
    {
        [JsonProperty("companyName")]
        public string? CompanyName { get; set; }
    }
}
