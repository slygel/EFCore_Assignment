using Domain.Entities;

namespace Application.DTOs.Responses;

public class EmployeeProjectDto
{
    public Guid EmployeeId { get; set; }
    public string EmployeeName { get; set; }
    public DateTime JoinedDate { get; set; }
    public List<ProjectInfo> Projects { get; set; } = new List<ProjectInfo>();
}