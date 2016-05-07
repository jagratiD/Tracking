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
    
    public partial class DB_Spot_UserProfile
    {
        public DB_Spot_UserProfile()
        {
            this.DB_Spot_CustomerProfile = new HashSet<DB_Spot_CustomerProfile>();
        }
    
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Nullable<int> LoginCount { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public string IPAddress { get; set; }
        public string MACAddress { get; set; }
        public string GoogleId { get; set; }
        public string ProfilePicURL { get; set; }
        public string PhoneNo { get; set; }
        public string Screenname { get; set; }
        public string isVerified { get; set; }
    
        public virtual ICollection<DB_Spot_CustomerProfile> DB_Spot_CustomerProfile { get; set; }
    }
}
