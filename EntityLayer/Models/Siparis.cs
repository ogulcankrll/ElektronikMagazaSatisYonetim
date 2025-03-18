using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Models
{
    public class Siparis:BaseEntity
    {
        public int MusteriID { get; set; }
        public decimal ToplamTutar { get; set; }
        public int DurumID { get; set; }
        public string TakipNumarasi { get; set; }
        public int TeslimatTuruID { get; set; }

        public Musteri Musteri { get; set; }
        public SiparisDurumu SiparisDurumu { get; set; }
        public TeslimatTipi TeslimatTuru { get; set; }
        public List<SiparisUrun> SiparisUrunler { get; set; }
    }
}
