using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Models
{
    public class Sepet : BaseEntity
    {
        public int MusteriID { get; set; }
        public Musteri Musteri { get; set; }

        public List<SepetUrun> SepetUrunler { get; set; }
    }
}
