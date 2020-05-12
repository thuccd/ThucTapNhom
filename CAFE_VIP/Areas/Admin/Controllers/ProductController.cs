using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CAFE_VIP.Models;
using Models.EF;
using CAFE_VIP.Common;
using System.IO;
using System.Web.UI.WebControls;
using System.Net;
using System.Data.Entity;



namespace CAFE_VIP.Areas.Admin.Controllers
{
    public class PRODUCTController : Controller
    {
        // GET: Admin/PRODUCT
        CafeDbContext db = new CafeDbContext();
        public ActionResult Index()
        {

            return View(db.PRODUCTs.Where(n => n.ProductStatus == false).OrderBy(n => n.CategoryID));
        }
        [HttpGet]
        public ActionResult TaoMoi()
        {
            ViewBag.CategoryID = new SelectList(db.CATEGORies.OrderBy(n => n.CategoryID), "CategoryID", "CategoryName");
            return View();
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult TaoMoi(PRODUCT sp, HttpPostedFileBase ShowImage)
        {
            //load list  mã sản phẩm 
            ViewBag.CategoryID = new SelectList(db.CATEGORies.OrderBy(n => n.CategoryID), "CategoryID", "CategoryName");

            // kiểm tra hình ảnh đã tồn tại hay chưa 
            if (ShowImage.ContentLength > 0)
            {
                //lấy tên hình ảnh 
                var filename = Path.GetFileName(ShowImage.FileName);
                //lấy hình ảnh chuyển đến thư mục hình ảnh 
                var path = Path.Combine(Server.MapPath("~/Content/HinhAnhSP"), filename);
                //nếu thư mục đã có hình ảnh thì xuất ra thông báo 
                if (System.IO.File.Exists(path))
                {
                    ViewBag.upload = "Hình Đã Tồn Tại ";
                    return View();
                }
                else
                {
                    //lấy  hình ảnh đưa ra thư mục Hình Ảnh Sản Phẩm 
                    ShowImage.SaveAs(path);
                    sp.ShowImage = filename;
                }
            }
            db.PRODUCTs.Add(sp);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        [ValidateInput(false)]
        [HttpGet]
        public ActionResult ChinhSua(int? id)
        {
            //lấy sản phẩm chỉnh sửa dựa vào id 
            //nếu id không tương ứng 
            if (id == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            PRODUCT sp = db.PRODUCTs.FirstOrDefault(n => n.ProductID == id);
            if (sp == null)
            {
                return HttpNotFound();
            }

            //load  dropdow list mã loại mónFirstOrDefault
            ViewBag.CategoryID = new SelectList(db.CATEGORies.OrderBy(n => n.CategoryID), "CategoryID", "CategoryName", sp.CategoryID);
            return View(sp);
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult ChinhSua(PRODUCT model, HttpPostedFileBase ShowImage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult Xoa(int? id)
        {
            //lấy sản phẩm chỉnh sửa dựa vào id 
            //nếu id không tương ứng 
            if (id == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            PRODUCT sp = db.PRODUCTs.FirstOrDefault(n => n.ProductID == id);
            if (sp == null)
            {
                return HttpNotFound();
            }
            //load  dropdow list mã loại món 
            ViewBag.CategoryID = new SelectList(db.CATEGORies.ToList().OrderBy(n => n.CategoryID), "CategoryID", "CategoryName", sp.CategoryID);
            return View(sp);
        }
        [HttpPost]
        public ActionResult Xoa(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            PRODUCT model = db.PRODUCTs.FirstOrDefault(n => n.ProductID == id);
            if (model == null)
            {
                return HttpNotFound();
            }
            db.PRODUCTs.Remove(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}