using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Models
{
    public class Rol:BaseEntity
    {
        public string  RolAdi { get; set; }
        public List<Personel> Personeller { get; set; }
    }
}
