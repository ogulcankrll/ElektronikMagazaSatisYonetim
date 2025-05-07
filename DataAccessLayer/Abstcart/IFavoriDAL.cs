using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstcart
{
    public interface IFavoriDAL:IGenericDal<Favori>
    {
        List<Favori> MusterininFavorileri(int musteriId);
        bool FavoriVarMi(int musteriId, int urunId);
    }
}
