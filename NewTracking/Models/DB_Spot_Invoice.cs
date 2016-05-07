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
    
    public partial class DB_Spot_Invoice
    {
        public string InvoiceID { get; set; }
        public Nullable<decimal> Km { get; set; }
        public Nullable<decimal> Fare { get; set; }
        public Nullable<decimal> KmFare { get; set; }
        public Nullable<decimal> EnrouteExpensesFare { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<int> TravelTime { get; set; }
        public Nullable<decimal> ConvenienceCharges { get; set; }
        public string CRNNo { get; set; }
        public Nullable<long> SpotId { get; set; }
        public Nullable<decimal> BaseFare { get; set; }
        public Nullable<double> Discount { get; set; }
    
        public virtual DB_Spot_Orders DB_Spot_Orders { get; set; }
    }
}