using Newtonsoft.Json;

namespace ExtensivSharp.Models.Customers
{
    public class EmbeddedCustomers
    {
        [JsonProperty("http://api.3plCentral.com/rels/customers/customer")]
        public List<Customer>? Customers { get; set; }
    }
}
