using DataAccessLayer.Abstcart;
using DataAccessLayer.Concrete.Repository;
using DataAccessLayer.Context;
using EntityLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EFFavoriDAL : GenericRepository<Favori>, IFavoriDAL
    {
        public List<Favori> MusterininFavorileri(int musteriId)
        {
            using (var context = new MyContext())
            {
                return context.Favori
                              .Include(f => f.Urun)
                              .Where(f => f.MusteriID == musteriId)
                              .ToList();
            }
        }

        public bool FavoriVarMi(int musteriId, int urunId)
        {
            using (var context = new MyContext())
            {
                return context.Favori
                              .Any(f => f.MusteriID == musteriId && f.UrunID == urunId);
            }
        }
    }
}
