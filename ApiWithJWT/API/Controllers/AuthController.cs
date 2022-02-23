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
        private IProductService productService;
        public AuthController(IAuthService authService,IProductService productService)
        {
            this.authService = authService;
            this.productService = productService;
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

        [HttpPost("productadd")]
        public IActionResult ProductAdd(ProductDTO productDTO)
        {
            var res = productService.AddProduct(productDTO);
            if (res)
            {
                return Ok("basarili");
            }
            return BadRequest("basarisiz");
        }
    }
}
