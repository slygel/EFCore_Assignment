using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Requests;

public class DepartmentRequestDto
{ 
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }
}