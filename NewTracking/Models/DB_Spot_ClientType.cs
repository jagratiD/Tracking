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
    
    public partial class DB_Spot_ClientType
    {
        public DB_Spot_ClientType()
        {
            this.DB_Spot_CustomerProfile = new HashSet<DB_Spot_CustomerProfile>();
            this.DB_Spot_Orders = new HashSet<DB_Spot_Orders>();
        }
    
        public int ClientTypeId { get; set; }
        public string ClientType { get; set; }
        public string Description { get; set; }
        public Nullable<int> Priority { get; set; }
    
        public virtual ICollection<DB_Spot_CustomerProfile> DB_Spot_CustomerProfile { get; set; }
        public virtual ICollection<DB_Spot_Orders> DB_Spot_Orders { get; set; }
    }
}
