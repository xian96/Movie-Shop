using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieShop.Core.Models.Request;
using MovieShop.Core.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.API.Controllers
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

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> UserInfo(int id)
        {
            var userRegisterResponse = await _userService.GetUserDetails(id);
            if (userRegisterResponse == null)
            {
                return NotFound("no user Found");
            }
            return Ok(userRegisterResponse);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser(UserRegisterRequestModel userRegisterRequest)
        {
            if (ModelState.IsValid)
            {
                //call the user Service
                var userRegisterResponse = await _userService.CreateUser(userRegisterRequest);
                //catch the exception 
                return Ok(userRegisterResponse);
            }

            return BadRequest(new { message = "please correct the input information" });
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginRequestModel loginRequest)
        {
            if (ModelState.IsValid)
            {
                //call the user Service
                var loginRespond = await _userService.ValidateUser(loginRequest.Email, loginRequest.Password);
                if(loginRespond == null)
                {
                    return BadRequest(new { message = "please correct the input information" });
                }
                return Ok(loginRespond);
            }

            return BadRequest(new { message = "please correct the input information" });
        }

    }
}
