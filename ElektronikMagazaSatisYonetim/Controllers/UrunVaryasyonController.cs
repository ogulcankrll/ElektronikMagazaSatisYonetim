using BusinessLayer.Abstract;
using ElektronikMagazaSatisYonetim.Controllers;
using EntityLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

public class UrunVaryasyonController : BaseController
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
        var liste = _varyasyonServis.UrunVaryasyonlariUrunIleGetir();
        return View(liste);
    }

    
}
