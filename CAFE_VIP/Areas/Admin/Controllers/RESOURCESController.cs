using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Models.EF;
namespace CAFE_VIP.Areas.Admin.Controllers
{
    public class RESOURCESController : Controller
    {
        private CafeDbContext db = new CafeDbContext();
        [HttpPost]
        public ActionResult Index(string searchingg)
        {

            var linkss = from l in db.RESOURCES // lấy toàn bộ liên kết
                        select l;

            if (!String.IsNullOrEmpty(searchingg)) // kiểm tra chuỗi tìm kiếm có rỗng/null hay không
            {
                linkss = linkss.Where(s => s.Resourcesname.Contains(searchingg)); //lọc theo chuỗi tìm kiếm.Contains(searching));
            }

            return View(linkss); //trả về kết quả

        }
        [HttpGet]
        // GET: Admin/RESOURCES
        public ActionResult Index()
        {
            return View(db.RESOURCES.ToList());
        }

        // GET: Admin/RESOURCES/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RESOURCE rESOURCE = db.RESOURCES.Find(id);
            if (rESOURCE == null)
            {
                return HttpNotFound();
            }
            return View(rESOURCE);
        }

        // GET: Admin/RESOURCES/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/RESOURCES/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ResourcesID,Resourcesname,Quantity,Total")] RESOURCE rESOURCE)
        {
            if (ModelState.IsValid)
            {
                db.RESOURCES.Add(rESOURCE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rESOURCE);
        }

        // GET: Admin/RESOURCES/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RESOURCE rESOURCE = db.RESOURCES.Find(id);
            if (rESOURCE == null)
            {
                return HttpNotFound();
            }
            return View(rESOURCE);
        }

        // POST: Admin/RESOURCES/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ResourcesID,Resourcesname,Quantity,Total")] RESOURCE rESOURCE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rESOURCE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rESOURCE);
        }

        // GET: Admin/RESOURCES/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RESOURCE rESOURCE = db.RESOURCES.Find(id);
            if (rESOURCE == null)
            {
                return HttpNotFound();
            }
            return View(rESOURCE);
        }

        // POST: Admin/RESOURCES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RESOURCE rESOURCE = db.RESOURCES.Find(id);
            db.RESOURCES.Remove(rESOURCE);
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
    }
}
