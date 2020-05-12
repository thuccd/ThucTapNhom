using Models.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CAFE_VIP.Models;
using CAFE_VIP.Common;
using Models.EF;

namespace CAFE_VIP.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(LoginModels models)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.Login(models.UserName, models.PassWord);
                if (result)
                {
                    var user = dao.GetbyID(models.UserName);
                    var userSession = new UserLogin();
                    userSession.UserName = user.UserName;
                    userSession.UserID = user.UserId;
                    userSession.PassWord = user.UserPassword;
                    Session.Add(CommonConstant.USER_SESSION, userSession);
                    return RedirectToAction("HomeAdmin", "Admin");
                }
                else
                {
                    ModelState.AddModelError("", "Login fail");
                }
            }
            return View("Index");
        }
        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(USER user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                long id = dao.Insert(user);
                if (id > 0)
                {
                    return RedirectToAction("Index", "Login");
                }
            }
            else
            {
                ModelState.AddModelError("", "Add succsessfull");
            }
            return View("Index");
        }
    }
}