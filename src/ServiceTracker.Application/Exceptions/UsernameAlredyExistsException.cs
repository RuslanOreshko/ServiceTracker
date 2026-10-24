namespace ServiceTracker.Application.Exceptions;

public sealed class UsernameAlredyExistsException : Exception
{
    public UsernameAlredyExistsException() : base("A user with username alredy exists") {}    
}