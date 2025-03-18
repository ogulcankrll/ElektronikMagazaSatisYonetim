using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Models
{
    public class UrunVaryasyon:BaseEntity
    {
        public int UrunID { get; set; }
        public string VaryasyonAdi { get; set; }
        public decimal EkFiyat { get; set; }

        public Urun Urun { get; set; }
    }
}
