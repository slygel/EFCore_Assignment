namespace Application.DTOs.Responses;

public class SalaryDto
{
    public Guid Id { get; set; }
    public Guid EmployeeId { get; set; }
    public decimal Salary { get; set; }
}