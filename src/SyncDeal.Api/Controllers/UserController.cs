using Microsoft.AspNetCore.Mvc;
using SyncDeal.Application.UseCases.User.Register;
using SyncDeal.Communication.Requests;
using SyncDeal.Communication.Responses;

namespace SyncDeal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseErrorDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseUserDTO), StatusCodes.Status201Created)]
        public async Task<IActionResult> RegisterUser(
            [FromServices] IRegisterUseCase useCase,
            [FromBody] RequestRegisterUserDTO request
            )
        {
            var response = await useCase.Execute(request);

            return Created(string.Empty, response);
        }
    }
}
