using System.Net;
using Microsoft.Extensions.Logging;

namespace AA.Domain.Exceptions;

public abstract class DomainException : Exception
{
    public abstract string PublicMessage { get; }
    public abstract string PrivateMessage { get; }
    public abstract LogLevel LogLevel { get; }
    public abstract HttpStatusCode StatusCode { get; }
}