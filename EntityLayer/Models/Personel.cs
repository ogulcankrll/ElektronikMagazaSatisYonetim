using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Models
{
    public class Personel:BaseEntity
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Eposta { get; set; }
        public string Sifre { get; set; }
        public string Telefon { get; set; }
        public int RolID { get; set; }

        public Rol Rol { get; set; }  
        public PersonelDetay PersonelDetay { get; set; }
    }
}
