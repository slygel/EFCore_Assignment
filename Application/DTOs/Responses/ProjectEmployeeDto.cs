namespace Application.DTOs.Responses;

public class ProjectEmployeeDto
{
    public Guid ProjectId { get; set; }
    public Guid EmployeeId { get; set; }
    public bool Enable { get; set; }
}