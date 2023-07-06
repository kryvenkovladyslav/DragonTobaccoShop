using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using System;
using WebAPI.Infrastructure.Options;
using WebAPI.Models.DataTransferObjects.User;
using Domain.ApplicationModels;
using IdentitySystem.Infrastucture.Services.Interfaces;
using AutoMapper;
using WebAPI.Models.Responses.Messages;
using JWTAuthentification.Common.Services.Interfaces;
using JWTAuthentification.Common.Options;
using JWTAuthentification.Common.Data;
using Abstractions.Common;
using System.Linq;

namespace WebAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AuthenticationController : Controller
    {
        private readonly IUserRoleManager<User, Role, Guid> userRoleManager;
        private readonly IUserService<User, Guid> userService;
        private readonly IRoleService<Role, Guid> roleService;
        private readonly IJWTAuthenticationOptions jwtOptions;
        private readonly ITokenGenerator tokenGenerator;
        private readonly IMapper mapper;

        public AuthenticationController(
            IUserRoleManager<User, Role, Guid> userRoleManager,
            IUserService<User, Guid> userService,
            IRoleService<Role, Guid> roleService,
            ITokenGenerator tokenGenerator,
            IOptions<JWTOptions> jwtOptions,
            IMapper mapper)
        {
            this.userRoleManager = userRoleManager;
            this.tokenGenerator = tokenGenerator;
            this.jwtOptions = jwtOptions.Value;
            this.userService = userService;
            this.roleService = roleService;
            this.mapper = mapper;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Register([FromBody] RegistrationUserDTO registrationUserDTO)
        {
            if (registrationUserDTO == null)
            {
                return BadRequest(new InvalidObjectResponse());
            }

            var mappedUser = mapper.Map<User>(registrationUserDTO);
            mappedUser.WishList = new WishList();
            mappedUser.CartSessions = new List<CartSession> { new CartSession() };
            var result = await userService.CreateNewUserAsync(mappedUser, registrationUserDTO.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            var createdUser = await userService.FindUserByNamelAsync(mappedUser.UserName);
            var defaultRole = await roleService.FindByNameAsync(nameof(ApplicationRoles.User));
            await userRoleManager.AddUserToRoleAsync(createdUser, defaultRole);

            return result.Succeeded ? 
                Created("~/api/authentication", new UserCreatedResponse()) : BadRequest(result.Errors);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Login([FromBody] LoginUserDTO loginUserDTO)
        {
            var user = await userService.FindUserByNamelAsync(loginUserDTO.UserName);

            if (user == null)
            {
                return BadRequest(new InvalidUserNameResponse());
            }

            if (await userService.CheckPasswordAsync(user, loginUserDTO.Password))
            {
                var roleClaims = (await userRoleManager.GetAllRolesNameForUserAsync(user))
                    .Select(r => new Claim(ClaimTypes.Role, r));

                var authenticationClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };
                authenticationClaims.AddRange(roleClaims);

                var token = tokenGenerator.GenerateToken(jwtOptions, authenticationClaims, DateTime.Now.AddHours(24));

                return Ok(new JWTToken
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    Expiration = token.ValidTo
                });
            }

            return BadRequest(new InvalidPasswordResponse());
        }
    }
}