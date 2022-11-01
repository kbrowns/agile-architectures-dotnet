using System.Reflection;
using AA.Domain.Exceptions;
using AA.Domain.Services.Validation;
using FluentValidation.Results;
using Microsoft.Extensions.Logging;

namespace AA.Domain.Services;

public abstract class DomainService<TRequest, TResponse>
    where TRequest : class where TResponse : class
{

    private static readonly StaticLogger Logger = new StaticLogger(MethodBase.GetCurrentMethod()?.DeclaringType);
    
    public abstract TResponse Execute(TRequest request);

    public abstract IRequestValidator<TRequest> GetRequestValidator();

    public TResponse Run(TRequest request)
    {
        try
        {
            ValidateRequest(request);

            return Execute(request);
        }
        catch (DomainException ex)
        {
            // ReSharper disable once TemplateIsNotCompileTimeConstantProblem
            Logger.Log(ex.LogLevel, ex.PrivateMessage ?? "Unexpected error");

            throw;
        }
    }
    
    private void ValidateRequest(TRequest request)
    {
        IRequestValidator<TRequest> validator = GetRequestValidator();

        if (validator != null)
        {
            ValidationResult validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
            {
                throw new BadRequestException(validationResult.Errors);
            }
        }
    }
}