using BusinessLayer.Abstract;
using EntityLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;
using System;

public class UrunController : Controller
{
    private readonly IUrunServis _urunServis;
    private readonly IKategoriServis _kategoriServis;
    private readonly IMarkaServis _markaServis;

    public UrunController(IUrunServis urunServis, IKategoriServis kategoriServis, IMarkaServis markaServis)
    {
        _urunServis = urunServis;
        _kategoriServis = kategoriServis;
        _markaServis = markaServis;
    }

    public IActionResult TestEkle()
    {
        var urun = new Urun
        {
            Ad = "Test Ürün",
            KategoriID = 1,
            MarkaID = 1,
            Fiyat = 100,
            ResimURL = "/urunResimleri/test.jpg"
        };
        _urunServis.Ekle(urun);
        return Content("Eklendi");
    }

    public IActionResult Index()
    {
        var urunler = _urunServis.UrunleriKategoriVeMarkaIleGetir();
        return View(urunler);
    }

    public IActionResult UrunEkle()
    {
        ViewBag.Kategoriler = new SelectList(_kategoriServis.TumunuGetir(), "Id", "Ad");
        ViewBag.Markalar = new SelectList(_markaServis.TumunuGetir(), "Id", "Ad");
        return View();
    }

    [HttpPost]
    public IActionResult UrunEkle(Urun urun, IFormFile resimDosyasi)
    {
        if (resimDosyasi != null && resimDosyasi.Length > 0)
        {
            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "urunResimleri");

            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(resimDosyasi.FileName);
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            // Dosya kopyalama işlemi senkron yapılır
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                resimDosyasi.CopyTo(fileStream);
            }

            urun.ResimURL = "/urunResimleri/" + uniqueFileName;
        }

        _urunServis.Ekle(urun);
        return RedirectToAction("Index");
    }

    public IActionResult UrunGuncelle(int id)
    {
        var urun = _urunServis.GetirID(id);
        if (urun == null)
            return NotFound();

        ViewBag.Kategoriler = new SelectList(_kategoriServis.TumunuGetir(), "Id", "Ad", urun.KategoriID);
        ViewBag.Markalar = new SelectList(_markaServis.TumunuGetir(), "Id", "Ad", urun.MarkaID);
        return View(urun);
    }

    [HttpPost]
    public IActionResult UrunGuncelle(Urun guncellenenUrun, IFormFile? resimDosyasi)
    {
        var mevcutUrun = _urunServis.GetirID(guncellenenUrun.Id);
        if (mevcutUrun == null)
            return NotFound();

        // Resim güncellemesi varsa
        if (resimDosyasi != null && resimDosyasi.Length > 0)
        {
            // Eski resmi sil
            if (!string.IsNullOrEmpty(mevcutUrun.ResimURL))
            {
                var eskiDosyaYolu = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", mevcutUrun.ResimURL.TrimStart('/'));
                if (System.IO.File.Exists(eskiDosyaYolu))
                    System.IO.File.Delete(eskiDosyaYolu);
            }

            // Yeni resmi yükle
            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "urunResimleri");
            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(resimDosyasi.FileName);
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            // Dosya kopyalama işlemi senkron yapılır
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                resimDosyasi.CopyTo(fileStream);
            }

            mevcutUrun.ResimURL = "/urunResimleri/" + uniqueFileName;
        }

        // Diğer alanları güncelle
        mevcutUrun.Ad = guncellenenUrun.Ad;
        mevcutUrun.Fiyat = guncellenenUrun.Fiyat;
        mevcutUrun.KategoriID = guncellenenUrun.KategoriID;
        mevcutUrun.MarkaID = guncellenenUrun.MarkaID;

        _urunServis.Guncelle(mevcutUrun);

        return RedirectToAction("Index");
    }

    public IActionResult UrunSil(int id)
    {
        var urun = _urunServis.GetirID(id);
        if (urun == null)
            return NotFound();

        // Resmi sil
        if (!string.IsNullOrEmpty(urun.ResimURL))
        {
            var dosyaYolu = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", urun.ResimURL.TrimStart('/'));
            if (System.IO.File.Exists(dosyaYolu))
                System.IO.File.Delete(dosyaYolu);
        }

        _urunServis.Sil(urun);
        return RedirectToAction("Index");
    }
}
