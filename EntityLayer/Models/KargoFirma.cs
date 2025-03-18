using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Models
{
    public class KargoFirma : BaseEntity
    {
        public string FirmaAdi { get; set; }
        public List<Siparis> Siparisler { get; set; }
    }
}
