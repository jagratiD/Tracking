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
    
    public partial class DB_Orders
    {
        public DB_Orders()
        {
            this.DB_Order_Details = new HashSet<DB_Order_Details>();
            this.DB_OrderItems = new HashSet<DB_OrderItems>();
            this.DB_OrderLog = new HashSet<DB_OrderLog>();
        }
    
        public int OrderId { get; set; }
        public string Remarks { get; set; }
        public Nullable<System.DateTime> Created { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<bool> IsCompleted { get; set; }
        public Nullable<long> ClientId { get; set; }
    
        public virtual ICollection<DB_Order_Details> DB_Order_Details { get; set; }
        public virtual ICollection<DB_OrderItems> DB_OrderItems { get; set; }
        public virtual ICollection<DB_OrderLog> DB_OrderLog { get; set; }
    }
}
