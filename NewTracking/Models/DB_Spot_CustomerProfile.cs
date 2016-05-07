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
    
    public partial class DB_Spot_CustomerProfile
    {
        public DB_Spot_CustomerProfile()
        {
            this.DB_Spot_Orders = new HashSet<DB_Spot_Orders>();
        }
    
        public long CustomerUId { get; set; }
        public string CustomerName { get; set; }
        public string EmailId { get; set; }
        public string Location { get; set; }
        public string Language { get; set; }
        public string InvideCode { get; set; }
        public string ProfilePicture { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public string IPAddress { get; set; }
        public string DeviceUsed { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<int> ClientType { get; set; }
        public string CustomerCode { get; set; }
        public string Number { get; set; }
        public string OTP { get; set; }
    
        public virtual DB_Spot_ClientType DB_Spot_ClientType { get; set; }
        public virtual DB_Spot_UserProfile DB_Spot_UserProfile { get; set; }
        public virtual ICollection<DB_Spot_Orders> DB_Spot_Orders { get; set; }
    }
}
