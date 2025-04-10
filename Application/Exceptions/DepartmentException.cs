namespace Application.Exceptions;

public class DepartmentException : Exception
{
    public DepartmentException(Guid id)
        : base($"Department with ID {id} was not found.")
    {
    }
}