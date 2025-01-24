using Products.Contracts.Errors;

namespace Products.Contracts.Exceptions;

public class CustomValidationException : Exception
{
    public CustomValidationException(List<ValidationError> validationErrors)
    {
        ValidationErrors = validationErrors;
    }
    
    public List<ValidationError> ValidationErrors { get; set; }
}