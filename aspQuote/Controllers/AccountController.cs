//using System;
//using System.Web;
//using System.Web.Mvc;
//using System.Web.Security;
//using aspQuote.Models;

//namespace aspQuote.Controllers
//{
//    public class AccountController : Controller
//    {
//        // GET: /Account/Login
//        [AllowAnonymous]
//        //public ActionResult Login(string returnUrl)
//        //{
//        //    ViewBag.ReturnUrl = returnUrl;
//        //    return View();
//        //}
//        public ActionResult Login(LoginModel model)
//        {
//            if (ModelState.IsValid && AuthenticateUser(model)) // Assuming AuthenticateUser is implemented
//            {
//                if (User.IsInRole("Admin"))
//                {
//                    return RedirectToAction("Index", "Admin"); // Redirect to admin page
//                }
//                else
//                {
//                    return RedirectToAction("Index", "Home"); // Redirect to default page
//                }
//            }

//            // If login fails, add error message and redisplay login form
//            ModelState.AddModelError("", "Invalid login attempt.");
//            return View();
//        }

//        // POST: /Account/Login
//        [HttpPost]
//        [AllowAnonymous]
//        [ValidateAntiForgeryToken]
//        public ActionResult Login(LoginViewModel model, string returnUrl)
//        {
//            if (ModelState.IsValid)
//            {
//                // Kullanıcı doğrulama işlemi (örnek bir kullanıcı kontrolü)
//                if (model.Email == "admin@admin.com" && model.Password == "admin123")
//                {
//                    FormsAuthentication.SetAuthCookie(model.Email, model.RememberMe);

//                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/") && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
//                    {
//                        return Redirect(returnUrl);
//                    }
//                    else
//                    {
//                        return RedirectToAction("Create", "Insuree");
//                    }
//                }
//                else
//                {
//                    ModelState.AddModelError("", "Geçersiz giriş denemesi.");
//                }
//            }

//            // Eğer buraya geldiyseniz, giriş başarısız demektir, formu yeniden gösterin
//            return View(model);
//        }

//        // POST: /Account/LogOff
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult LogOff()
//        {
//            FormsAuthentication.SignOut();
//            return RedirectToAction("Create", "Insuree");
//        }
//    }
//}
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using aspQuote.Models;

namespace aspQuote.Controllers
{
    public class AccountController : Controller
    {
        // GET: /Account/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            //if (model.Email == "admin@admin.com" && model.Password == "admin123")
            //{
            //    return RedirectToAction("Admin", "Insuree");
            //}
            //else
            //{
            //    return View();
            //}
            if (ModelState.IsValid)
            {

                if (AuthenticateUser(model))
                {
                    User.Identity.IsAuthenticated.Equals(true);
                    FormsAuthentication.SetAuthCookie(model.Email, model.RememberMe);

                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/") && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                    {
                        return RedirectToAction("Create", "Insuree");
                    }
                    else
                    {
                        if (User.IsInRole("Admin"))
                        {
                            return RedirectToAction("Create", "Insuree"); // Redirect to default page
                        }
                        else
                        {
                            return RedirectToAction("Admin", "Insuree"); // Redirect to admin page
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Failed to login.");
                }
            }

            return RedirectToAction("Create", "Insuree");
        }

        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Create", "Admin");
        }

        bool AuthenticateUser(LoginViewModel model)
        {
            if (model.Email == "admin@admin.com" && model.Password == "admin123")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
