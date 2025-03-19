using Microsoft.Extensions.Options;
using MyRecipeBook.Application.Services.AutoMapper;
using MyRecipeBook.Application.Services.Cryptography;
using MyRecipeBook.Communication.Request;
using MyRecipeBook.Communication.Response;
using MyRecipeBook.Exceptions.ExceptionBase;

namespace MyRecipeBook.Application.UseCases.User.Register;

public class RegisterUserUseCase
{
    public ResponseRegisteredUserJson Execute(RequestRegisterUserJson request)
    {
        var criptografiaDeSenha = new PasswordEncripter();
        
        var autoMapper = new AutoMapper.MapperConfiguration(options =>
            {
                options.AddProfile(new AutoMapping());
            }
        )
        .CreateMapper();
        
        Validate(request);
        
        var user = autoMapper.Map<Domain.Entities.User>(request);

        user.Password = criptografiaDeSenha.Encrypt(request.Password);

        return new ResponseRegisteredUserJson()
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