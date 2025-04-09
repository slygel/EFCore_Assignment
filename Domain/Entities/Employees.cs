namespace Domain.Entities;

public class Employees
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required DateTime JoinedDate { get; set; }
    public Guid DepartmentId { get; set; }
    
    public Departments Department { get; set; }
    public Salaries Salary { get; set; }
    public ICollection<ProjectEmployee> ProjectEmployees { get; set; }
}