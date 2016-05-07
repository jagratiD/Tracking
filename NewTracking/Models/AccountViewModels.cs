using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.UI.WebControls;
using NewTracking.Models;
using System.Linq;
using System;
using PagedList;

namespace NewTracking.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string Action { get; set; }
        public string ReturnUrl { get; set; }
    }

    public class ManageUserViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
    public class CommonFunctions
    {
        public static List<ListItem> GetPageSize()
        {
            List<ListItem> items = new List<ListItem>
                     {
                         new ListItem{ Text="10", Value = "10" },
                         new ListItem{ Text="20", Value = "20" },
                        new ListItem{ Text="25", Value = "25" },
                        new ListItem{ Text="30", Value = "30" },
                        new ListItem{ Text="50", Value = "50" },
                         new ListItem{ Text="100", Value = "100" }

                     };
            return items;

        }

        public static List<ListItem> GetSortingBy()
        {
            List<ListItem> items = new List<ListItem>
                     {
                         new ListItem{ Text="OrderId", Value = "OrderId" },
                         new ListItem{ Text="DeliveryTime", Value = "DeliveryTime" }
                     };
            return items;

        }


        public static List<ListItem> GetOrderStatus()
        {
            List<ListItem> items = new List<ListItem>
                     {
                         new ListItem{ Value="All", Text = "All" },
                          new ListItem{ Value="NA", Text = "Not Assigned" },
                           new ListItem{ Value="A", Text = "Assigned" },
                             new ListItem{ Value="P", Text = "Pickup" },
                              new ListItem{ Value="C", Text = "Completed" },
                             new ListItem{ Value="CAN", Text = "Cancelled" },                           
                             new ListItem{ Value="CBA", Text = "Can Not Be Assigned" }  ,
                             new ListItem{ Value="DC", Text = "Declined" } ,
                              new ListItem{ Value="PDC", Text = "Declined At Pickup Time" },
                               new ListItem{ Value="DDC", Text = "Declined At Delivery Time" }

                     };

            return items;
        }
    }


    public class OrderPage
    {
        public DateTime OrderDate { get; set; }
        public DateTime OrderEDate { get; set; }
        public string OrderStatus { get; set; }
        public int PageSize { get; set; }
        public IPagedList<OrderDetailModel> list { get; set; }
    }



    public class OrderDetailModel
    {

        public Nullable<System.DateTime> CreatedOn { get; set; }
        public long OrderId { get; set; }
        public string CRNNo { get; set; }
        public string ClientName { get; set; }
        public DateTime? VehicleAssignTime { get; set; }
        public DateTime? ConsignorArrivalTime { get; set; }
        public DB_OrderDetails PickUpTime { get; set; }

        public List<string> Waypoints { get; set; }
        public string ReverseKey { get; set; }

        public string Consignor { get; set; }
        public string Consignee
        {
            get
            {
                if (Waypoints.Count() > 1)
                {
                    var consignees = string.Join(" , ", Waypoints.ToArray());
                    if (consignees.Length > 200)
                    {
                        consignees = consignees.Substring(0, 200) + " ...";
                    }
                    return consignees;
                }
                else
                {
                    return Waypoints.FirstOrDefault();
                }
            }
        }
        public DateTime? EstimatedPickupTime { get; set; }
        // public DateTime? CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string Route { get; set; }

        public string CreatedOnstring
        {
            get
            {
                if (CreatedOn == null)
                    return "NA";
                else
                    return Convert.ToString(CreatedOn);
            }
        }
        public string Status { get; set; }
        public string Vehicle { get; set; }
        public List<DB_OrderDetails> oddetails { get; set; }
        public List<string> CDN
        {
            get
            {
                var liststrng = oddetails.Select(x => x.CDNnumber).ToList();
                return liststrng;
            }
        }
        public Nullable<int> TotalPickupPoints
        {
            get
            {
                var count = oddetails.Where(c => c.PickOrDelivery == "PICKUP").Count();
                return count;
            }
        }
        public Nullable<int> TotalDropPoints
        {
            get
            {
                var count = oddetails.Where(c => c.PickOrDelivery == "DELIVERY").Count();
                return count;
            }

        }
        public Nullable<int> TotalPickupCompleted
        {
            get
            {
                var count = oddetails.Where(c => c.PickOrDelivery == "PICKUP" && c.PickDelStatus == "C").Count();
                return count;
            }
        }
        public Nullable<int> TotalDropCompleted
        {
            get
            {
                var count = oddetails.Where(c => c.PickOrDelivery == "DELIVERY" && c.PickDelStatus == "C").Count();
                return count;
            }
        }
        public Nullable<int> QuantityPickup
        {
            get
            {
                var count = oddetails.Where(c => c.PickOrDelivery == "PICKUP").Sum(x => x.EnteredQty == null ? 0 : x.EnteredQty);
                return count;

            }
        }
        public Nullable<int> QuantityDeliver
        {
            get
            {
                var count = oddetails.Where(c => c.PickOrDelivery == "DELIVERY").Sum(x => x.EnteredQty == null ? 0 : x.EnteredQty);
                return count;
            }
        }
        public Nullable<int> QuantityReturned
        {
            get
            {
                var count = oddetails.Where(c => c.PickOrDelivery == "R-DDC").Sum(x => x.EnteredQty == null ? 0 : x.EnteredQty);
                return count;
            }
        }
        public Nullable<int> TotalReturnPoints
        {
            get
            {
                var count = oddetails.Where(c => c.PickOrDelivery == "R-DDC").Count();
                return count;

            }
        }
        public Nullable<int> TotalReturnCompleted
        {
            get
            {
                var count = oddetails.Where(c => c.PickOrDelivery == "R-DDC" && c.PickDelStatus == "C").Count();
                return count;
            }
        }
    }

}
