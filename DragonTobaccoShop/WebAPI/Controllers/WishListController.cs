using Abstractions.BusinessLayer.Services;
using Abstractions.Common;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebAPI.Infrastructure.Attributes;
using WebAPI.Models.Responses.Messages;

namespace WebAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class WishListController : Controller
    {
        private readonly IWishListService wishListService;
        private readonly IMapper mapper;

        public WishListController(IWishListService wishListService, IMapper mapper) 
        {
            this.wishListService = wishListService;
            this.mapper = mapper;
        }

        [HttpGet]
        [AuthorizeRole(ApplicationRoles.User, ApplicationRoles.Moderator, ApplicationRoles.Administrator)]
        public async Task<ActionResult> GetWishList(Guid wishListID) 
        {
            var wishList = wishListService.FindByIDAsync(wishListID);

            if(wishList == null)
            {
                return BadRequest(new InvalidObjectResponse());
            }

            var products = await wishListService.GetAllProductsAsync(wishListID);

            return Ok(products);
        }

        [HttpGet]
        [AuthorizeRole(ApplicationRoles.User, ApplicationRoles.Moderator, ApplicationRoles.Administrator)]
        public async Task<ActionResult> AddProduct(Guid wishListID)
        {
            var wishList = wishListService.FindByIDAsync(wishListID);

            if (wishList == null)
            {
                return BadRequest(new InvalidObjectResponse());
            }

            var products = await wishListService.GetAllProductsAsync(wishListID);

            return Ok(products);
        }


    }
}