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
    
    public partial class DB_UserRoles
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public Nullable<System.DateTime> CreatedAtUtc { get; set; }
        public Nullable<System.DateTime> UpdatedATUtc { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
    }
}
