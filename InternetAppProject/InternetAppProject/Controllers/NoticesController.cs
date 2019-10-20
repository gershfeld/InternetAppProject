using System;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Collections.Generic;
using secondHandPro.Models;

namespace secondHandPro.Controllers
{
    public class NoticesController : Controller
    {
        private secondHandProContext db = new secondHandProContext();

        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase fileupload)
        {
            if (fileupload != null)
            {
                
                if (Path.GetExtension(fileupload.FileName) == ".jpeg" || Path.GetExtension(fileupload.FileName) == ".PNG" || Path.GetExtension(fileupload.FileName) == ".BMP")
                {
                    string fileName = Path.GetFileName(fileupload.FileName);
                    int fileSize = fileupload.ContentLength;
                    fileupload.SaveAs(Server.MapPath("~/Media/" + fileName));
                    string FilePath = "~/Media/" + fileName;
                    
                }

            }
            return RedirectToAction("Create");
        }

        // GET: Notices
       
          public ActionResult Index(string SearchString,string category="",string state="",string contact="",string location="",string name="",string description="", int flag=1)
        {
           var notices = from n in db.Notices select n;
            if (flag == 1)
            {
                if (!String.IsNullOrEmpty(SearchString))
                {
                    notices = notices.Where(s => s.Category.ToString().Contains(SearchString) ||
                    s.State.ToString().Contains(SearchString) ||
                    s.Contact.Contains(SearchString) ||
                    s.Location.ToString().Contains(SearchString) ||
                    s.Name.Contains(SearchString) ||
                    s.Description.Contains(SearchString));
                }
            }
            else
                          if (!String.IsNullOrEmpty(category+state+contact+location+name+description))
            {
                notices = notices.Where(s => s.Category.ToString().Contains(category) &&
               s.State.ToString().Contains(state) &&
               s.Location.ToString().Contains(location));
            }
                    return View(notices.ToList());
        }
      [HttpPost]
        public string GroupByState(string state)
        {
            
            var notices = db.Notices.GroupBy(item => item.State);
            notices = notices.Where(item => item.Key.ToString().Equals(state));
            int count = notices.FirstOrDefault().Count();
            
            return count.ToString();
        }
        public ActionResult NoticesToUsers()
        {
            var notices = from notice in db.Notices
                          join user in db.Users on notice.U.Username equals user.Username
                          select notice;


             return View(notices.ToList());             
        }
        public ActionResult NoticesToUser()
        {
            var notices = from notice in db.Notices
                       join user in db.Users on notice.U.Username equals user.Username
                       select notice;
            notices = notices.Where(item => item.U.isAdmin);

            
            

            return View(notices.ToList());
        }



        // GET: Notices/Details/5
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Notice notice = db.Notices.Find(id);
            if (notice == null)
            {
                return HttpNotFound();
            }
            notice.counter += 1;
            db.SaveChanges();
            return View(notice);
        }
           

        // GET: Notices/Create
        [MyAuthorized2]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Notices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Contact,Name,Description,Price,State,Category")] Notice notice, HttpPostedFileBase fileupload)
        {
            if (ModelState.IsValid)
            {
                var username = (Session["name"].ToString());
                notice.U = db.Users.Where(x => x.Username.Equals(username)).FirstOrDefault();
                if (!fileupload.Equals(null))
                {

               
                string fileName = Path.GetFileName(fileupload.FileName);
                fileupload.SaveAs(Server.MapPath("~/Media/" + fileName));
                string FilePath = "~/Media/" + fileName;
                notice.Image = FilePath;
                notice.counter = 0;

                db.Notices.Add(notice);
                db.SaveChanges();
                return RedirectToAction("Index");
                }
            }

            return View(notice);
        }
        public ActionResult topNotice()
        {
            int c=0;
            var notices = from n in db.Notices select n;
            notices.OrderByDescending(x => x.counter);
            notices = notices.Take(5);
          
            return View(notices.ToList());
        }

        // GET: Notices/Edit/5
        [MyAuthorized]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Notice notice = db.Notices.Find(id);
            if (notice == null)
            {
                return HttpNotFound();
            }
            return View(notice);
        }

        // POST: Notices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Contact,Name,Description,Price,State,Category")] Notice notice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(notice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(notice);
        }

        // GET: Notices/Delete/5
        [MyAuthorized]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Notice notice = db.Notices.Find(id);
            if (notice == null)
            {
                return HttpNotFound();
            }
            return View(notice);
        }

        // POST: Notices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            Notice notice = db.Notices.Find(id);
            db.Notices.Remove(notice);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        


 public string countFur()
        {
            return db.Notices.Where(x => x.Category.ToString() == "Furniture").Count().ToString();
        }
        public string conttSprots()
        {
            return db.Notices.Where(x => x.Category.ToString() == "Sports").Count().ToString();
        }
        public string countCars()
        {
            string s = db.Notices.Where(x => x.Category.ToString() == "Cars").Count().ToString();
            return s;
        }

        public string countElec()
        {
            return db.Notices.Where(x => x.Category.ToString() == "Electronics").Count().ToString();

        }

        public string countJE()
        {
            return db.Notices.Where(x => x.Category.ToString() == "Jewelry").Count().ToString();

        }
        public string PriceRange()
        {
            string returnType;
            int range1, range2, range3, range4, range5;
            range1 = db.Notices.Where(x => (x.Price >= 0 && x.Price < 10000)).Count();
            range2 = db.Notices.Where(x => (x.Price >= 10000 && x.Price < 25000)).Count();
            range3 = db.Notices.Where(x => (x.Price >= 25000 && x.Price < 50000)).Count();
            range4 = db.Notices.Where(x => (x.Price >= 50000 && x.Price < 100000)).Count();
            range5 = db.Notices.Where(x => x.Price >= 100000).Count();
            return range1.ToString() + "," + range2.ToString() + "," + range3.ToString() + "," + range4.ToString() + "," + range5.ToString();
        }

    }
}







