using Microsoft.AspNetCore.Mvc;
using MyRecipeBook.Communicatio.Request;
using MyRecipeBook.Communicatio.Response;

namespace MyRecipeBook.Api.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisterUserJson), StatusCodes.Status201Created)]
        public IActionResult Register(RequestRegisterUserJson request)
        {
            return Created();
        }
    }
}
