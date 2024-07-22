using DesafioDiaDoRock.ApplicationCore.DTO.UserDTO;
using DesafioDiaDoRock.ApplicationCore.Interfaces.Services;
using DesafioDiaDoRock.ApplicationCore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesafioDiaDoRock.PublicApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class UserController(IUserService userService) : ControllerBase
    {
        private readonly IUserService _userService = userService;


        [HttpPost ("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Create(RegisterDTO userDTO)
        {
            var response = await _userService.Create(userDTO);

            if (response.IsSuccess)
                return Ok(response);

            return StatusCode(response._code, response);
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginDTO userDTO)
        {
            var response = await _userService.Login(userDTO);

            if (response.IsSuccess)
                return Ok(response);

            return StatusCode(response._code, response);
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _userService.Get(id));
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            return Ok(await _userService.GetListUsers());
        }


    }
}
