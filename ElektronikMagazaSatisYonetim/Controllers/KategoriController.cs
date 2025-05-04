using BusinessLayer.Abstract;
using ElektronikMagazaSatisYonetim.Controllers;
using EntityLayer.Models;
using Microsoft.AspNetCore.Mvc;

public class KategoriController : BaseController
{
    private readonly IKategoriServis _kategoriServis;

    public KategoriController(IKategoriServis kategoriServis)
    {
        _kategoriServis = kategoriServis;
    }

 
    public IActionResult Index()
    {
        var kategoriler = _kategoriServis.TumunuGetir();
        return View(kategoriler);
    }

   
    public IActionResult KategoriEkle()
    {
        return View();
    }

   
    [HttpPost]
    public IActionResult KategoriEkle(Kategori kategori)
    {
        if (ModelState.IsValid)
        {
            _kategoriServis.Ekle(kategori);
            return RedirectToAction("Index");
        }
        return View(kategori);
    }

 
    public IActionResult KategoriGuncelle(int id)
    {
        var kategori = _kategoriServis.GetirID(id);
        if (kategori == null)
            return NotFound();

        return View(kategori);
    }

    
    [HttpPost]
    public IActionResult KategoriGuncelle(Kategori kategori)
    {
        if (ModelState.IsValid)
        {
            _kategoriServis.Guncelle(kategori);
            return RedirectToAction("Index");
        }
        return View(kategori);
    }

    // Kategori Sil
    public IActionResult KategoriSil(int id)
    {
        var kategori = _kategoriServis.GetirID(id);
        if (kategori == null)
            return NotFound();

        _kategoriServis.Sil(kategori);
        return RedirectToAction("Index");
    }
}
