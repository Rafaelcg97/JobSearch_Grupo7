using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using static System.Net.Mime.MediaTypeNames;

namespace JobSearch_Grupo7.Models
{
    public class InterfaceObject
    {
        [Key]
        public int objectId { get; set; }
        public string? objectName { get; set; }
        public string? objectContentText { get; set; } 
        public byte[]? objectContentImage { get; set; }
    }
}
