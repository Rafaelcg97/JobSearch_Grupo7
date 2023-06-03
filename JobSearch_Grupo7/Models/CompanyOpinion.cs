using System.ComponentModel.DataAnnotations;

namespace JobSearch_Grupo7.Models
{
    public class CompanyOpinion
    {
        [Key]
        public int companyOpinionId { get; set; }

        [Required]
        public string? companyOpinion { get; set; }

        public DateTime companyOpinionTimeStamp { get; set; }

        public int employeeId { get; set; }

        public int companyId { get; set; }

        public bool companyOpinionAnom { get; set;}
    }
}
