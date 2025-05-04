using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IPersonelServis:IGenericService<Personel>
    {
        List<Personel> TumPersonelleriRolIleGetir();
    }
}
