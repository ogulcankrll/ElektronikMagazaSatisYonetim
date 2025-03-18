using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Models
{
    public class SiparisUrun : BaseEntity
    {
        public int SiparisID { get; set; }
        public int UrunID { get; set; }
        public int Adet { get; set; }
        public decimal Fiyat { get; set; }

        public Siparis Siparis { get; set; }
    }
}
