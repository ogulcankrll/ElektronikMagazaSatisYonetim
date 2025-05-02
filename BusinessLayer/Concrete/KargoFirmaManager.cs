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
    public class KargoFirmaManager:IKargoFirmaServis
    {
        private readonly IKargoFirmaDAL _kargoFirmaDal;

        public KargoFirmaManager(IKargoFirmaDAL kargoFirmaDal)
        {
            _kargoFirmaDal = kargoFirmaDal;
        }

        public void Ekle(KargoFirma t)
        {
            _kargoFirmaDal.Ekle(t); 
        }

        public KargoFirma GetirID(int id)
        {
           return _kargoFirmaDal.GetirID(id);
        }

        public void Guncelle(KargoFirma t)
        {
           _kargoFirmaDal.Guncelle(t);
        }

        public void Sil(KargoFirma t)
        {
            _kargoFirmaDal.Sil(t);
        }

        public List<KargoFirma> TumunuGetir()
        {
         return  _kargoFirmaDal.TumunuGetir();
            
        }
    }
}
