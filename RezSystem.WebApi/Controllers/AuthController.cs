using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RezSystem.Business.Operations.User;
using RezSystem.Business.Operations.User.Dtos;
using RezSystem.WebApi.Models;

namespace RezSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var addUserDto = new AddUserDto
            {
                Email = request.Email,
                Password = request.Password,
                FirstName = request.FirstName,
                LastName = request.LastName
            };


            var result = await _userService.AddUser(addUserDto);

            if(result.IsSuccess)
            {
                return Ok(new { message = result.Message });
            }
            else
            {
                return BadRequest(new { message = result.Message });
            }
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _userService.LoginUser(new LoginUserDto { Email = request.Email , Password=request.Password});

            if(!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok();

            

        }


    }
}
