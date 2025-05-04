using BusinessLayer.Abstract;
using EntityLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElektronikMagazaSatisYonetim.Controllers
{
    public class RolController : BaseController
    {
        private readonly IGenericService<Rol> _rolService;

        public RolController(IGenericService<Rol> rolService)
        {
            _rolService = rolService;
        }

        public IActionResult Index()
        {
            var roller = _rolService.TumunuGetir();
            return View(roller);
        }

        public IActionResult RolEkle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RolEkle(Rol rol)
        {
            if (ModelState.IsValid)
            {
                _rolService.Ekle(rol);
                return RedirectToAction("Index");
            }
            return View(rol);
        }

        public IActionResult RolGuncelle(int id)
        {
            var rol = _rolService.GetirID(id);
            return rol == null ? NotFound() : View(rol);
        }

        [HttpPost]
        public IActionResult RolGuncelle(Rol rol)
        {
            if (ModelState.IsValid)
            {
                _rolService.Guncelle(rol);
                return RedirectToAction("Index");
            }
            return View(rol);
        }

        public IActionResult RolSil(int id)
        {
            var rol = _rolService.GetirID(id);
            if (rol == null) return NotFound();
            _rolService.Sil(rol);
            return RedirectToAction("Index");
        }
    }

}
