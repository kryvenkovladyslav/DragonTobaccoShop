using Abstractions.BusinessLayer.Services;
using Abstractions.Common;
using Abstractions.Models;
using AutoMapper;
using Domain.ApplicationModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Infrastructure.Attributes;
using WebAPI.Models.DataTransferObjects.Product;
using WebAPI.Models.Responses.Messages;

namespace WebAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CheckedProductController : Controller
    {
        private readonly ICheckedProductService checkedProductService;
        private readonly IMapper mapper;

        public CheckedProductController(ICheckedProductService checkedProductService, IMapper mapper)
        {
            this.checkedProductService = checkedProductService;
            this.mapper = mapper;
        }

        [HttpPost]
        [AuthorizeRole(ApplicationRoles.User, ApplicationRoles.Moderator, ApplicationRoles.Administrator)]
        public async Task<ActionResult> CreateCheckedProduct([FromBody] CheckedProductCreationDTO checkedProductCreationDTO)
        {
            if (checkedProductCreationDTO == null)
            {
                return BadRequest(new InvalidObjectResponse());
            }

            var mappedProduct = mapper.Map<CheckedProduct>(checkedProductCreationDTO);

            await checkedProductService.CreateCheckedProductAsync(mappedProduct);

            return Created("~/api/product", "created");
        }

        [HttpGet("{userID}")]
        [AuthorizeRole(ApplicationRoles.User, ApplicationRoles.Moderator, ApplicationRoles.Administrator)]
        public async Task<ActionResult<ICollection<CheckedProductDTO>>> GetAllCheckedProductsForUser(Guid userID)
        {
            var checkedProducts = await checkedProductService.GetAllCheckedProductsForUserAsync(userID);

            var mappedProducts = mapper.Map<ICollection<CheckedProductDTO>>(checkedProducts);

            return Ok(mappedProducts);
        }
    }
}
