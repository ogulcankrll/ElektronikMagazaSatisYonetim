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
    public class PersonelManager:IPersonelServis
    {
        private readonly IPersonelDAL _personelDAL;

        public PersonelManager(IPersonelDAL personelDAL)
        {
            _personelDAL = personelDAL;
        }

        public void Ekle(Personel t)
        {
           _personelDAL.Ekle(t);    
        }

        public Personel GetirID(int id)
        {
           
            return _personelDAL.GetirID(id);
        }

        public void Guncelle(Personel t)
        {
           _personelDAL.Guncelle(t);    
        }

        public void Sil(Personel t)
        {
          _personelDAL.Sil(t);      
        }

        public List<Personel> TumPersonelleriRolIleGetir()
        {
           return _personelDAL.TumunuRolIleGetir();
        }

        public List<Personel> TumunuGetir()
        {
            return _personelDAL.TumunuGetir();  
        }
    }
}
