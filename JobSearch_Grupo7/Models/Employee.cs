using System.ComponentModel.DataAnnotations;

namespace JobSearch_Grupo7.Models
{
    public class Employee
    {
        public Employee(int employeeId, string? employeeName, string? employeeDescription, string? employeeEmail, string? employeePhone, string? employeeLinkedIn)
        {
            this.employeeId = employeeId;
            this.employeeName = employeeName;
            this.employeeDescription = employeeDescription;
            this.employeeEmail = employeeEmail;
            this.employeePhone = employeePhone;
            this.employeeLinkedIn = employeeLinkedIn;
        }

        [Key]
        public int employeeId { get; set; }
        public string? employeeName { get; set; }
        public string? employeeDescription { get; set; }
        public string? employeeEmail { get; set; }
        public string? employeePhone { get; set; }
        public string? employeeLinkedIn { get; set; }
        public byte[]? employeePicture { get; set; }
        public int userId { get; set; }
    }
}
