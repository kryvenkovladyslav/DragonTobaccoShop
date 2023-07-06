using Abstractions.Common;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Domain.ApplicationModels;
using WebAPI.Infrastructure.Attributes;
using IdentitySystem.Infrastucture.Services.Interfaces;
using WebAPI.Models.Responses.Messages;
using System.Collections.Generic;
using WebAPI.Models.DataTransferObjects.User;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace WebAPI.Controllers
{
    [AuthorizeRole(ApplicationRoles.Administrator)]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class RoleController : Controller
    {
        private readonly IUserRoleManager<User, Role, Guid> userRoleManager;
        private readonly IUserService<User, Guid> userService;
        private readonly IRoleService<Role, Guid> roleService;

        public RoleController(
            IUserRoleManager<User, Role, Guid> userRoleManager, 
            IUserService<User, Guid> userService,
            IRoleService<Role, Guid> roleService)
        {
            this.userRoleManager = userRoleManager;
            this.userService = userService;
            this.roleService = roleService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Role>>> GetAllRolesAsync()
        {
            return Ok(await roleService.GetAllRolesAsync());
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Role>>> GetAllRoleForUserAsync()
        {
            return Ok(await roleService.GetAllRolesAsync());
        }


        [HttpPost("{roleName}")]
        public async Task<ActionResult> CreateRole(string roleName)
        {
            if(roleName == null)
            {
                return BadRequest(new InvalidRoleNameResponse());
            }

            var result = await roleService.CreateNewRoleAsync(new Role(roleName));
            
            return result.Succeeded ? Created("~/api/role", new RoleCreatedResponse()) : BadRequest(result.Errors);
        }

        [HttpPost("{roleName}")]
        public async Task<ActionResult> UpdateRole(string roleName)
        {
            if (roleName == null)
            {
                return BadRequest(new InvalidRoleNameResponse());
            }

            var result = await roleService.UpdateRoleAsync(new Role(roleName));

            return result.Succeeded ? Ok(new RoleUpdateResponse()) : BadRequest(result.Errors);
        }

        [HttpDelete("roleName")]
        public async Task<ActionResult> DeleteRole(string roleName)
        {
            if (roleName == null)
            {
                return BadRequest(new InvalidRoleNameResponse());
            }

            await roleService.DeleteRoleAsync(new Role(roleName));

            return Ok(new RoleDeletedResponse());
        }

        [HttpPost]
        public async Task<ActionResult> AddUserToRole([FromBody] UserRoleDTO userRole)
        {
            if (userRole == null)
            {
                return BadRequest(new InvalidRoleNameResponse());
            }

            var user = await userService.FindUserByNamelAsync(userRole.UserName);
            var role = await roleService.FindByNameAsync(userRole.RoleName);

            if (ValidateUserRole(user, role))
            {
                return BadRequest(new InvalidActionResponse());
            }

            var result = await userRoleManager.AddUserToRoleAsync(user, role);

            return  result.Succeeded ? Ok(new UserAddToRoleResponse(userRole.UserName, userRole.RoleName)): BadRequest(result.Errors);
        }

        [HttpPost]
        public async Task<ActionResult> DeleteUserFromRole([FromBody] UserRoleDTO userRole)
        {
            if (userRole == null)
            {
                return BadRequest(new InvalidRoleNameResponse());
            }

            var user = await userService.FindUserByNamelAsync(userRole.UserName);
            var role = await roleService.FindByNameAsync(userRole.RoleName);
            
            if(ValidateUserRole(user, role))
            {
                return BadRequest(new InvalidActionResponse());
            }

            var result = await userRoleManager.DeleteUserFromRoleAsync(user, role);

            return result.Succeeded ? Ok(new UserAddToRoleResponse(userRole.UserName, userRole.RoleName)) : BadRequest(result.Errors);
        }

        private bool ValidateUserRole(User user, Role role)
        {
            return user == null || role == null;
        }
    }
}