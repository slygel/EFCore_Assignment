namespace Domain.Entities;

public class ProjectEmployee
{
    public Guid ProjectId { get; set; }
    public Guid EmployeeId { get; set; }
    public bool Enable { get; set; }
    public Employees Employee { get; set; }
    public Projects Projects { get; set; }
}