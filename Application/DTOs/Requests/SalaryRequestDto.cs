using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Requests;

public class SalaryRequestDto
{
    [Required]
    public Guid EmployeeId { get; set; }
    [Required]
    public decimal Salary { get; set; }
}