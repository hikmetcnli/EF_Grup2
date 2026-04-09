

using System.ComponentModel.DataAnnotations;

namespace EF_Grup2.Models
{
    public class Arac
    {
        [Key]
        public int Id { get; set; }
        public int ModelYili { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Marka { get; set; }

        [Required]
        [StringLength(20)]
        public string Plaka { get; set; }

        public decimal Fiyat { get; set; }

        public string ResimYolu { get; set; }
    }
}
