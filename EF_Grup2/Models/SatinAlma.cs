using System.ComponentModel.DataAnnotations;

namespace EF_Grup2.Models
{
    public class SatinAlma
    {
        [Key]
        public int Id { get; set; }

        public int MusteriID { get; set; }
        public virtual Musteri musteri { get; set; }
        public int AracID { get; set; }
        public virtual Arac arac { get; set; }
        public decimal AlimFiyati { get; set; }
        public DateTime AlimTarihi { get; set; }

    }
}
