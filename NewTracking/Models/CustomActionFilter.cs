using NewTracking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace NewTracking.Models
{
    public class CustomActionAttribute : AuthorizeAttribute
    {
        LogisureEntities1 dc = new LogisureEntities1();

        private bool FailedAuth = false;
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            HttpContext context = System.Web.HttpContext.Current;
     
            if (context.Request.Cookies["UserName"] != null)
            {
                FailedAuth = false;
                return true;
            }
            else
            {
                FailedAuth = true;                
                return false;
            }

        }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);

            if (FailedAuth)
            {
                string returnurl = HttpContext.Current.Request.RawUrl;
                RedirectToRouteResult(filterContext,
             new { controller = "Account", action = "Login",returnurl}
         );
                //filterContext.Result = new ViewResult { ViewName = "NotAuth" };
            }
        }

        private void RedirectToRouteResult(AuthorizationContext context, object routeValues)
        {
            var rc = new RequestContext(context.HttpContext, context.RouteData);
            string url = RouteTable.Routes.GetVirtualPath(rc,
                new RouteValueDictionary(routeValues)).VirtualPath;
            context.HttpContext.Response.Redirect(url, true);
        }
    }
}