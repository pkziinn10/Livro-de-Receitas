using FluentValidation;
using MyRecipeBook.Exceptions;
using MyRecipeBook.Communication.Request;

namespace MyRecipeBook.Application.UseCases.User.Register;

public class RegisterUserValidation : AbstractValidator<RequestRegisterUserJson>
{
    public RegisterUserValidation()
    {
        RuleFor(user => user.Name).NotEmpty().WithMessage(ResourceMessageException.NAME_EMPTY);
        RuleFor(user => user.Email).NotEmpty().WithMessage(ResourceMessageException.EMAIL_EMPTY);
        RuleFor(user => user.Email).EmailAddress().WithMessage(ResourceMessageException.EMAIL_INVALID);
        RuleFor(user => user.Password.Length).GreaterThanOrEqualTo(6).WithMessage(ResourceMessageException.PASSWORD_EMPTY);
    }
}