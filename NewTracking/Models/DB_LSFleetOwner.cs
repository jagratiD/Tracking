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
    
    public partial class DB_LSFleetOwner
    {
        public DB_LSFleetOwner()
        {
            this.DB_LSVehicle = new HashSet<DB_LSVehicle>();
        }
    
        public int FleetOwnerId { get; set; }
        public string Name { get; set; }
        public Nullable<int> UDANFleetOwnerId { get; set; }
        public string PaymentMode { get; set; }
        public string BankName { get; set; }
        public string BankAccountNo { get; set; }
        public string BankBranchName { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> Status { get; set; }
        public string IFSC_CODE { get; set; }
    
        public virtual ICollection<DB_LSVehicle> DB_LSVehicle { get; set; }
    }
}
