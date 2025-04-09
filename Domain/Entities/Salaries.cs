namespace Domain.Entities;

public class Salaries
{
    public Guid Id { get; set; }
    public Guid EmployeeId { get; set; }
    public decimal Salary { get; set; }
    public Employees Employees { get; set; }
}