namespace Application.Exceptions;

public class ProjectException : Exception
{
    public ProjectException(Guid id) : base($"Project with ID {id} was not found.")
    {
    }
}