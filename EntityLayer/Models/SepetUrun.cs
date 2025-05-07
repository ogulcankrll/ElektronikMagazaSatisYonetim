using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Models
{
    public class SepetUrun : BaseEntity
    {
        public int SepetID { get; set; }
        public int UrunID { get; set; }
        public int Adet { get; set; }
        public decimal Fiyat { get; set; } // O anda sepetteki fiyat (ürünün fiyatı değişirse sepet etkilenmesin diye)

        public Sepet Sepet { get; set; }
        public Urun Urun { get; set; }
    }

}
