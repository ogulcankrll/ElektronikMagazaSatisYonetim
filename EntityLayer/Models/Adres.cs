using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Models
{
    public class Adres:BaseEntity
    {
        public int MusteriID { get; set; }
        public string AdresSatiri { get; set; }
        public string Sehir { get; set; }
        public string PostaKodu { get; set; }

        public Musteri Musteri { get; set; }

    }
}
