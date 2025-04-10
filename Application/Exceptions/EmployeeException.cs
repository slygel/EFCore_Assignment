namespace Application.Exceptions;

public class EmployeeException : Exception
{
    public EmployeeException(Guid id) : base($"Employee with ID {id} was not found.")
    {
    }
}