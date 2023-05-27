using System.ComponentModel.DataAnnotations;

namespace JobSearch_Grupo7.Models
{
    public class City
    {
        [Key]
        public int cityId { get; set; }

        [Required]
        [MaxLength(50), MinLength(1)]
        public string? cityName { get; set; }

        [Required]
        [MaxLength(15), MinLength(5)]
        public string? department { get; set; }

        [Required]
        [MaxLength(15), MinLength(10)]
        public string? zone { get; set; }
    }
}
