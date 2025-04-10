using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Requests;

public class ProjectRequestDto
{
    [Required]
    public string Name { get; set; }
}