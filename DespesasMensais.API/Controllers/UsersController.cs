using DespesasMensais.Library.Contracts;
using DespesasMensais.Library.Helpers;
using DespesasMensais.Library.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

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



        [HttpPost("register")]
        public IActionResult Register(UserAccount newUser)
        {
            var responseRegister = _userService.Register(newUser);

            if (responseRegister == null)
                return BadRequest(new { message = "Register failed" });
                       
            return Ok(responseRegister);
        }



 
        [HttpGet]
        [Authorize]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            var Id = User.Claims.First(claim => claim.Type == "Id").Value;
            return Ok(users);
        }
    }
}
