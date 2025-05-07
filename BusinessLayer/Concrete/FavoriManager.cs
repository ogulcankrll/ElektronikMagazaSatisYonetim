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
    public class FavoriManager : IFavoriServis
    {
        private readonly IFavoriDAL _favoriDAL;

        public FavoriManager(IFavoriDAL favoriDAL)
        {
            _favoriDAL = favoriDAL;
        }

        public void Ekle(Favori t)
        {
            _favoriDAL.Ekle(t);
        }

        public Favori GetirID(int id)
        {
            return _favoriDAL.GetirID(id);
        }

        public void Guncelle(Favori t)
        {
            _favoriDAL.Guncelle(t);
        }

        public void Sil(Favori t)
        {
            _favoriDAL.Sil(t);
        }

        public List<Favori> TumunuGetir()
        {
            return _favoriDAL.TumunuGetir();
        }

        public List<Favori> MusterininFavorileri(int musteriId)
        {
            return _favoriDAL.MusterininFavorileri(musteriId);
        }

        public bool FavoriVarMi(int musteriId, int urunId)
        {
            return _favoriDAL.FavoriVarMi(musteriId, urunId);
        }
    }
}
