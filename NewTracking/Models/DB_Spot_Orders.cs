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
    
    public partial class DB_Spot_Orders
    {
        public DB_Spot_Orders()
        {
            this.DB_Spot_Invoice = new HashSet<DB_Spot_Invoice>();
            this.DB_Spot_OrderDetails = new HashSet<DB_Spot_OrderDetails>();
            this.DB_Spot_OrderDetails1 = new HashSet<DB_Spot_OrderDetails>();
            this.DB_Spot_OrderPointsinfo = new HashSet<DB_Spot_OrderPointsinfo>();
        }
    
        public long SpotId { get; set; }
        public string CRNNo { get; set; }
        public Nullable<long> CustomerId { get; set; }
        public Nullable<System.DateTime> OrderArrivalDatetime { get; set; }
        public string Vehicle { get; set; }
        public Nullable<double> OrderKmPD { get; set; }
        public Nullable<double> OrderKmAP { get; set; }
        public Nullable<System.DateTime> OrderAssignedDatetime { get; set; }
        public Nullable<short> CityId { get; set; }
        public Nullable<int> ClientTypeId { get; set; }
        public string FromPlace { get; set; }
        public Nullable<double> FromLat { get; set; }
        public Nullable<double> FromLng { get; set; }
        public string ToPlace { get; set; }
        public Nullable<double> ToLat { get; set; }
        public Nullable<double> ToLng { get; set; }
        public Nullable<bool> IsReturnTrip { get; set; }
        public Nullable<bool> IsChampRequired { get; set; }
        public Nullable<int> NoOfChamps { get; set; }
        public Nullable<int> ApproxLoadingUnloadingTime { get; set; }
        public string VanType { get; set; }
        public string DeviceType { get; set; }
        public string BrowserInfo { get; set; }
        public Nullable<double> TimeTookForOrderCompletion { get; set; }
        public Nullable<decimal> OrderAmount { get; set; }
        public Nullable<decimal> ConvenienceCharge { get; set; }
        public string RouteImage { get; set; }
        public Nullable<bool> IsConfirmed { get; set; }
        public Nullable<int> OTP { get; set; }
        public Nullable<System.DateTime> OTPCreated { get; set; }
        public Nullable<bool> IsCompleted { get; set; }
        public Nullable<decimal> ApproxWeight { get; set; }
        public Nullable<decimal> EstimatedKm { get; set; }
        public Nullable<decimal> EstimatedFare { get; set; }
        public Nullable<int> EstimatedTime { get; set; }
        public string FareFrom { get; set; }
        public string PickupInformation { get; set; }
        public Nullable<double> EnrouteExpenses { get; set; }
        public Nullable<double> CalculatedAmount { get; set; }
        public Nullable<double> ReceivedAmount { get; set; }
        public Nullable<System.DateTime> ExpectedPickUpTime { get; set; }
        public string DriverDetails { get; set; }
        public Nullable<double> TripKM { get; set; }
        public Nullable<double> TripTime { get; set; }
        public Nullable<double> LoadingTime { get; set; }
        public Nullable<double> UnloadingTime { get; set; }
        public string ServiceType { get; set; }
        public Nullable<short> PFloorNo { get; set; }
        public Nullable<short> DFloorNo { get; set; }
        public Nullable<bool> LiftAtPickup { get; set; }
        public Nullable<bool> LiftAtDelivery { get; set; }
        public Nullable<double> Discount { get; set; }
        public Nullable<bool> IsCanceledBy { get; set; }
        public string CancellationReason { get; set; }
    
        public virtual DB_City DB_City { get; set; }
        public virtual DB_Spot_ClientType DB_Spot_ClientType { get; set; }
        public virtual DB_Spot_CustomerProfile DB_Spot_CustomerProfile { get; set; }
        public virtual ICollection<DB_Spot_Invoice> DB_Spot_Invoice { get; set; }
        public virtual ICollection<DB_Spot_OrderDetails> DB_Spot_OrderDetails { get; set; }
        public virtual ICollection<DB_Spot_OrderDetails> DB_Spot_OrderDetails1 { get; set; }
        public virtual ICollection<DB_Spot_OrderPointsinfo> DB_Spot_OrderPointsinfo { get; set; }
    }
}
