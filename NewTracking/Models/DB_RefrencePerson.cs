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
    
    public partial class DB_RefrencePerson
    {
        public int Id { get; set; }
        public string RefrencialName { get; set; }
        public string EmailId { get; set; }
        public Nullable<int> PersonTypeId { get; set; }
        public Nullable<int> AddressId { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public string IPAddress { get; set; }
        public string MACAddress { get; set; }
        public string ReferenceCode { get; set; }
    }
}
