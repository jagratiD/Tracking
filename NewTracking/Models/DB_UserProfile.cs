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
    
    public partial class DB_UserProfile
    {
        public DB_UserProfile()
        {
            this.webpages_UsersInRoles = new HashSet<webpages_UsersInRoles>();
        }
    
        public int UserId { get; set; }
        public string UserName { get; set; }
        public Nullable<System.DateTime> CreatedAtUtc { get; set; }
        public Nullable<System.DateTime> UpdatedATUtc { get; set; }
        public string ConfirmationToken { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<System.DateTime> LastPasswordFailureDate { get; set; }
        public Nullable<int> PasswordFailuresSinceLastSuccess { get; set; }
        public string Password { get; set; }
        public Nullable<System.DateTime> PasswordChangedDate { get; set; }
        public string PasswordSalt { get; set; }
        public string PasswordVerificationToken { get; set; }
        public Nullable<System.DateTime> PasswordVerificationTokenExpirationDate { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<int> UnitID { get; set; }
    
        public virtual ICollection<webpages_UsersInRoles> webpages_UsersInRoles { get; set; }
    }
}
