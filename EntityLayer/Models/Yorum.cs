using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Models
{
        public class Yorum:BaseEntity
        {
            public int MusteriID { get; set; }
            public int UrunID { get; set; }
            public string Icerik { get; set; }
            public int Puan { get; set; }
            public DateTime YorumTarihi { get; set; }

            public Musteri Musteri { get; set; }
            public Urun Urun { get; set; }
        }
}
