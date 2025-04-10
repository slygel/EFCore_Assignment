namespace Application.DTOs.Responses;

public class EmployeeDepartmentDto
{
    public Guid EmployeeId { get; set; }
    public string EmployeeName { get; set; }
    public DateTime JoinedDate { get; set; }
    public string DepartmentName { get; set; }
}