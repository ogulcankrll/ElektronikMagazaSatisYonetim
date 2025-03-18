using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Models
{
    public class Marka:BaseEntity
    {
        public string Ad { get; set; }
        public List<Urun> Urunler { get; set; }
    }
}
