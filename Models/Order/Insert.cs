using ExtensivSharp.Models.Generic;

namespace ExtensivSharp.Models.Order
{
#pragma warning disable CS8618
    public class Insert
    {
        public Identifier PackageInsertIdentifier { get; set; }
        public float Quantity { get; set; }
        public float InsertedQuantity { get; set; }
        public string Barcode { get; set; }
    }
}
