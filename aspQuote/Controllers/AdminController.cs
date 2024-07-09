using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using aspQuote.Models;

namespace aspQuote.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        Model1 db = new Model1();

        // GET: Admin
        //public ActionResult Index()
        //{
        //    var insurees = db.Insurees.ToList();
        //    return View(insurees);
        //}
        public class AdminAuthorizeAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                if (!filterContext.HttpContext.User.IsInRole("Admin"))
                {
                    filterContext.Result = new RedirectToRouteResult("Default",
                        new RouteValueDictionary { { "controller", "Account" }, { "action", "Login" } });
                }
            }
        }
        public ActionResult Index()
        {
            if (!User.IsInRole("Admin"))
            {
                return View("Account/Login"); // Redirect to login page
            }
            return View();
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
