using System;
using Microsoft.AspNetCore.Mvc;
using Skeleton.Domain.Models.Users;
using Skeleton.Domain.Services.AuthServices.Abstractions;
using Skeleton.Domain.Services.Core;

namespace Skeleton.Api.Controllers
{
    [ApiController, Route("users")]
    public class UserController: ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }
        
        [HttpPost]
        public IActionResult Post([FromBody] User question)
        {
            try
            {
                _service.InsertAsync(question);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}