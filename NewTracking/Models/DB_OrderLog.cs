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
    
    public partial class DB_OrderLog
    {
        public long OrderIdLog { get; set; }
        public Nullable<int> OrderId { get; set; }
        public Nullable<long> UId { get; set; }
        public string DeviceId { get; set; }
        public string Vehicle { get; set; }
        public Nullable<System.DateTime> ReachTime { get; set; }
        public Nullable<System.DateTime> CompletedDateTime { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public string FullAddress { get; set; }
        public Nullable<double> Latitude { get; set; }
        public Nullable<double> Longitude { get; set; }
        public Nullable<double> Accuracy { get; set; }
        public string Status { get; set; }
        public Nullable<long> PhotoGoods { get; set; }
        public Nullable<long> PhotoBilty { get; set; }
        public Nullable<long> Signature { get; set; }
        public string IPAddress { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<double> GpsLatitude { get; set; }
        public Nullable<double> GpsLongitude { get; set; }
        public Nullable<System.DateTime> GpsDateTime { get; set; }
        public string BiltyNumber { get; set; }
        public string PlaceName { get; set; }
        public Nullable<long> RatOrderlogID { get; set; }
    
        public virtual DB_Order_Details DB_Order_Details { get; set; }
        public virtual DB_Orders DB_Orders { get; set; }
        public virtual DB_PhotoUpload DB_PhotoUpload { get; set; }
        public virtual DB_PhotoUpload DB_PhotoUpload1 { get; set; }
        public virtual DB_PhotoUpload DB_PhotoUpload2 { get; set; }
    }
}
