using System.ComponentModel.DataAnnotations;

namespace JobSearch_Grupo7.Models
{
    public class sources_pages
    {
        [Key]
        public int id_source { get; set; }
        [Required]
        public string? linksToSource { get; set;}
        [Required]
        public string? advice_day { get;set; }
        [Required]
        public string? contact { get; set; }
        [Required]
        public string? mail { get; set; }
    }
}
