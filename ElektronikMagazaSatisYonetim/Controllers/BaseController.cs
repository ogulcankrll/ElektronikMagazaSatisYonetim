using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ElektronikMagazaSatisYonetim.Controllers
{

    public class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // Personel bilgileri (Admin Paneli için)
            ViewBag.RolID = HttpContext.Session.GetInt32("RolID");
            ViewBag.PersonelAdSoyad = HttpContext.Session.GetString("PersonelAdSoyad");

            // Müşteri bilgileri (E-Ticaret için)
            ViewBag.MusteriID = HttpContext.Session.GetInt32("MusteriId");
            ViewBag.MusteriAdSoyad = HttpContext.Session.GetString("MusteriAdSoyad");

            base.OnActionExecuting(context); // Temel işlevsellik
        }
    }
 }