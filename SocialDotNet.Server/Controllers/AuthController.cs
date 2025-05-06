using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialDotNet.Application.Authentication.Commands.Register;
using SocialDotNet.Application.Authentication.Commands.RevokeToken;
using SocialDotNet.Application.Authentication.Commands.UpdateRefreshToken;
using SocialDotNet.Application.Authentication.Common;
using SocialDotNet.Application.Authentication.Queries.Login;
using SocialDotNet.Contracts.Authentication;
using SocialDotNet.Domain.Common.Errors;

namespace SocialDotNet.Server.Controllers
{
    [Route("api/auth")]
    public class AuthController : ApiController
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public AuthController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var command = _mapper.Map<RegisterCommand>(request);
            ErrorOr<AuthenticationResult> authResult = await _mediator.Send(command);
            return authResult.Match(
                authResult => {
                    var response = _mapper.Map<AuthenticationResponse>(authResult);
                    SetTokenCookie(response.RefreshToken);  
                    return Ok(response);
                },
                errors => Problem(errors));
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var query = _mapper.Map<LoginQuery>(request);
            var authResult = await _mediator.Send(query);

            if (authResult.IsError && authResult.FirstError == Errors.Authentication.InvalidCredentials)
            {
                return Problem(
                    statusCode: StatusCodes.Status401Unauthorized,
                    title: authResult.FirstError.Description);
            }

            return authResult.Match(
                authResult => {
                    var response = _mapper.Map<AuthenticationResponse>(authResult);
                    SetTokenCookie(response.RefreshToken);
                    return Ok(response);
                },
                errors => Problem(errors));
        }

        [AllowAnonymous]
        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken()
        {
            var refreshToken = Request.Cookies["refreshToken"];
            var request = new RefreshTokenRequest(refreshToken);
            var command = _mapper.Map<UpdateRefreshTokenCommand>(request);
            var authResponse = await _mediator.Send(command);
            if (authResponse.IsError && authResponse.FirstError == Errors.Token.InvalidToken)
            {
                return Problem(
                    statusCode: StatusCodes.Status401Unauthorized,
                    title: authResponse.FirstError.Description);
            }
          
            return authResponse.Match(
                authResponse => {
                    var response = _mapper.Map<AuthenticationResponse>(authResponse);
                    SetTokenCookie(response.RefreshToken); 
                    return Ok(response); 
                },
                errors => Problem(errors));
        }

        [HttpGet("revoke-token")]
        public async Task<IActionResult> RevokeToken()
        {
            // accept refresh token in request body or cookie
            var token = Request.Cookies["refreshToken"];
            var request = new RevokeTokenRequest(token);
            var command = _mapper.Map<RevokeTokenCommand>(request);
            var response = await _mediator.Send(command);

            return response.Match(
                response => Ok(new { message = "Token revoked" }),
                errors => Problem(errors));
        }

        [HttpGet("ping-auth")]
        public IActionResult PingAuth()
        {
            return Ok();
        }

        [AllowAnonymous]
        [HttpGet("get-ip-address")]
        public IActionResult GetIpAddress()
        {
            // get source ip address for the current request
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
                return Ok(Request.Headers["X-Forwarded-For"].FirstOrDefault());
            else
                return Ok(HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString());
        }

        private void SetTokenCookie(string token)
        {
            // append cookie with refresh token to the http response
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(7)
            };
            Response.Cookies.Append("refreshToken", token, cookieOptions);
        }
    }
}