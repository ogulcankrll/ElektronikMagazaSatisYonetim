using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Models
{
    public class SiparisDurumu:BaseEntity
    {
        public string DurumAdi { get; set; }
        public List<Siparis> Siparisler { get; set; }
    }
}
