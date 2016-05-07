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
    
    public partial class DB_States
    {
        public DB_States()
        {
            this.DB_Address = new HashSet<DB_Address>();
            this.DB_City = new HashSet<DB_City>();
            this.DB_Driver = new HashSet<DB_Driver>();
            this.DB_GPS = new HashSet<DB_GPS>();
            this.DB_LSVehicle = new HashSet<DB_LSVehicle>();
            this.DB_PhoneInfo = new HashSet<DB_PhoneInfo>();
        }
    
        public short StateId { get; set; }
        public string Name { get; set; }
        public string StateCode { get; set; }
    
        public virtual ICollection<DB_Address> DB_Address { get; set; }
        public virtual ICollection<DB_City> DB_City { get; set; }
        public virtual ICollection<DB_Driver> DB_Driver { get; set; }
        public virtual ICollection<DB_GPS> DB_GPS { get; set; }
        public virtual ICollection<DB_LSVehicle> DB_LSVehicle { get; set; }
        public virtual ICollection<DB_PhoneInfo> DB_PhoneInfo { get; set; }
    }
}