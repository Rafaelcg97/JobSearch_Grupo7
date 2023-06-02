using System.ComponentModel.DataAnnotations;

namespace JobSearch_Grupo7.Models
{
    public class Area
    {
        [Key]
        public int areaId { get; set; }

        [Required]
        public string? areaName { get; set; }

        public string? areaDescription { get; set; }
    }
}
