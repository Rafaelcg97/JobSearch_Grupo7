using System.ComponentModel.DataAnnotations;

namespace JobSearch_Grupo7.Models
{
    public class JobType
    {
        [Key]
        public int jobTypeId { get; set; }

        [Required]
        [MaxLength(50), MinLength(5)]
        public string? jobTypePrompt { get; set; }

        public string? jobTypeDescription { get; set; }

        [Required]
        public bool jobTypeIsActive { get; set; }
    }
}
