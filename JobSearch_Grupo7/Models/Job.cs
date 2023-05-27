using System.ComponentModel.DataAnnotations;
using System.Data;

namespace JobSearch_Grupo7.Models
{
    public class Job
    {
        [Key]
        public int jobId { get; set; }

        [Required]
        [MaxLength(100), MinLength(25)]
        public string? jobName { get; set; }

        [Required]
        public int jobTypeId { get; set; }

        [Required]
        public float jobSalary { get; set; }

        [Required]
        public int jobExperienceYear { get; set; }

        [Required]
        [MaxLength(1500), MinLength(200)]
        public string? jobDescription { get; set; }

        [Required]
        [MaxLength(1500), MinLength(100)]
        public string? jobRequirements { get; set; }

        [Required]
        public bool jobIsActive { get; set; }

        [Required]
        public DateTime jobPosted { get; set; }

        [Required]
        public DateTime jobExpiration { get; set; }

        [Required]
        public int cityId { get; set; }

        [Required]
        public int areaId { get; set; }

        [Required]
        public int companyId { get; set; }
    }
}
