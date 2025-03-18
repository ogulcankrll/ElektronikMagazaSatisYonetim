using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Models
{
    public class UrunResim:BaseEntity
    {
        public int UrunID { get; set; }
        public string ResimURL { get; set; }

        public Urun Urun { get; set; }
    }
}
