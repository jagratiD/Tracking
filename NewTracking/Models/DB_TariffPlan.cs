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
    
    public partial class DB_TariffPlan
    {
        public int TariffId { get; set; }
        public string TariffPlan { get; set; }
        public string Description { get; set; }
        public Nullable<int> ClientId { get; set; }
        public string PublicName { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}