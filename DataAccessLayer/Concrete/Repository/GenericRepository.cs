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
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;

        
        public GenericRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>(); 
        }

        public void Ekle(T entity)
        {
            _dbSet.Add(entity);  
            _context.SaveChanges();  
        }

        public T GetirID(int id)
        {
            return _dbSet.Find(id);  
        }

        public void Guncelle(T entity)
        {
            _dbSet.Update(entity);  
            _context.SaveChanges();  
        }

        public void Sil(T entity)
        {
            _dbSet.Remove(entity);  
            _context.SaveChanges();  
        }

        public List<T> TumunuGetir()
        {
            return _dbSet.ToList();  
        }
    }

}
