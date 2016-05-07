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
    
    public partial class DB_VehiclePenalty
    {
        public int Id { get; set; }
        public Nullable<long> VehicleId { get; set; }
        public Nullable<double> Amount { get; set; }
        public string Description { get; set; }
        public string Remark { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public string MacAddress { get; set; }
        public string IPAddress { get; set; }
        public Nullable<System.DateTime> PenaltyDate { get; set; }
        public string ChargableAt { get; set; }
        public Nullable<int> ReasonId { get; set; }
        public Nullable<bool> IsVerify { get; set; }
    
        public virtual DB_LSVehicle DB_LSVehicle { get; set; }
        public virtual DB_PenalityIncentiveReason DB_PenalityIncentiveReason { get; set; }
    }
}
