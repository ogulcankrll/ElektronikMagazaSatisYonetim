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
    public class UrunVaryasyonManager:IUrunVaryasyonServis
    {
        private readonly IUrunVaryasyonDAL _urunVaryasyonDAL;

        public UrunVaryasyonManager(IUrunVaryasyonDAL urunVaryasyonDAL)
        {
            this._urunVaryasyonDAL = urunVaryasyonDAL;
        }

        public void Ekle(UrunVaryasyon t)
        {
           _urunVaryasyonDAL.Ekle(t);
        }

        public UrunVaryasyon GetirID(int id)
        {
            return _urunVaryasyonDAL.GetirID(id);
        }

        public void Guncelle(UrunVaryasyon t)
        {
            _urunVaryasyonDAL.Guncelle(t);
        }

        public void Sil(UrunVaryasyon t)
        {
            _urunVaryasyonDAL.Sil(t);   
        }

        public List<UrunVaryasyon> TumunuGetir()
        {
         return _urunVaryasyonDAL.TumunuGetir();
        }

        public List<UrunVaryasyon> UrunVaryasyonlariUrunIleGetir()
        {
            return _urunVaryasyonDAL.TumVaryasyonlariUrunlerleGetir();
        }
    }
}
