﻿using Newtonsoft.Json;

namespace ExtensivSharp.Models.Order
{
#pragma warning disable CS8618
    public class FulfillInvInfo
    {
        [JsonProperty("fulfillInvShippingAndHandling")]
        public decimal FulfillInvShippingAndHandling { get; set; }

        [JsonProperty("fulfillInvTax")]
        public decimal FulfillInvTax { get; set; }

        [JsonProperty("fulfillInvDiscountCode")]
        public string FulfillInvDiscountCode { get; set; }

        [JsonProperty("fulfillInvDiscountAmount")]
        public decimal FulfillInvDiscountAmount { get; set; }

        [JsonProperty("fulfillInvGiftMessage")]
        public string FulfillInvGiftMessage { get; set; }
    }
}
