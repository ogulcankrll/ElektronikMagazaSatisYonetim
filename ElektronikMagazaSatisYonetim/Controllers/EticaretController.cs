using BusinessLayer.Abstract;
using ElektronikMagazaSatisYonetim.Controllers;
using ElektronikMagazaSatisYonetim.ViewModels;
using Microsoft.AspNetCore.Mvc;

public class EticaretController : BaseController
{
    private readonly IUrunServis _urunServis;
    private readonly IKategoriServis _kategoriServis;
    private readonly IMarkaServis _markaServis;

    public EticaretController(IUrunServis urunServis, IKategoriServis kategoriServis, IMarkaServis markaServis)
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

    public IActionResult Detay(int id)
    {
        var urun = _urunServis.UrunleriKategoriVeMarkaIleGetir()
                              .FirstOrDefault(u => u.Id == id);

        if (urun == null)
            return NotFound();

        return View(urun);
    }
}
