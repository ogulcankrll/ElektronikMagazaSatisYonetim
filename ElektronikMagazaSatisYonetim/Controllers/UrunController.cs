using BusinessLayer.Abstract;
using EntityLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;
using System;
using ElektronikMagazaSatisYonetim.Controllers;

public class UrunController : BaseController
{
    private readonly IUrunServis _urunServis;
    private readonly IKategoriServis _kategoriServis;
    private readonly IMarkaServis _markaServis;

    // Constructor
    public UrunController(IUrunServis urunServis, IKategoriServis kategoriServis, IMarkaServis markaServis)
    {
        _urunServis = urunServis;
        _kategoriServis = kategoriServis;
        _markaServis = markaServis;
    }

    // Ürünleri Listele
    public IActionResult Index()
    {
        var urunler = _urunServis.UrunleriKategoriVeMarkaIleGetir();
        return View(urunler);
    }

    // Ürün Ekleme Sayfası
    public IActionResult UrunEkle()
    {
        ViewBag.Kategoriler = new SelectList(_kategoriServis.TumunuGetir(), "Id", "Ad");
        ViewBag.Markalar = new SelectList(_markaServis.TumunuGetir(), "Id", "Ad");
        return View();
    }

    // Ürün Ekleme
    [HttpPost]
    public IActionResult UrunEkle(Urun urun, IFormFile resimDosyasi)
    {
        if (resimDosyasi != null && resimDosyasi.Length > 0)
        {
            // Dosya boyutu kontrolü
            if (resimDosyasi.Length > 5 * 1024 * 1024)
            {
                ModelState.AddModelError("ResimDosyasi", "Dosya boyutu 5 MB'dan büyük olamaz.");
                return View(); // Hata mesajı döndürülebilir
            }

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

    // Ürün Güncelleme Sayfası
    public IActionResult UrunGuncelle(int id)
    {
        var urun = _urunServis.GetirID(id);
        if (urun == null)
            return NotFound();

        ViewBag.Kategoriler = new SelectList(_kategoriServis.TumunuGetir(), "Id", "Ad", urun.KategoriID);
        ViewBag.Markalar = new SelectList(_markaServis.TumunuGetir(), "Id", "Ad", urun.MarkaID);

        return View(urun);
    }

    // Ürün Güncelleme İşlemi
    [HttpPost]
    public IActionResult UrunGuncelle(Urun urun, IFormFile? resimDosyasi)
    {
        if (ModelState.IsValid)
        {
            // Mevcut ürünü getir
            var mevcutUrun = _urunServis.GetirID(urun.Id);
            if (mevcutUrun == null)
                return NotFound();

            // Resim işleme
            if (resimDosyasi != null && resimDosyasi.Length > 0)
            {
                // Dosya boyutu kontrolü
                if (resimDosyasi.Length > 5 * 1024 * 1024)
                {
                    ModelState.AddModelError("ResimDosyasi", "Dosya boyutu 5 MB'dan büyük olamaz.");
                    ViewBag.Kategoriler = new SelectList(_kategoriServis.TumunuGetir(), "Id", "Ad", urun.KategoriID);
                    ViewBag.Markalar = new SelectList(_markaServis.TumunuGetir(), "Id", "Ad", urun.MarkaID);
                    return View(urun);
                }

                // Eski resmi sil
                if (!string.IsNullOrEmpty(mevcutUrun.ResimURL))
                {
                    var eskiResimYolu = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", mevcutUrun.ResimURL.TrimStart('/'));
                    if (System.IO.File.Exists(eskiResimYolu))
                    {
                        System.IO.File.Delete(eskiResimYolu);
                    }
                }

                // Yeni resmi kaydet
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "urunResimleri");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(resimDosyasi.FileName);
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    resimDosyasi.CopyTo(fileStream);
                }

                urun.ResimURL = "/urunResimleri/" + uniqueFileName;
            }
            else
            {
                // Resim yüklenmemişse mevcut resmi koru
                urun.ResimURL = mevcutUrun.ResimURL;
            }

            // Ürünü güncelle
            _urunServis.Guncelle(urun);
            TempData["Mesaj"] = "Ürün başarıyla güncellendi.";
            return RedirectToAction("Index");
        }

        // Model geçerli değilse
        ViewBag.Kategoriler = new SelectList(_kategoriServis.TumunuGetir(), "Id", "Ad", urun.KategoriID);
        ViewBag.Markalar = new SelectList(_markaServis.TumunuGetir(), "Id", "Ad", urun.MarkaID);
        return View(urun);
    }



    // Ürün Silme
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
            {
                System.IO.File.Delete(dosyaYolu);
                TempData["Mesaj"] = "Ürün ve resmi başarıyla silindi."; // Bilgilendirme mesajı
            }
        }

        _urunServis.Sil(urun);
        return RedirectToAction("Index");
    }

    // Test Ürün Ekleme
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

    // Test Ürün Güncelleme
    public IActionResult TestGuncelle()
    {
        // Güncellenmek istenen ürünün ID'sini alıyoruz
        int urunId = 1; // Veritabanında güncellemek istediğiniz ürünün ID'si

        // Ürünü getiriyoruz
        var mevcutUrun = _urunServis.GetirID(urunId);
        if (mevcutUrun == null)
        {
            return Content("Ürün bulunamadı!");
        }

        // Ürünü güncelliyoruz
        mevcutUrun.Ad = "Güncellenmiş Ürün";
        mevcutUrun.Fiyat = 150;

        // Ürünü güncelleme işlemi
        _urunServis.Guncelle(mevcutUrun);

        // Güncelleme başarılıysa mesaj döndürülür
        return Content($"Ürün başarıyla güncellendi: {mevcutUrun.Ad}, {mevcutUrun.Fiyat}");
    }
}
