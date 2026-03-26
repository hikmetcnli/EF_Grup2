using System.ComponentModel.DataAnnotations;

namespace EF_Grup2.Models
{
    public class Musteri
    {
        [Key]
        public int Id { get; set; }
        public string ?Adi { get; set; }
        public string ?Soyadi { get; set; }
        public string ?Adres { get; set; }
        public string ?Telefon { get; set; }
    }
}
