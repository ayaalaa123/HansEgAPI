using HansEgAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HansEgAPI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IJwtAuthManager _jwtAuthManager;

        public LoginController(IJwtAuthManager jwtAuthManager)
        {
            _jwtAuthManager = jwtAuthManager;
        }


        [HttpPost("auth")]
        public IActionResult Auth([FromBody] LoginCred loginCred)
        {
            var token = _jwtAuthManager.Authenticate(loginCred.UserName, loginCred.Password);

            if (token == null)
                return Unauthorized();
            
            return Ok(token);
        }

    }
}
