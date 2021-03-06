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
    
    public partial class DB_City
    {
        public DB_City()
        {
            this.DB_Address = new HashSet<DB_Address>();
            this.DB_LSVehicle = new HashSet<DB_LSVehicle>();
            this.DB_Driver = new HashSet<DB_Driver>();
            this.DB_GPS = new HashSet<DB_GPS>();
            this.DB_PhoneInfo = new HashSet<DB_PhoneInfo>();
            this.DB_Spot_FareFactors = new HashSet<DB_Spot_FareFactors>();
            this.DB_Spot_Orders = new HashSet<DB_Spot_Orders>();
        }
    
        public short CityId { get; set; }
        public string Name { get; set; }
        public string CityCode { get; set; }
        public Nullable<short> StateId { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDisabled { get; set; }
        public string EcomCityCode { get; set; }
    
        public virtual ICollection<DB_Address> DB_Address { get; set; }
        public virtual ICollection<DB_LSVehicle> DB_LSVehicle { get; set; }
        public virtual DB_States DB_States { get; set; }
        public virtual ICollection<DB_Driver> DB_Driver { get; set; }
        public virtual ICollection<DB_GPS> DB_GPS { get; set; }
        public virtual ICollection<DB_PhoneInfo> DB_PhoneInfo { get; set; }
        public virtual ICollection<DB_Spot_FareFactors> DB_Spot_FareFactors { get; set; }
        public virtual ICollection<DB_Spot_Orders> DB_Spot_Orders { get; set; }
    }
}
