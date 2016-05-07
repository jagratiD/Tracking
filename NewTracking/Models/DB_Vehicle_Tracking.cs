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
    
    public partial class DB_Vehicle_Tracking
    {
        public int VehicleTrackingId { get; set; }
        public Nullable<long> VehicleId { get; set; }
        public Nullable<int> GPSId { get; set; }
        public Nullable<int> DriverId { get; set; }
        public Nullable<int> MobileId { get; set; }
        public Nullable<int> HelperId { get; set; }
        public Nullable<double> CurrentLatitude { get; set; }
        public Nullable<double> CurrentLongitude { get; set; }
        public Nullable<double> Speed { get; set; }
        public Nullable<System.DateTime> Datetime { get; set; }
        public string State { get; set; }
        public string hstate { get; set; }
        public string EventType { get; set; }
        public Nullable<System.DateTime> hstateDateTime { get; set; }
        public string All_data { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public string MACAddress { get; set; }
    
        public virtual DB_Driver DB_Driver { get; set; }
        public virtual DB_GPS DB_GPS { get; set; }
        public virtual DB_Helper DB_Helper { get; set; }
        public virtual DB_LSVehicle DB_LSVehicle { get; set; }
        public virtual DB_PhoneInfo DB_PhoneInfo { get; set; }
    }
}
