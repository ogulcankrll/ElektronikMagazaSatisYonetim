using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Models
{
    public class Favori:BaseEntity
    {
        public int MusteriID { get; set; }
        public int UrunID { get; set; }

        public Musteri Musteri { get; set; }
        public Urun Urun { get; set; }
    }
}
