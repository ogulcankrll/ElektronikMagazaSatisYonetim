using BusinessLayer.Abstract;
using ElektronikMagazaSatisYonetim.Controllers;
using Microsoft.AspNetCore.Mvc;

public class AnaSayfaController : BaseController
{
    private readonly IUrunServis _urunServis;
    private readonly IMusteriServis _musteriServis;
    private readonly IPersonelServis _personelServis;
  

    public AnaSayfaController(IUrunServis urunServis, IMusteriServis musteriServis, IPersonelServis personelServis )
    {
        _urunServis = urunServis;
        _musteriServis = musteriServis;
        _personelServis = personelServis;
       
    }

    public IActionResult Index()
    {
        ViewBag.UrunSayisi = _urunServis.TumunuGetir().Count();
        ViewBag.MusteriSayisi = _musteriServis.TumunuGetir().Count();
        ViewBag.PersonelSayisi = _personelServis.TumunuGetir().Count();
       
        return View();
    }
}