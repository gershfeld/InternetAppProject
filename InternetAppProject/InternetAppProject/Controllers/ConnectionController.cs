using secondHandPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace secondHandPro.Controllers
{

    public class ConnectionController : Controller
    {
        private secondHandProContext db = new secondHandProContext();
        // GET: Conection
        public ActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public string CheckSignIn(string username, string password)
        {
            User u = db.Users.Where(x => x.Username == username).FirstOrDefault();
            if (Session["name"] != null)
            {
                return "Please LogOut Before SignIn To Diffrent User";
            }
            Session["name"] = username;

            if (u == null)
                return "Login Failed,No such user name";
            if (u.Username == null)
                return "Login Failed";

            if (u.Password.ToUpper() != password.ToUpper())
                return "Login Failed,Wrong Password";
            if (Session["name"] != null && u.Username.Equals(Session["name"].ToString()))
                return Session["name"].ToString();

            return "Login Succeful";
        }
        public string returnUserName()
        {
            if (Session["name"].ToString() == null)
                return "  ";
            return Session["name"].ToString();
        }
        public void LogOut()
        {
            Session["name"] = null;
            Session.Remove("name");
            Session.Abandon();
        }
    }
}