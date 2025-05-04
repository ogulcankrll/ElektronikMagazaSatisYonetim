using BusinessLayer.Abstract;
using ElektronikMagazaSatisYonetim.Controllers;
using EntityLayer.Models;
using Microsoft.AspNetCore.Mvc;

public class MusteriController : BaseController
{
    private readonly IMusteriServis _musteriServis;

    public MusteriController(IMusteriServis musteriServis)
    {
        _musteriServis = musteriServis;
    }

   
    public IActionResult Index()
    {
        var musteriler = _musteriServis.TumunuGetir();
        return View(musteriler);
    }

  
    public IActionResult MusteriEkle()
    {
        return View();
    }

  
    [HttpPost]
    public IActionResult MusteriEkle(Musteri musteri)
    {
        if (ModelState.IsValid)
        {
            _musteriServis.Ekle(musteri);
            return RedirectToAction("Index");
        }
        return View(musteri);
    }

    
    public IActionResult MusteriGuncelle(int id)
    {
        var musteri = _musteriServis.GetirID(id);
        if (musteri == null)
            return NotFound();
        return View(musteri);
    }

   
    [HttpPost]
    public IActionResult MusteriGuncelle(Musteri musteri)
    {
        if (ModelState.IsValid)
        {
            _musteriServis.Guncelle(musteri);
            return RedirectToAction("Index");
        }
        return View(musteri);
    }


    public IActionResult MusteriSil(int id)
    {
        var musteri = _musteriServis.GetirID(id);
        if (musteri == null)
            return NotFound();

        _musteriServis.Sil(musteri);
        return RedirectToAction("Index");
    }
}
