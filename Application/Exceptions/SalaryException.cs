namespace Application.Exceptions;

public class SalaryException : Exception
{
    public SalaryException(Guid id) : base($"Salary with ID {id} was not found.")
    {
    }
}