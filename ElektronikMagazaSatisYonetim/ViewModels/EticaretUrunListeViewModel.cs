using EntityLayer.Models;

namespace ElektronikMagazaSatisYonetim.ViewModels
{
    public class EticaretUrunListeViewModel
    {
        public List<Urun> Urunler { get; set; }
        public List<Kategori> Kategoriler { get; set; }
        public List<Marka> Markalar { get; set; }

        public int? KategoriId { get; set; }  // KategoriId filtresi
        public int? MarkaId { get; set; }     // MarkaId filtresi
        public decimal? MinFiyat { get; set; }
        public decimal? MaxFiyat { get; set; }
    }

}
