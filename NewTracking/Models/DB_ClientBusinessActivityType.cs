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
    
    public partial class DB_ClientBusinessActivityType
    {
        public DB_ClientBusinessActivityType()
        {
            this.DB_Client = new HashSet<DB_Client>();
        }
    
        public int ClientBusinessActivityTypeId { get; set; }
        public string ClientBusinessActivityTypeName { get; set; }
        public string Description { get; set; }
    
        public virtual ICollection<DB_Client> DB_Client { get; set; }
    }
}