using DespesasMensais.Library.Contracts;
using DespesasMensais.Library.Helpers;
using DespesasMensais.Library.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DespesasMensais.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }



        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }


        [HttpPost("register")]
        public IActionResult Register(UserAccount newUser)
        {
            var responseRegister = _userService.Register(newUser);

            if (responseRegister == null)
                return BadRequest(new { message = "Register failed" });

            var responseAuth = _userService.Authenticate(new AuthenticateRequest { Username = newUser.UserName, Password = newUser.Password });

            if(responseAuth == null)
                return BadRequest(new { message = "Register with success however an error occured while authentication." });

            return Ok(responseAuth);
        }



        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }
    }
}
