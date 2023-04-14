using Microsoft.AspNetCore.Mvc;
using Sat.Recruitment.Business.Dtos;
using Sat.Recruitment.Business.Services.Abstract;
using System;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser([FromBody] CreateUserDto createUserDto)
        {
            try
            {
                return Ok(await _userService.CreateUser(createUserDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);            
            }
        }

    }
}
