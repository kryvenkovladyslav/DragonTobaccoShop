using Abstractions.Common;
using AutoMapper;
using Domain.ApplicationModels;
using IdentitySystem.Infrastucture.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebAPI.Infrastructure.Attributes;
using WebAPI.Models.DataTransferObjects.User;
using WebAPI.Models.Responses.Messages;

namespace WebAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : Controller
    {
        private IUserService<User, Guid> userService;
        private IMapper mapper;

        public UserController(IUserService<User, Guid> userService, IMapper mapper) 
        {
            this.userService = userService;
            this.mapper = mapper;
        }

        [HttpGet("{userName}")]
        public async Task<ActionResult> GetUser(string userName)
        {
            var user = await userService.FindUserByNamelAsync(userName);

            if (user == null)
            {
                return BadRequest(new InvalidUserNameResponse());
            }

            return Ok(mapper.Map<UserDTO>(user));
        }
    }
}