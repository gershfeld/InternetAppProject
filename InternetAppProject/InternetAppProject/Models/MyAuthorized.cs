using secondHandPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace secondHandPro.Models
{
    public class MyAuthorized : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            secondHandProContext db = new secondHandProContext();
            var authorized = base.AuthorizeCore(httpContext);
            if (httpContext.Session["name"] == null)
                return false;
            var username = httpContext.Session["name"].ToString();
            if (username == null)
                return false;
            var user = db.Users.Where(x => x.Username == username).FirstOrDefault();
            return user.isAdmin;    
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new  ViewResult  { ViewName = "UnAothurized" };
            //base.HandleUnauthorizedRequest(filterContext);
            
        }
    }
}
