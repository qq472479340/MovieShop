using ApplicationCore.Models;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterRequestModel model)
        {
            var user = await _userService.RegisterUser(model);
            return Ok(user);
        }

        [Route("Login") ]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequestModel model)
        {
            var userLoginResponseModel = await _userService.Login(model);
            return Ok(userLoginResponseModel);
        }

        [Route("{id:int}")]
        [HttpGet]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);
            if(user == null)
            {
                return NotFound($"No User Found For Id = {id}");
            }
            return Ok(user);
        }

    }
}
