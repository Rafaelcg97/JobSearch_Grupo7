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

        public Company(int companyId, string? companyName, string? companyDescription, string? companyDirection, 
            string? companyPhone1, string? companyPhone2, string? companyEmail, string? companyLinkedIn, byte[]? companyPicture)
        {
            this.companyId = companyId;
            this.companyName = companyName;
            this.companyDescription = companyDescription;
            this.companyDirection = companyDirection;
            this.companyPhone1 = companyPhone1;
            this.companyPhone2 = companyPhone2;
            this.companyEmail = companyEmail;
            this.companyLinkedIn = companyLinkedIn;
            this.companyPicture = companyPicture;
        }
    }
}
