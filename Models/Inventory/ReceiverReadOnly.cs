using ExtensivSharp.Models.Generic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensivSharp.Models.Inventory
{
    public class ReceiverReadOnly
    {
        [JsonProperty("receiverId")]
        public int ReceiverId { get; set; }

        [JsonProperty("receiverType")]
        public int ReceiverType { get; set; }

        [JsonProperty("deferNotification")]
        public bool DeferNotification { get; set; }

        [JsonProperty("receiptAdviceSendInfo")]
        public ReceiptAdviceSendInfo ReceiptAdviceSendInfo { get; set; }

        [JsonProperty("customerIdentifier")]
        public CustomerIdentifier CustomerIdentifier { get; set; }

        [JsonProperty("facilityIdentifier")]
        public Identifier FacilityIdentifier { get; set; }

        [JsonProperty("warehouseTransactionSourceType")]
        public int WarehouseTransactionSourceType { get; set; }

        [JsonProperty("transactionEntryType")]
        public int TransactionEntryType { get; set; }

        [JsonProperty("importChannelIdentifier")]
        public Identifier ImportChannelIdentifier { get; set; }

        [JsonProperty("creationDate")]
        public DateTime CreationDate { get; set; }

        [JsonProperty("createdByIdentifier")]
        public Identifier CreatedByIdentifier { get; set; }

        [JsonProperty("lastModifiedDate")]
        public DateTime LastModifiedDate { get; set; }

        [JsonProperty("lastModifiedByIdentifier")]
        public Identifier LastModifiedByIdentifier { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("chargesPending")]
        public bool ChargesPending { get; set; }
    }
}
