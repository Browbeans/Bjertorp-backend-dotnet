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
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }


        [HttpGet]
        public async Task<List<User>> Get()
        {
            var users = await _userService.GetAsync();
            return users;
        }

        [HttpPost]
        public async Task<string> CreateUser(User user)
        {
            return await _userService.CreateUser(user);
        }

        [HttpDelete("{id}")]
        public async Task<string> DeleteUser(string id)
        {
            return await _userService.DeleteUser(id);
        }
    }
}
