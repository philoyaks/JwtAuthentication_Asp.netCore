using Authentication_Authorization.Model;
using Authentication_Authorization.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication_Authorization.Controllers
{
    [ApiController]
    [Route("authenticate")]
    public class UserController : ControllerBase
    {
        private readonly IMockRepoService _repo;
        private readonly IAuthenticateService _auth;

        public UserController(IMockRepoService repo, IAuthenticateService auth)
        {
            _repo = repo;
            _auth = auth;
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(string username, string password)
        {
            var result = _repo.FindUser(username, password);
            if (result == null)
            {
                return NotFound("Invalid password");

            }
            var token = _auth.AuthenticateUser(result);

            return Ok(new
            {
                result,
                token
            });
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Register([FromBody] User user)
        {
            var result = _repo.CreateUser(user);

            if (result == null)
            {
                return BadRequest("Invalid password");

            }
            var token = _auth.AuthenticateUser(result);

            return Ok(new { result, token });
        }

        [HttpGet]
        [Route("logout")]
        public IActionResult Logout([FromBody] User user)
        {
            return Ok();
        }





    }
}
