using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime EklenmeTarihi { get; set; }
        public DateTime? SilinmeTarihi { get; set; }
        public DateTime? GuncellenmeTarihi { get; set; }
       
    }
}
