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
    public class EFPersonelDAL : GenericRepository<Personel>, IPersonelDAL
    {
        public List<Personel> TumunuRolIleGetir()
        {
            using (var context = new MyContext()) 
            {
                return context.Personel.Include(p => p.Rol).ToList();
            }
        }
    }
}
