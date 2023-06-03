using System.ComponentModel.DataAnnotations;

namespace JobSearch_Grupo7.Models
{
    public class JobComment
    {
        [Key]
        public int jobCommentId { get; set; }

        [Required]
        public string? jobComment { get; set; }

        [Required]
        public DateTime jobCommentTimeStamp { get; set; }

        [Required]
        public int employeeId { get; set;}

        [Required]
        public int jobId { get; set; }

        [Required]
        public bool jobCommentAnom { get; set; }
    }
}
