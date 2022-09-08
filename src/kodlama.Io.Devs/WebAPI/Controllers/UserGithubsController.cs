using Application.Features.UserGithubs.Commands.CreateUserGithub;
using Application.Features.UserGithubs.Commands.DeleteUserGithub;
using Application.Features.UserGithubs.Commands.UpdateUserGithub;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserGithubsController : BaseController
    {
        [HttpPost("Add")]
        public async Task<ActionResult> Add(CreateUserGithubCommand createUserGithubCommand,CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(createUserGithubCommand);
            return Ok(result);
        }
        [HttpPost("Update")]
        public async Task<ActionResult> Update(UpdateUserGithubCommand updateUserGithubCommand, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(updateUserGithubCommand);
            return Ok(result);
        }
        [HttpPost("Delete/{Id}")]
        public async Task<ActionResult> Update([FromRoute]DeleteUserGithubCommand deleteUserGithubCommand, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(deleteUserGithubCommand);
            return Ok(result);
        }
    }
}
