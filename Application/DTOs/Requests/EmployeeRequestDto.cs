using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Requests;

public class EmployeeRequestDto
{
    [Required]
    public string Name { get; set; }
    
    [Required]
    public DateTime JoinedDate { get; set; }
    
    [Required]
    public Guid DepartmentId { get; set; }
}