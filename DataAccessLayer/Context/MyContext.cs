using EntityLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Context
{
    public class MyContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-TMP3NRH;Database=DBElektronikMagaza;Integrated Security=True;Encrypt=False;");


        }

        public DbSet<Adres> Adres { get; set; }
        public DbSet<Favori> Favori { get; set; }
        public DbSet<KargoFirma> KargoFirma { get; set; }
        public DbSet<Kategori> Kategori { get; set; }
        public DbSet<Marka> Marka { get; set; }
        public DbSet<Musteri> Musteri { get; set; }
        public DbSet<Personel> Personel { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Siparis> Siparis { get; set; }
        public DbSet<SiparisDurumu> SiparisDurumu { get; set; }
        public DbSet<SiparisUrun> siparisUrun { get; set; }
        public DbSet<TeslimatTipi> TeslimatTipi { get; set; }
        public DbSet<Urun> Urun { get; set; }
        public DbSet<UrunVaryasyon> UrunVaryasyon { get; set; }
        public DbSet<Yorum> Yorum { get; set; }
        public DbSet<Sepet> Sepet { get; set; }
        public DbSet<SepetUrun> SepetUrun { get; set; }




    }
}
