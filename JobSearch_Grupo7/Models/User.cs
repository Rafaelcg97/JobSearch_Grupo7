using System.ComponentModel.DataAnnotations;

namespace JobSearch_Grupo7.Models
{
    public class User
    {
        [Key]
        public int idUser { get; set; }

        [Required]
        public string? emailUser { get; set; }

        [Required] 
        public string? passwordUser { get; set; }

    }
}
