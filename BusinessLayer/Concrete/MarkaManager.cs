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
    public class MarkaManager : IMarkaServis
    {
        private readonly IMarkaDAL _markaDAL;

        public MarkaManager(IMarkaDAL markaDAL)
        {
            _markaDAL = markaDAL;
        }

        public void Ekle(Marka t)
        {
           _markaDAL.Ekle(t);   
        }

       

        public Marka GetirID(int id)
        {
           return _markaDAL.GetirID(id);    
        }

        public void Guncelle(Marka t)
        {
          _markaDAL.Guncelle(t);    
        }

        public void Sil(Marka t)
        {
           _markaDAL.Sil(t);    
        }

        public List<Marka> TumunuGetir()
        {
            return _markaDAL.TumunuGetir();
        }
    }
}
