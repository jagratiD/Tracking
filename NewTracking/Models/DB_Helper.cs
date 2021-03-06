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
    
    public partial class DB_Helper
    {
        public DB_Helper()
        {
            this.DB_Vehicle_Tracking = new HashSet<DB_Vehicle_Tracking>();
            this.DB_VehicleAssetMappingLog = new HashSet<DB_VehicleAssetMappingLog>();
        }
    
        public int HelperId { get; set; }
        public string HelperCode { get; set; }
        public string Name { get; set; }
        public string FatherName { get; set; }
        public Nullable<System.DateTime> DateOfJoining { get; set; }
        public Nullable<System.DateTime> DateOfLeaving { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public Nullable<bool> IsDOBBaseDocument { get; set; }
        public Nullable<long> AddressId { get; set; }
        public Nullable<long> PermanentAddressId { get; set; }
        public Nullable<int> RefPersonId { get; set; }
        public string BankName { get; set; }
        public string BankAccountNo { get; set; }
        public string BankBranchName { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string Status { get; set; }
        public Nullable<System.DateTime> Created { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> Modified { get; set; }
        public string ModifiedBy { get; set; }
        public string IPAddress { get; set; }
        public Nullable<bool> IsPoliceVerificationDone { get; set; }
        public Nullable<bool> IsAadharSubmitted { get; set; }
        public string AadharCardNumber { get; set; }
        public Nullable<bool> IsVoterIdSubmitted { get; set; }
        public string VoterIdNumber { get; set; }
        public Nullable<bool> IsPanCardSubmitted { get; set; }
        public string PanNumber { get; set; }
        public Nullable<bool> IsRashanCardSubmitted { get; set; }
        public string RashanCardNumber { get; set; }
        public Nullable<bool> IsPhotoSubmitted { get; set; }
        public string WorkHistoryRemark { get; set; }
        public string FamilyReferenceRemark { get; set; }
        public string LogisureReferenceRemark { get; set; }
        public string DocsIncompleteRemark { get; set; }
        public Nullable<int> LoadView { get; set; }
        public string PoliceVerificationRemark { get; set; }
        public string ReferencePersonType { get; set; }
    
        public virtual DB_Address DB_Address { get; set; }
        public virtual DB_Address DB_Address1 { get; set; }
        public virtual ICollection<DB_Vehicle_Tracking> DB_Vehicle_Tracking { get; set; }
        public virtual ICollection<DB_VehicleAssetMappingLog> DB_VehicleAssetMappingLog { get; set; }
    }
}
