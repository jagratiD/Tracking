using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Owin;
using NewTracking.Models;
using System.Net;
using System.Net.NetworkInformation;
using System.Configuration;
using Newtonsoft.Json.Linq;

namespace NewTracking.Controllers
{
    //[Authorize]
    public class AccountController : Controller
    {
        LogisureEntities1 db = new LogisureEntities1();

        [AllowAnonymous]
        public ActionResult Login(string returnurl)
        {
            ViewBag.ReturnUrl = returnurl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Login(UserProfile model, FormCollection collection, string returnurl)
        {
            if (!string.IsNullOrEmpty(model.UserName) && !string.IsNullOrEmpty(model.PassKey))
            {
                var z = ConfigurationManager.AppSettings["ModuleName"];
                string ipadd = GetIPAddress();
                string macid = GetMACAddress();
                ipadd = CommonFunction.EncodeToBase64(ipadd);
                macid = CommonFunction.EncodeToBase64(macid);

                string uri = "http://custommisc.logisureindia.com/userverify/verify?username=" + model.UserName + "&password="+model.PassKey+ "&modulename=" + z  + "&qid=" + ipadd + "&mid=" + macid;

                var client = new WebClient();
                string data = await client.DownloadStringTaskAsync(uri);
                 JObject jobj = JObject.Parse(data);
               bool stat = (bool)jobj.SelectToken("status");
               var msg = (string)jobj.SelectToken("msg");
          //     var stat = (string)jobj.SelectToken("jobj.status");
             
               
              //  string [] sortdata = data.ToArray();
                HttpCookie IsAuthenticatedCookie = new HttpCookie("IsAuthenticated");
                IsAuthenticatedCookie.Value = data;
                Response.Cookies.Add(IsAuthenticatedCookie);

                if (stat == true && msg == "Successfully Verified")
                {
             //   return Json(new { data = data, username = model.UserName, password = model.PassKey }, JsonRequestBehavior.AllowGet);

                //UserProfile user = db.UserProfiles.Where(x => x.UserName == model.UserName).FirstOrDefault();
                //    var Role = db.webpages_UsersInRoles.Where(x => x.UserId == user.UserId).FirstOrDefault();

                //    HttpCookie UserNameCookie = new HttpCookie("UserName");
                //    UserNameCookie.Value = model.UserName;
                //    Response.Cookies.Add(UserNameCookie);
                    DB_CustomUserProfile user = db.DB_CustomUserProfile.Where(x => x.UserName == model.UserName).FirstOrDefault();

                    HttpCookie UserNameCookie1 = new HttpCookie("UserName");
                    UserNameCookie1.Value = model.UserName;
                    Response.Cookies.Add(UserNameCookie1);
                    HttpCookie UserIdCookie1 = new HttpCookie("UserId");
                    UserIdCookie1.Value = user.UserID.ToString();
                    Session["UserId"] = user.UserID;
                    Response.Cookies.Add(UserIdCookie1);
                    HttpCookie ClientIdCookie = new HttpCookie("ClientId");


                   if(model.UserName.ToLower().Contains("logisure"))
                   {
                       ClientIdCookie.Value = null;
                       Response.Cookies.Add(ClientIdCookie);
                   }
                   else
                   {
                       DB_UserToUnitMapping UserToUnit = db.DB_UserToUnitMapping.Where(x => x.UserId == user.UserID).FirstOrDefault();
                       ClientIdCookie.Value = UserToUnit.UnitId.ToString();
                       Response.Cookies.Add(ClientIdCookie);

                   }

                   
                    //if (UserToUnit != null)
                    //{
                    //ClientIdCookie.Value = UserToUnit.UnitId.ToString();
                    //Response.Cookies.Add(ClientIdCookie);

                    //var x = CommonFunction.EncodeToBase64(UserToUnit.UnitId.ToString());
                    //return Redirect("/Home/BookOrder?Cid=" + x);

                    //}
                    //else
                    //{                        
                    //    ClientIdCookie.Value = "0";
                    //    Response.Cookies.Add(ClientIdCookie);
                    if (string.IsNullOrEmpty(returnurl))
                    {
                        return Redirect("/TrackOrders/Index");
                    }
                    else
                    {
                        return Redirect(returnurl);
                    }
                    //}

                }
                else
                {
                    return View("Login");
                }
            }
            else
            {
                return View("Login");
            }
        }

        public ActionResult LogOff()
        {
            if (Request.Cookies["UserName"] != null)
            {
                HttpCookie UserCookie = new HttpCookie("UserName");
                HttpCookie ClientCookie = new HttpCookie("ClientId");
                HttpCookie RoleCookie = new HttpCookie("RoleName");

                UserCookie.Expires = ClientCookie.Expires = RoleCookie.Expires = DateTime.Now.AddDays(-1d);

                Response.Cookies.Add(UserCookie);
                Response.Cookies.Add(ClientCookie);
                Response.Cookies.Add(RoleCookie);

            }
            return RedirectToAction("Login", "Account");
        }

        protected string GetIPAddress()
        {
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (!string.IsNullOrEmpty(ipAddress))
            {
                string[] addresses = ipAddress.Split(',');
                if (addresses.Length != 0)
                {
                    return addresses[0];
                }
            }

            return context.Request.ServerVariables["REMOTE_ADDR"];
        }

        public string GetMACAddress()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            String sMacAddress = string.Empty;
            foreach (NetworkInterface adapter in nics)
            {
                if (sMacAddress == String.Empty)// only return MAC Address from first card  
                {
                    IPInterfaceProperties properties = adapter.GetIPProperties();
                    sMacAddress = adapter.GetPhysicalAddress().ToString();
                }
            } return sMacAddress;
        }

    }
}