using BusinessLayer.Abstract;
using DataAccessLayer.Abstcart;
using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class UrunManager:IUrunServis
    {
        private readonly IUrunDAL _urunDAL;

        public UrunManager(IUrunDAL urunDAL)
        {
            _urunDAL = urunDAL;
        }
        public void Ekle(Urun t)
        {
            _urunDAL.Ekle(t);
            
        }
        public Urun GetirID(int id)
        {
            return _urunDAL.GetirID(id);
        }
        public void Guncelle(Urun t)
        {
           _urunDAL.Guncelle(t);    
        }
        public void Sil(Urun t)
        {
            _urunDAL.Sil(t);    
        }
        public List<Urun> TumunuGetir()
        {
            return _urunDAL.TumunuGetir();
        }
        public List<Urun> UrunleriKategoriVeMarkaIleGetir()
        {
            return _urunDAL.UrunleriKategoriVeMarkaIleGetir();
        }
    }
}
