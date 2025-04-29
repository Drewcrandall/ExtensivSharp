using Newtonsoft.Json;

namespace ExtensivSharp.Models.Order
{
#pragma warning disable CS8618
    public class ParcelOption
    {
        [JsonProperty("orderId")]
        public int OrderId { get; set; }

        [JsonProperty("deliveryConfirmationType")]
        public string DeliveryConfirmationType { get; set; }

        [JsonProperty("deliveredDutyPaid")]
        public int DeliveredDutyPaid { get; set; }

        [JsonProperty("dryIceWeight")]
        public double DryIceWeight { get; set; }

        [JsonProperty("insuranceAmount")]
        public double InsuranceAmount { get; set; }

        [JsonProperty("insuranceType")]
        public int InsuranceType { get; set; }

        [JsonProperty("internationalContentsType")]
        public string InternationalContentsType { get; set; }

        [JsonProperty("internationalNonDelivery")]
        public string InternationalNonDelivery { get; set; }

        [JsonProperty("residentialFlag")]
        public bool ResidentialFlag { get; set; }

        [JsonProperty("saturdayDeliveryFlag")]
        public bool SaturdayDeliveryFlag { get; set; }

        [JsonProperty("taxIdentifiers")]
        public string TaxIdentifiers { get; set; }

        [JsonProperty("carrierAccountNumber")]
        public string CarrierAccountNumber { get; set; }

        [JsonProperty("carrierSelectionV2")]
        public bool CarrierSelectionV2 { get; set; }

        [JsonProperty("shipDate")]
        public string ShipDate { get; set; }

        [JsonProperty("chosenRate")]
        public string ChosenRate { get; set; }
    }

}
