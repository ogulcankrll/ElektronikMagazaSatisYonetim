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
    public class KategoriManager : IKategoriServis
    {
        private readonly IKategoriDAL _kategoriDAL;

        public KategoriManager(IKategoriDAL kategoriDAL)
        {
            _kategoriDAL = kategoriDAL;
        }

        public void Ekle(Kategori t)
        {
          _kategoriDAL.Ekle(t); 
        }

        public Kategori GetirID(int id)
        {
         return _kategoriDAL.GetirID(id);
        }

        public void Guncelle(Kategori t)
        {
            _kategoriDAL.Guncelle(t);   
        }

        public void Sil(Kategori t)
        {
            _kategoriDAL.Sil(t);
        }

        public List<Kategori> TumunuGetir()
        {
            return _kategoriDAL.TumunuGetir();
        }
    }
}
