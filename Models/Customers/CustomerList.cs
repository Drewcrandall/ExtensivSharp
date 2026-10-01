using Newtonsoft.Json;

namespace ExtensivSharp.Models.Customers
{
    public class CustomerList
    {
        [JsonProperty("totalResults")]
        public int TotalResults { get; set; }

        [JsonProperty("_embedded")]
        public EmbeddedCustomers? Embedded { get; set; }
    }
}
