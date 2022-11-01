using System.Net;
using Microsoft.Extensions.Logging;

namespace AA.Domain.Exceptions;

public class SystemConfigurationException : DomainException
{
    public SystemConfigurationException(string privateMessage)
    {
        this.PrivateMessage = privateMessage;
    }

    public override string PublicMessage => "Unexpected Server Error";
    public override string PrivateMessage { get; }
    public override LogLevel LogLevel => LogLevel.Error;
    public override HttpStatusCode StatusCode => HttpStatusCode.InternalServerError;
}