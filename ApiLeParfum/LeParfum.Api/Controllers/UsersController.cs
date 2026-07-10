using LeParfum.Application.DTOs;
using LeParfum.Application.Interfaces;
using LeParfum.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LeParfum.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost("registro")]
        public async Task<IActionResult> Register(UserDto userDto)
        {
            try
            {
                var result = await _userService.RegisterUserAsync(new UserEntity
                {
                    UserName = userDto.Name,
                    Password = userDto.Password
                });
                return Ok(result);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserDto userDto)
        {
            try
            {
                var result = await _userService.LoginUserAsync(new UserEntity
                {
                    UserName = userDto.Name,
                    Password = userDto.Password
                });
                return Ok(result!.UserName);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
    }
}