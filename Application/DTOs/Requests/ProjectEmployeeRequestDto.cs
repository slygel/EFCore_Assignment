using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Requests;

public class ProjectEmployeeRequestDto
{
    [Required]
    public Guid ProjectId { get; set; }
    
    [Required]
    public Guid EmployeeId { get; set; }
    public bool Enable { get; set; }
}