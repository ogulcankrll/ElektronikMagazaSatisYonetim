using BusinessLayer.Abstract;
using ElektronikMagazaSatisYonetim.Controllers;
using EntityLayer.Models;
using Microsoft.AspNetCore.Mvc;

public class MusteriGirisController : BaseController
{
    private readonly IMusteriServis _musteriServis;

    public MusteriGirisController(IMusteriServis musteriServis)
    {
        _musteriServis = musteriServis;
    }

    public IActionResult Giris()
    {
        if (HttpContext.Session.GetInt32("MusteriID") != null)
        {
            // Session'dan müşteri ad ve soyadını ViewBag'e aktarıyoruz
            ViewBag.MusteriAdSoyad = HttpContext.Session.GetString("MusteriAdSoyad");
            return RedirectToAction("Index", "Eticaret");
        }

        return View();
    }
    [HttpPost]
    public IActionResult Giris(string eposta, string sifre)
    {
        var musteri = _musteriServis.TumunuGetir()
            .FirstOrDefault(m => m.Eposta == eposta && m.Sifre == sifre);

        if (musteri != null)
        {
            // Kullanıcı bilgilerini session'a kaydet
            HttpContext.Session.SetInt32("MusteriID", musteri.Id);
            HttpContext.Session.SetString("MusteriAdSoyad", musteri.Ad + " " + musteri.Soyad);

            // Kullanıcı bilgilerini ViewBag'e aktar
            ViewBag.MusteriAdSoyad = musteri.Ad + " " + musteri.Soyad;

            // Giriş işlemi başarılıysa, ana sayfaya yönlendir
            return RedirectToAction("Index", "Eticaret");
        }

        // Hatalı giriş durumunda hata mesajı
        ViewBag.Hata = "E-posta veya şifre hatalı.";
        return View();
    }

    [HttpGet]
    public IActionResult Kayit()
    {
        if (HttpContext.Session.GetInt32("MusteriID") != null)
        {
            return RedirectToAction("Index", "Eticaret");
        }

        return View();
    }

    [HttpPost]
    public IActionResult Kayit(Musteri musteri)
    {
        var kontrol = _musteriServis.TumunuGetir().Any(x => x.Eposta == musteri.Eposta);
        if (kontrol)
        {
            ViewBag.Hata = "Bu e-posta ile daha önce kayıt olunmuş.";
            return View();
        }

        _musteriServis.Ekle(musteri);

        var yeniMusteri = _musteriServis.TumunuGetir()
            .FirstOrDefault(x => x.Eposta == musteri.Eposta);

        if (yeniMusteri != null)
        {
            HttpContext.Session.SetInt32("MusteriID", yeniMusteri.Id);
            HttpContext.Session.SetString("MusteriAdSoyad", yeniMusteri.Ad + " " + yeniMusteri.Soyad);

            ViewBag.MusteriAdSoyad = yeniMusteri.Ad + " " + yeniMusteri.Soyad;
        }

        return RedirectToAction("Index", "Eticaret");
    }

    public IActionResult Cikis()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Giris", "MusteriGiris");
    }
}
