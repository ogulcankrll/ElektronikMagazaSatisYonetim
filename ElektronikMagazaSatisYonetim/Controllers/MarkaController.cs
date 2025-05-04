using BusinessLayer.Abstract;
using ElektronikMagazaSatisYonetim.Controllers;
using EntityLayer.Models;
using Microsoft.AspNetCore.Mvc;

public class MarkaController : BaseController
{
    private readonly IMarkaServis _markaServis;

    public MarkaController(IMarkaServis markaServis)
    {
        _markaServis = markaServis;
    }

    public IActionResult Index()
    {
        var markalar = _markaServis.TumunuGetir();
        return View(markalar);
    }

    public IActionResult MarkaEkle()
    {
        return View();
    }

    [HttpPost]
    public IActionResult MarkaEkle(Marka marka)
    {
        if (ModelState.IsValid)
        {
            _markaServis.Ekle(marka);
            return RedirectToAction("Index");
        }
        return View(marka);
    }

    public IActionResult MarkaGuncelle(int id)
    {
        var marka = _markaServis.GetirID(id);
        if (marka == null)
            return NotFound();
        return View(marka);
    }

    [HttpPost]
    public IActionResult MarkaGuncelle(Marka marka)
    {
        if (ModelState.IsValid)
        {
            _markaServis.Guncelle(marka);
            return RedirectToAction("Index");
        }
        return View(marka);
    }

    public IActionResult MarkaSil(int id)
    {
        var marka = _markaServis.GetirID(id);
        if (marka == null)
            return NotFound();

        _markaServis.Sil(marka);
        return RedirectToAction("Index");
    }
}
