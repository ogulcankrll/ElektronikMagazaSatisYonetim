using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Models
{
    public  class Musteri:BaseEntity
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Eposta { get; set; }
        public string Sifre { get; set; }
        public string Telefon { get; set; }

        public List<Adres> Adresler { get; set; }
        public List<Favori> Favoriler { get; set; }
        public List<Siparis> Siparisler { get; set; }
        public List<Yorum> Yorumlar { get; set; }


    }
}
