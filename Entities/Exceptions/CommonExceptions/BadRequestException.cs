namespace Entities.Exceptions.CommonExceptions;

public abstract class BadRequestException : Exception
{
    protected BadRequestException(string message) : base(message) {}
}