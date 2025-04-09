namespace Domain.Entities;

public class Projects
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public ICollection<ProjectEmployee> ProjectEmployees { get; set; }
}