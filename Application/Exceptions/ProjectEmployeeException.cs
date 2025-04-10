namespace Application.Exceptions;

public class ProjectEmployeeException : Exception
{
    public ProjectEmployeeException(Guid projectId, Guid employeeId)
        : base($"ProjectEmployee with ProjectId {projectId} and EmployeeId {employeeId} was not found.")
    {
    }
}