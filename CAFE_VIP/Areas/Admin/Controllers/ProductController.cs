using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CAFE_VIP.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        CafeDbContext db = new CafeDbContext();
        // GET: Admin/Product
        public ActionResult Index()
        {
            var lstsp = db.PRODUCTs.OrderBy(x => x.ProductID ).ToList();
            return View(lstsp);
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Taomoi()
        {
            return View();
        }
    }
}