using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Models
{
    public class PersonelDetay:BaseEntity
    {
        public int PersonelID { get; set; }
        public string Soyad { get; set; }
        public string Eposta { get; set; }
        public string Sifre { get; set; }
        public string Telefon { get; set; }

        public Personel Personel { get; set; }


    }
}
