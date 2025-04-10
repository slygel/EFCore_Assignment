namespace Application.DTOs.Responses;

public class EmployeeSalaryDto
{
    public Guid EmployeeId { get; set; }
    public string EmployeeName { get; set; }
    public DateTime JoinedDate { get; set; }
    public decimal Salary { get; set; }
}