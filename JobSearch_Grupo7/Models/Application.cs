using System.ComponentModel.DataAnnotations;

namespace JobSearch_Grupo7.Models
{
    public class Application
    {
        [Key]
        public int applicationId { get; set; }

        [Required]
        public int applicationStatusId { get; set;}

        [Required]
        public DateTime applicationDate { get; set; }

        [Required]
        public int jobId { get; set; }

        [Required]
        public int employeeId { get; set; }

        [Required]
        public int resumeId { get; set; }
    }
}
