using ECommerce.BLL.Dtos.AccountDtos;
using ECommerce.BLL.Services.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {

        
        private readonly IAccountServices _accountServices;

        public AccountsController(IAccountServices accountServices )
        {
          
            _accountServices = accountServices;
        }



        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(AccountRegisterDto registerDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountServices
                    .Register(registerDto);
                if (result == null)
                {
                    return BadRequest(result);
                }

                return Ok(result);
            }
            return BadRequest();

        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(AccountLoginDto loginDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountServices.Login(loginDto);
                if (result == null)
                {
                    return Unauthorized();
                }

                return Ok(result);
            }
            return BadRequest();
        }
    }
}
