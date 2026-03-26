using System.ComponentModel.DataAnnotations;

namespace EF_Grup2.Models
{
    public class DepartmanList
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
