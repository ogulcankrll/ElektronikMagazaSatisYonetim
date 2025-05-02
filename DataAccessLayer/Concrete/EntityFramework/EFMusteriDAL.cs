using DataAccessLayer.Abstcart;
using DataAccessLayer.Concrete.Repository;
using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EFMusteriDAL:GenericRepository<Musteri>,IMusteriDAL
    {
    }
}
