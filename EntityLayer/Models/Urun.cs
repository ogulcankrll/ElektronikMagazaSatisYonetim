using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Models
{
    public class Urun:BaseEntity
    {
        public string Ad { get; set; }
        public int KategoriID { get; set; }
        public int MarkaID { get; set; }
        public decimal Fiyat { get; set; }
        public string? ResimURL { get; set; }


        public Kategori Kategori { get; set; }
        public Marka Marka { get; set; }
        public List<UrunVaryasyon> UrunVaryasyonlari { get; set; }
      
    }
}
