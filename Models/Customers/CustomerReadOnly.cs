using Newtonsoft.Json;

namespace ExtensivSharp.Models.Customers
{
    /// <summary>Customer fields that are not updatable by the API client.</summary>
    public class CustomerReadOnly
    {
        [JsonProperty("customerId")]
        public int CustomerId { get; set; }

        [JsonProperty("deactivated")]
        public bool Deactivated { get; set; }
    }
}
