using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstcart
{
    public interface IGenericDal<T> where T : class,new()
    {
        void Ekle(T t);
        void Sil(T t);  
        void Guncelle(T t);
        T GetirID(int id);
        List<T> TumunuGetir();
    }
}
