using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BjertorpAPI.Models;
using BjertorpAPI.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BjertorpAPI.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly UserService _userService;

        public LoginController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<string> Login(LoginModel user)
        {
            return await _userService.Login(user);
        }

        [HttpDelete]
        public string Logout()
        {
            return "You are now logged out";
        }
    }
}
