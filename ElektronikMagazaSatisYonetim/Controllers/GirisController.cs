using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ElektronikMagazaSatisYonetim.Controllers
{
    public class GirisController : BaseController
    {
        private readonly IPersonelServis _personelServis;

        public GirisController(IPersonelServis personelServis)
        {
            _personelServis = personelServis;
        }

        [HttpGet]
        public IActionResult Giris()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Giris(string eposta, string sifre)
        {
            var girisYapan = _personelServis.TumunuGetir()
                              .FirstOrDefault(p => p.Eposta == eposta && p.Sifre == sifre);

            if (girisYapan != null)
            {
                // Giriş başarılıysa oturum açıyoruz
                HttpContext.Session.SetInt32("PersonelID", girisYapan.Id);
                HttpContext.Session.SetString("PersonelAdSoyad", girisYapan.Ad + " " + girisYapan.Soyad);
                HttpContext.Session.SetInt32("RolID", girisYapan.RolID);

                // Kullanıcının rolüne göre yönlendirme yapalım
                if (girisYapan.RolID == 3) // Admin rolü
                {
                    return RedirectToAction("Index", "AnaSayfa"); // Admin yönlendirmesi
                }
                else if (girisYapan.RolID == 2) // Personel rolü
                {
                    return RedirectToAction("Index", "AnaSayfa"); // Personel yönlendirmesi
                }
                else
                {
                    return RedirectToAction("Index", "Home"); // Diğer herhangi bir rol için ana sayfa
                }
            }

            // Giriş başarısızsa hata mesajı göster
            ViewBag.Hata = "Geçersiz e-posta veya şifre!";
            return View();
        }

        public IActionResult Cikis()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Giris", "Giris"); 
        }

    }
}
