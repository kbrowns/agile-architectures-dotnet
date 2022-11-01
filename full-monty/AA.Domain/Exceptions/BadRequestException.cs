using System.Net;
using FluentValidation.Results;
using Microsoft.Extensions.Logging;

namespace AA.Domain.Exceptions;

public class BadRequestException : DomainException
{
    public BadRequestException(string privateMessage)
    {
        this.PrivateMessage = privateMessage;
    }

    public BadRequestException(IEnumerable<ValidationFailure> validationResultErrors)
    {
        this.PrivateMessage = validationResultErrors.Select(x => $"{x.PropertyName}: {x.ErrorMessage}").ToJoinedString(Environment.NewLine);
    }

    public override string PublicMessage => "Bad Request";
    public override string PrivateMessage { get; }
    public override LogLevel LogLevel => LogLevel.Information;
    public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
}