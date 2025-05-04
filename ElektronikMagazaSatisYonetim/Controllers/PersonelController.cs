using BusinessLayer.Abstract;
using EntityLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ElektronikMagazaSatisYonetim.Controllers
{
    public class PersonelController : BaseController
    {
        private readonly IPersonelServis _personelServis;
        private readonly IGenericService<Rol> _rolServis;

        public PersonelController(IPersonelServis personelServis, IGenericService<Rol> rolServis)
        {
            _personelServis = personelServis;
            _rolServis = rolServis;
        }

        
        public IActionResult Index()
        {
            var personeller = _personelServis.TumPersonelleriRolIleGetir(); 
            return View(personeller);
        }

    
        public IActionResult PersonelEkle()
        {
            ViewBag.Roller = new SelectList(_rolServis.TumunuGetir(), "Id", "RolAdi");
            return View();
        }

        [HttpPost]
        public IActionResult PersonelEkle(Personel personel)
        {
            if (ModelState.IsValid)
            {
                _personelServis.Ekle(personel);
                return RedirectToAction("Index");
            }

            ViewBag.Roller = new SelectList(_rolServis.TumunuGetir(), "Id", "RolAdi", personel.RolID);
            return View(personel);
        }


       
        public IActionResult PersonelGuncelle(int id)
        {
            var personel = _personelServis.GetirID(id);
            if (personel == null)
                return NotFound();

            ViewBag.Roller = new SelectList(_rolServis.TumunuGetir(), "Id", "RolAdi", personel.RolID);
            return View(personel);
        }

        [HttpPost]
        public IActionResult PersonelGuncelle(Personel personel)
        {
            if (ModelState.IsValid)
            {
                _personelServis.Guncelle(personel);
                return RedirectToAction("Index");
            }

            ViewBag.Roller = new SelectList(_rolServis.TumunuGetir(), "Id", "RolAdi", personel.RolID);
            return View(personel);
        }


        public IActionResult Sil(int id)
        {
            var personel = _personelServis.GetirID(id);  
            if (personel == null)
                return NotFound();  

            _personelServis.Sil(personel);  
            return RedirectToAction("Index");  
        }

    }
}

