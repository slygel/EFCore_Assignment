namespace Domain.Entities;

public class Departments
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public ICollection<Employees> Employees { get; set; }

}