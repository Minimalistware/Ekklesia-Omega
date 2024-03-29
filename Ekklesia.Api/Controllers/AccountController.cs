﻿using Ekkleisa.Business.Contract.IBusiness;
using Ekkleisa.Business.Implementation.Business;
using Ekklesia.Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ekklesia.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountBusiness _accountBusiness;

        public AccountController(IAccountBusiness accountBusiness)
        {
            _accountBusiness = accountBusiness;
        }

        [HttpPost("SignUp")]
        public async Task<ActionResult<Response>> SignUp(SignUpDTO Dto)
        {
            var response = await _accountBusiness.SignUp(Dto);
            if (response.success) return Ok(response);
            return BadRequest(response);
        }

        [HttpPost("SignIn")]
        public async Task<ActionResult<Response>> SignIn(SignInDTO Dto)
        {
            var response = await _accountBusiness.SignIn(Dto);
            if (response.success) return Ok(response);
            return BadRequest(response);
        }
    }
}
