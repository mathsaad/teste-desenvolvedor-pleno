using FluentValidation;
using MediatR;
using Products.Contracts.Errors;
using Products.Contracts.Exceptions;

namespace Products.Application.Behaviors;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request), "O comando recebido é nulo.");
        }

        var context = new ValidationContext<TRequest>(request);
        
        var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
        
        var failures = validationResults.Where( x => !x.IsValid)
            .SelectMany(x => x.Errors)
            .Select(x => new ValidationError
            {
                Property = x.PropertyName,
                ErrorMessage = x.ErrorMessage
            }).ToList();

        if (failures.Any())
        {
            throw new CustomValidationException(failures);         
        }
        
        var response = await next();
        return response;
    }
}