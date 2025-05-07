using BusinessLayer.Abstract;
using EntityLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

public class UrunVaryasyonController : Controller
{
    private readonly IUrunVaryasyonServis _varyasyonServis;
    private readonly IUrunServis _urunServis;

    public UrunVaryasyonController(IUrunVaryasyonServis varyasyonServis, IUrunServis urunServis)
    {
        _varyasyonServis = varyasyonServis;
        _urunServis = urunServis;
    }

    public IActionResult Index()
    {
        var varyasyonlar = _varyasyonServis.UrunVaryasyonlariUrunIleGetir();
        return View(varyasyonlar);
    }

    public IActionResult VaryasyonEkle()
    {
        ViewBag.Urunler = new SelectList(_urunServis.TumunuGetir(), "Id", "Ad");
        return View();
    }

    [HttpPost]
    public IActionResult VaryasyonEkle(UrunVaryasyon model)
    {
        if (ModelState.IsValid)
        {
            _varyasyonServis.Ekle(model);
            return RedirectToAction("Index");
        }
        ViewBag.Urunler = new SelectList(_urunServis.TumunuGetir(), "Id", "Ad");
        return View(model);
    }

    public IActionResult VaryasyonGuncelle(int id)
    {
        var varyasyon = _varyasyonServis.GetirID(id);
        if (varyasyon == null) return NotFound();

        ViewBag.Urunler = new SelectList(_urunServis.TumunuGetir(), "Id", "Ad", varyasyon.UrunID);
        return View(varyasyon);
    }

    [HttpPost]
    public IActionResult VaryasyonGuncelle(UrunVaryasyon model)
    {
        if (ModelState.IsValid)
        {
            _varyasyonServis.Guncelle(model);
            return RedirectToAction("Index");
        }
        ViewBag.Urunler = new SelectList(_urunServis.TumunuGetir(), "Id", "Ad", model.UrunID);
        return View(model);
    }

    public IActionResult Sil(int id)
    {
        var varyasyon = _varyasyonServis.GetirID(id);
        if (varyasyon == null) return NotFound();

        _varyasyonServis.Sil(varyasyon);
        return RedirectToAction("Index");
    }

    public IActionResult TestEkle()
    {
        // UrunID'nin geçerli bir ürün ID'si olup olmadığını kontrol et
        var urun = _urunServis.GetirID(1025); // UrunID = 1, ancak bu ID'nin mevcut olup olmadığını kontrol etmelisin
        if (urun == null)
        {
            return Content("Geçersiz UrunID");
        }

        // Yeni bir UrunVaryasyon nesnesi oluşturuluyor
        var varyasyon = new UrunVaryasyon
        {
            VaryasyonAdi = "Test Ürün", // Varyasyon adı
            UrunID = 1025,                // UrunID, burada örnek olarak 1 verdik.
            EkFiyat = 100,             // Ek fiyat
            EklenmeTarihi = DateTime.Now // Eklenme tarihi
        };

        // UrunVaryasyon nesnesini veritabanına ekliyoruz
        _varyasyonServis.Ekle(varyasyon); // Burada _varyasyonServis kullanılıyor, çünkü modelin işlemleri burada yapılmalı

        // "Eklendi" mesajı döndürülüyor
        return Content("Eklendi");
    }
}
