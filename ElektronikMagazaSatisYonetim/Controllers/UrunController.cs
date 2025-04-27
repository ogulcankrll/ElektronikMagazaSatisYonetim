using BusinessLayer.Abstract;
using EntityLayer.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;

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
    public IActionResult UrunEkle(Urun urun, IFormFile file)
    {
        if (ModelState.IsValid)
        {
            if (file != null && file.Length > 0)
            {
               
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/urunResimleri", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                urun.ResimURL = "/urunResimleri/" + fileName;
            }

            _urunServis.Ekle(urun);
            
            return RedirectToAction("Index");
        }

        ViewBag.Kategoriler = new SelectList(_kategoriServis.TumunuGetir(), "Id", "Ad");
        ViewBag.Markalar = new SelectList(_markaServis.TumunuGetir(), "Id", "Ad");
        return View(urun);
    }
}
