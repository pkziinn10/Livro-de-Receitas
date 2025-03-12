using MyRecipeBook.Communication.Request;
using MyRecipeBook.Communication.Response;
using MyRecipeBook.Exceptions.ExceptionBase;

namespace MyRecipeBook.Application.UseCases.User.Register;

public class RegisterUserUseCase
{
    public ResponseRegisteredUserJson Execute(RequestRegisterUserJson request)
    {
        Validate(request);
            return new ResponseRegisteredUserJson
            {
                Name = request.Name,
            };
    }

    private void Validate(RequestRegisterUserJson request)
    {
       var validator = new RegisterUserValidation();
       
       var result = validator.Validate(request);

       if (result.IsValid == false)
       {
           var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();

           throw new ErrorOnValidationException(errorMessages);
       }
    }
}

/* string.Join(Environment.NewLine, errorMessages) */