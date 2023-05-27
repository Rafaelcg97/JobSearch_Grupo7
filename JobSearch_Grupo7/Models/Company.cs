using System.ComponentModel.DataAnnotations;

namespace JobSearch_Grupo7.Models
{
    public class Company
    {
        [Key]
        public int companyId { get; set; }

        [Required]
        [MaxLength(50), MinLength(1)]
        public string? companyName { get; set; }

        [Required]
        [MaxLength(1000), MinLength(100)]
        public string? companyDescription { get; set; }

        [Required]
        [MaxLength(500), MinLength(10)]
        public string? companyDirection { get; set; }

        [Required]
        [StringLength(9)]
        public string? companyPhone1 { get; set; }

        [StringLength(9)]
        public string? companyPhone2 { get; set; }

        [MaxLength(50), MinLength(6)]
        public string? companyEmail { get; set; }

        [MaxLength(200), MinLength(6)]
        public string? companyLinkedIn { get; set; }


        public byte[]? companyPicture { get; set; }
    }
}
