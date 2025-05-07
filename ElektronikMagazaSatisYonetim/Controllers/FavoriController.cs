using BusinessLayer.Abstract;
using EntityLayer.Models;
using Microsoft.AspNetCore.Mvc;

public class FavoriController : Controller
{
    private readonly IFavoriServis _favoriServis;

    public FavoriController(IFavoriServis favoriServis)
    {
        _favoriServis = favoriServis;
    }

    public IActionResult Index(int musteriId)
    {
        var favoriler = _favoriServis.MusterininFavorileri(musteriId);
        return View(favoriler);
    }

    public IActionResult FavoriEkle(int urunId)
    {
        var musteriId = HttpContext.Session.GetInt32("MusteriID");

        if (musteriId == null)
        {
            TempData["Mesaj"] = "Lütfen giriş yapınız.";
            return RedirectToAction("Giris", "MusteriGiris");
        }

        if (_favoriServis.FavoriVarMi(musteriId.Value, urunId))
        {
            TempData["Mesaj"] = "Bu ürün zaten favorilerde.";
        }
        else
        {
            _favoriServis.Ekle(new Favori
            {
                MusteriID = musteriId.Value,
                UrunID = urunId
            });
            TempData["Mesaj"] = "Ürün favorilere eklendi.";
        }

        return RedirectToAction("Index", "Eticaret");
    }

    public IActionResult FavoriSil(int favoriId, int musteriId)
    {
        var favori = _favoriServis.GetirID(favoriId);
        if (favori == null)
            return NotFound();

        _favoriServis.Sil(favori);
        TempData["Mesaj"] = "Favoriden silindi.";
        return RedirectToAction("Index", new { musteriId });
    }
}
