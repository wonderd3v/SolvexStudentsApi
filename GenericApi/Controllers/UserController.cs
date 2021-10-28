﻿using GenericApi.Bl.Dto;
using GenericApi.Model.Entities;
using GenericApi.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GenericApi.Controllers
{
    public class UserController : BaseController<User, StudentDto>
    {
        private readonly IUserService _userService;

        public UserController(IUserService service) : base(service)
        {
            _userService = service;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(AuthenticateRequestDto model)
        {
            var response = await _userService.GetToken(model);

            if (response is null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

        [HttpPost("changePassword/{userId}")]
        public async Task<IActionResult> ChangePassword([FromRoute] int userId,[FromBody] ChangePasswordDto model)
        {
            var response = await _userService.ChangePassword(userId, model);

            if (response.IsSuccess is false)
                return BadRequest(response);

            return Ok(response);
        }
    }
}
