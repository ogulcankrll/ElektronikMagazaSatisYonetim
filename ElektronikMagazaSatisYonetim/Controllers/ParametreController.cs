using BusinessLayer.Abstract;
using EntityLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace ElektronikMagazaSatisYonetim.Controllers
{
    public class ParametreController : Controller
    {
        private readonly IGenericService<TeslimatTipi> _teslimatService;
        private readonly IGenericService<SiparisDurumu> _siparisDurumuService;

        public ParametreController(
            IGenericService<TeslimatTipi> teslimatService,
            IGenericService<SiparisDurumu> siparisDurumuService)
        {
            _teslimatService = teslimatService;
            _siparisDurumuService = siparisDurumuService;
        }

        // ===== TESLİMAT TİPİ =====

        public IActionResult TeslimatTipleri()
        {
            var teslimatTipleri = _teslimatService.TumunuGetir();
            return View(teslimatTipleri);
        }

        public IActionResult TeslimatTipiEkle()
        {
            return View(new TeslimatTipi());
        }

        [HttpPost]
        public IActionResult TeslimatTipiEkle(TeslimatTipi model)
        {
            _teslimatService.Ekle(model);
            return RedirectToAction("TeslimatTipleri");
        }

        public IActionResult TeslimatTipiSil(int id)
        {
            var teslimat = _teslimatService.GetirID(id);
            if (teslimat != null)
                _teslimatService.Sil(teslimat);

            return RedirectToAction("TeslimatTipleri");
        }

        // ===== SİPARİŞ DURUMU =====

        public IActionResult SiparisDurumlari()
        {
            var siparisDurumlari = _siparisDurumuService.TumunuGetir();
            return View(siparisDurumlari);
        }

        public IActionResult SiparisDurumuEkle()
        {
            return View(new SiparisDurumu());
        }

        [HttpPost]
        public IActionResult SiparisDurumuEkle(SiparisDurumu model)
        {
            _siparisDurumuService.Ekle(model);
            return RedirectToAction("SiparisDurumlari");
        }

        public IActionResult Sil(int id, string tip)
        {
            if (tip == "Teslimat")
            {
                var teslimat = _teslimatService.GetirID(id);
                if (teslimat != null)
                    _teslimatService.Sil(teslimat);
                return RedirectToAction("TeslimatTipleri");
            }
            else if (tip == "Siparis")
            {
                var durum = _siparisDurumuService.GetirID(id);
                if (durum != null)
                    _siparisDurumuService.Sil(durum);
                return RedirectToAction("SiparisDurumlari");
            }

            return NotFound();
        }
    }
}
