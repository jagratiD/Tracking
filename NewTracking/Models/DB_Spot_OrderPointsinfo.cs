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
    
    public partial class DB_Spot_OrderPointsinfo
    {
        public long OPointInfoId { get; set; }
        public long SpotOrderId { get; set; }
        public string PickOrDelivery { get; set; }
        public string DepotStationName { get; set; }
        public string ApproxAddress { get; set; }
        public Nullable<double> ApproxLatitude { get; set; }
        public Nullable<double> ApproxLongitude { get; set; }
        public string ContactNumber { get; set; }
        public Nullable<double> COPD { get; set; }
        public Nullable<int> SequenceNo { get; set; }
        public Nullable<System.DateTime> ExpectedTimeOfArrival { get; set; }
        public Nullable<System.DateTime> ReachedAt { get; set; }
        public Nullable<double> ActualLoadingUnLoadingTime { get; set; }
        public Nullable<System.DateTime> ActualCompletedAt { get; set; }
        public Nullable<double> ActualMLatitude { get; set; }
        public Nullable<double> ActualMLongitude { get; set; }
        public string ActualMAddress { get; set; }
        public string RecordClosedBy { get; set; }
        public string ContactedPersonRelation { get; set; }
        public string PersonContacted { get; set; }
        public Nullable<int> EnteredQty { get; set; }
        public string BiltyNumber { get; set; }
        public string PhotoGoods { get; set; }
        public string PhotoBilty { get; set; }
        public string Signature { get; set; }
        public Nullable<double> GPSLatitude { get; set; }
        public Nullable<double> GPSLongitude { get; set; }
        public Nullable<System.DateTime> GPSDateTime { get; set; }
        public string PickDelStatus { get; set; }
        public Nullable<bool> IsLiftAvailalbe { get; set; }
        public Nullable<int> FloorNumber { get; set; }
        public string PaymentBy { get; set; }
        public string ReturnReason { get; set; }
        public string CRNnumber { get; set; }
    
        public virtual DB_Spot_Orders DB_Spot_Orders { get; set; }
    }
}
