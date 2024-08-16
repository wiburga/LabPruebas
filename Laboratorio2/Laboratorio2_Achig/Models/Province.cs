using System.ComponentModel.DataAnnotations;

namespace Laboratorio2.Models
{
    public class Province
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(2, MinimumLength = 2)]
        public string Code { get; set; }
    }
}
