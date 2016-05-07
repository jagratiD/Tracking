using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewTracking.Models
{
    public class PermissionFilter : AuthorizeAttribute
    {

        public LogisureEntities1 db = new LogisureEntities1();
        public string Permission;
        private bool FailedpermAuth = false;
        private bool Inavlid = false;
        DateTime indianStd = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, "India Standard Time");
        //[CustomPermissionFilter(Permission = "CLOSE ORDER MANUALLY PERMISSION")]



        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            FailedpermAuth = false;
            Inavlid = false;

            if (httpContext == null)
                throw new ArgumentNullException("httpContext");

            //string[] users = Users.Split(',');

            int userid;
            string a = httpContext.Request.Cookies["UserName"].Value;

            userid = db.DB_CustomUserProfile.Where(x => x.UserName.ToLower() == a.ToLower()).Select(x => x.UserID).FirstOrDefault();

            if (userid != 0 && userid != null)
            {
                // string role = user.RoleName;
                int PermissionStatus = PermissionAuthenticate(Permission, userid, "");
                if (PermissionStatus == 0)
                {
                    FailedpermAuth = true;
                    return false;
                }
            }
            else
            {
                return false;
            }


            return true;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);

            if (FailedpermAuth)
                filterContext.Result = new ViewResult { ViewName = "NotAuth" };

        }

        public int PermissionAuthenticate(string Permission, int userid, string UseRole)
        {
            DateTime date = indianStd.Date;

            int permissionid = (from a in db.DB_CustomPermissions
                                where a.PermissionName.Contains(Permission)
                                select a.PermissionID).FirstOrDefault();

            string pid = permissionid.ToString();

            var Exist = (from a in db.DB_CustomUserProfile
                         where a.Permissions.Contains(pid) && a.UserID == userid
                         select a).FirstOrDefault();

            if (Exist != null)
            {
                FailedpermAuth = false;
                return 1;
            }
            else
            {
                FailedpermAuth = true;
                return 0;

            }

        }
    }
}