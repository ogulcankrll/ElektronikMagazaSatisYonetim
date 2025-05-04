using BusinessLayer.Abstract;
using ElektronikMagazaSatisYonetim.Controllers;
using EntityLayer.Models;
using Microsoft.AspNetCore.Mvc;

public class KargoFirmaController : BaseController
{
    private readonly IKargoFirmaServis _kargoFirmaServis;

    public KargoFirmaController(IKargoFirmaServis kargoFirmaServis)
    {
        _kargoFirmaServis = kargoFirmaServis;
    }

   
    public IActionResult Index()
    {
        var kargoFirmalari = _kargoFirmaServis.TumunuGetir();
        return View(kargoFirmalari);
    }

    // KargoFirma ekleme sayfası
    public IActionResult KargoFirmaEkle()
    {
        return View();
    }

    [HttpPost]
    public IActionResult KargoFirmaEkle(KargoFirma kargoFirma)
    {
        if (ModelState.IsValid)
        {
            _kargoFirmaServis.Ekle(kargoFirma);
            return RedirectToAction("Index");
        }
        return View(kargoFirma);
    }

    // KargoFirma güncelleme sayfası
    public IActionResult KargoFirmaGuncelle(int id)
    {
        var kargoFirma = _kargoFirmaServis.GetirID(id);
        if (kargoFirma == null)
            return NotFound();
        return View(kargoFirma);
    }

    [HttpPost]
    public IActionResult KargoFirmaGuncelle(KargoFirma kargoFirma)
    {
        if (ModelState.IsValid)
        {
            _kargoFirmaServis.Guncelle(kargoFirma);
            return RedirectToAction("Index");
        }
        return View(kargoFirma);
    }

    // KargoFirma silme işlemi
    public IActionResult KargoFirmaSil(int id)
    {
        var kargoFirma = _kargoFirmaServis.GetirID(id);
        if (kargoFirma == null)
            return NotFound();
        _kargoFirmaServis.Sil(kargoFirma);
        return RedirectToAction("Index");
    }
}
