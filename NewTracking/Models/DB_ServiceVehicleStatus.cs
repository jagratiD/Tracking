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
    
    public partial class DB_ServiceVehicleStatus
    {
        public int Id { get; set; }
        public string ServiceName { get; set; }
        public string Vehicle { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}
