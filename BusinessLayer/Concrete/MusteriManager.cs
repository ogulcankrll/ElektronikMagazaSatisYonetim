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
    public class MusteriManager:IMusteriServis
    {
        private readonly IMusteriDAL _musteriDAL;

        public MusteriManager(IMusteriDAL musteriDAL)
        {
            this._musteriDAL = musteriDAL;
        }

        public void Ekle(Musteri t)
        {
            _musteriDAL.Ekle(t);    
        }

        public Musteri GetirID(int id)
        {
           return _musteriDAL.GetirID(id);  
        }

        public void Guncelle(Musteri t)
        {
            _musteriDAL.Guncelle(t);    
        }

        public void Sil(Musteri t)
        {
           _musteriDAL.Sil(t);
        }

        public List<Musteri> TumunuGetir()
        {
            return _musteriDAL.TumunuGetir();   
        }
    }
}
