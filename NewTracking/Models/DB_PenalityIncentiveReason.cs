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
    
    public partial class DB_PenalityIncentiveReason
    {
        public DB_PenalityIncentiveReason()
        {
            this.DB_VehiclePenalty = new HashSet<DB_VehiclePenalty>();
            this.DB_ExtraCharge = new HashSet<DB_ExtraCharge>();
            this.DB_Deduction = new HashSet<DB_Deduction>();
        }
    
        public int ReasonId { get; set; }
        public string Type { get; set; }
        public string Reason { get; set; }
    
        public virtual ICollection<DB_VehiclePenalty> DB_VehiclePenalty { get; set; }
        public virtual ICollection<DB_ExtraCharge> DB_ExtraCharge { get; set; }
        public virtual ICollection<DB_Deduction> DB_Deduction { get; set; }
    }
}
