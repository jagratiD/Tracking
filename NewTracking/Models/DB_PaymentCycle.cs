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
    
    public partial class DB_PaymentCycle
    {
        public DB_PaymentCycle()
        {
            this.DB_FareStructure = new HashSet<DB_FareStructure>();
            this.DB_Client = new HashSet<DB_Client>();
        }
    
        public short PaymentCycleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<short> Days { get; set; }
    
        public virtual ICollection<DB_FareStructure> DB_FareStructure { get; set; }
        public virtual ICollection<DB_Client> DB_Client { get; set; }
    }
}
