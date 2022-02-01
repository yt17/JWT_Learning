using BL.Abstracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class AuthController : Controller
    {
        private IAuthService authService;
        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }
        [HttpPost("Login")]
        public IActionResult Login(LoginDTO loginDTO)
        {
            var usertologin = authService.Login(loginDTO);
            if (usertologin.Code==0)
            {
                return BadRequest(usertologin.Message);
            }
            var result = authService.CreateAccessToken(usertologin.Data);
            if (result.Code==1)
            {
                return Ok(result.Data);
            }
            return BadRequest(usertologin.Message);
        }
        [HttpPost("register")]
        public IActionResult Register(RegisterDTO registerDTO)
        {
            var check = authService.UserExists(registerDTO.email);
            if (check.Code==1)
            {
                return BadRequest(check.Message);
            }
            var reg = authService.Register(registerDTO, registerDTO.Password);
            var result = authService.CreateAccessToken(reg.Data);
            if (result.Code==1)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [Authorize("test")]
        public IActionResult test()
        {
            return Ok();
        }
    }
}
