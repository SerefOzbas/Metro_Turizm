using Bll.Abstract;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.MVC.Tools;

namespace UI.MVC.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User user)
        {
            var incominguser = _userService.GetUserByLogin(user.Email, user.Password);
            if (incominguser != null)
            {
                Session["UserID"] = incominguser.ID;
                return RedirectToAction("Index", "Home", incominguser.ID);
            }
            ViewBag.Error = "Kullanıcı bulunamadı";
            ModelState.AddModelError("", "Yanlış kullanıcı adı veya parola");
            return View();

        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(User user)
        {
            try
            {
                _userService.Insert(user);
                bool sonuc = MailHelper.SendConfirmationMail(user.FirstName, user.Email);
                if (!sonuc)
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Veritabanına ekleme hatası";
                return View();
            }
            return RedirectToAction("Login", "Account");
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login", "Account");
        }
    }
}