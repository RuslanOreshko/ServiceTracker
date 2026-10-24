namespace ServiceTracker.Application.Exceptions;

public sealed class EmailAlredyExistsException : Exception
{
    public EmailAlredyExistsException() : base("A user with this email alredy exists.") {}
}