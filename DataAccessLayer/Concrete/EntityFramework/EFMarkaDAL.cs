using DataAccessLayer.Abstcart;
using DataAccessLayer.Concrete.Repository;
using EntityLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EFMarkaDAL: GenericRepository<Marka>, IMarkaDAL
    {
     
    }
}
