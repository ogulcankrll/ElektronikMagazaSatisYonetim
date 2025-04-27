using DataAccessLayer.Abstcart;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repository
{
    public class GenericRepository<T> : IGenericDal<T> where T : class, new()
    {
        public readonly DbContext _context;
        

        
        public GenericRepository()
        {
            _context = new Context.MyContext();
           
        }
        private void Kaydet()
        {
            _context.SaveChanges();
        }

        public void Ekle(T t)
        {
            _context.Add(t);
            Kaydet();

        }

        public T GetirID(int id)
        {
            return _context.Find<T>(id);
        }

        public void Guncelle(T t)
        {
            _context.Update(t);
            Kaydet();
        }

        public void Sil(T t)
        {
           _context.Remove(t);
            Kaydet();
        }

        public List<T> TumunuGetir()
        {
            return _context.Set<T>().ToList();
        }
    }

}
