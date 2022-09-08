using Application.Features.Auths.Commands.RegisterCommand;
using Application.Features.Auths.Queries.LoginQuery;
using Application.Features.UserOperationClaims.Queries;
using Application.Features.Users.Queries;
using Core.Security.JWT;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : BaseController
    {
      ITokenHelper _tokenHelper;

        public AuthsController(ITokenHelper tokenHelper)
        {
            _tokenHelper = tokenHelper;
        }

        [HttpPost("Register")]
        public async Task<ActionResult> Register(RegisterCommand registerCommand)
        {
        
           
            
                var result = Mediator.Send(registerCommand);
                return Ok(result);
         
            
           
        }
        [HttpPost("Login")]
        public async Task<ActionResult> Login(LoginQuery loginQuery)
        {
            var result = Mediator.Send(loginQuery);

            if (result.Result!=null)
            {
                var claims = Mediator.Send(new GetListUserOperationClaimByUserIdQuery() { UserId = result.Result.Id });
                var user = await Mediator.Send(new GetUserByEmailQuery() { Email=result.Result.Email});
                var token = _tokenHelper.CreateToken(user,claims.Result.OperationClaim);
                return Ok(token);
            }
            return Ok();
        }

    }
}
