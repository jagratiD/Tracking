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
    
    public partial class DB_Spot_VehicleFareCharges
    {
        public int SpotVehicleFareChargesID { get; set; }
        public Nullable<double> ProposedPrice { get; set; }
        public Nullable<double> PricePerMinute { get; set; }
        public Nullable<double> PricePerKm { get; set; }
        public Nullable<double> CostPerMinute { get; set; }
        public Nullable<double> CostPerKM { get; set; }
        public Nullable<double> DieselChargesPerKM { get; set; }
        public Nullable<double> HireChargesCostPerMinute { get; set; }
        public Nullable<double> HireChargesCostPerDay { get; set; }
        public Nullable<double> CostPerDay { get; set; }
        public Nullable<double> CostPerMonth { get; set; }
        public Nullable<double> Mileage { get; set; }
        public string VehicleType { get; set; }
    }
}
