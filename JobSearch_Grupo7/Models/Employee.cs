using System.ComponentModel.DataAnnotations;

namespace JobSearch_Grupo7.Models
{
    public class Employee
    {
        [Key]
        public int employeeId { get; set; }
        public string? employeeName { get; set; }
        public string? employeeDescription { get; set; }
        public string? employeeEmail { get; set; }
        public string? employeePhone { get; set; }
        public string? employeeLinkedIn { get; set; }
        public byte[]? employeePicture { get; set; }
    }
}
