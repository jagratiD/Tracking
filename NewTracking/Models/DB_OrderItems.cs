//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NewTracking.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DB_OrderItems
    {
        public int OrderItemId { get; set; }
        public Nullable<int> OrderId { get; set; }
        public Nullable<int> ItemId { get; set; }
        public Nullable<int> DepotId { get; set; }
        public Nullable<short> Quantity { get; set; }
        public string ChargingBasis { get; set; }
        public Nullable<decimal> CostChargingBasis { get; set; }
        public Nullable<decimal> TotalCost { get; set; }
        public string Tag { get; set; }
    
        public virtual DB_Depot DB_Depot { get; set; }
        public virtual DB_ItemRegistration DB_ItemRegistration { get; set; }
        public virtual DB_Orders DB_Orders { get; set; }
    }
}
