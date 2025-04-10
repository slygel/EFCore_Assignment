namespace Application.DTOs.Requests;

public class ProjectEmployeeRequestDto
{
    public Guid ProjectId { get; set; }
    public Guid EmployeeId { get; set; }
    public bool Enable { get; set; }
}