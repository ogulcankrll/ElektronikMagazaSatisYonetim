using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ElektronikMagazaSatisYonetim.Controllers
{

    public class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // Session verilerini ViewBag ile ilet
            ViewBag.RolID = HttpContext.Session.GetInt32("RolID");
            ViewBag.PersonelAdSoyad = HttpContext.Session.GetString("PersonelAdSoyad");

            base.OnActionExecuting(context); // Temel işlevsellik
        }
    }
 }