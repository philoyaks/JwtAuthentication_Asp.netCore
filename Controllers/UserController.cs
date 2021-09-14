using Authentication_Authorization.Model;
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

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Register([FromBody] User user)
        {
            return Ok(new { user, "sjsj" });
        }



    }
}
