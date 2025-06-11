namespace ExtensivSharp.Models.Webhooks
{
#pragma warning disable CS8618
    public class Resource
    {
        public string Rel { get; set; }
        public string Href { get; set; }
        public Order.Order Body { get; set; }
    }
}
