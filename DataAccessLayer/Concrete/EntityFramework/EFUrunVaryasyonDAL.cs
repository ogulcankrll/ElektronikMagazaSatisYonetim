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
    public class EFUrunVaryasyonDAL : GenericRepository<UrunVaryasyon>, IUrunVaryasyonDAL
    {
        public List<UrunVaryasyon> TumVaryasyonlariUrunlerleGetir()
        {
            using (var context = new MyContext()) 
            {
                return context.UrunVaryasyon
                              .Include(x => x.Urun)
                              .ToList();
            }
        }
    }
}
