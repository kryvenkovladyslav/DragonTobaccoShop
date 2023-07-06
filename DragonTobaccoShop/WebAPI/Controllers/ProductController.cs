using Abstractions.BusinessLayer.Services;
using Abstractions.Common;
using Abstractions.Models;
using AutoMapper;
using Domain.ApplicationModels;
using IdentitySystem.Infrastucture.Services.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Infrastructure.Attributes;
using WebAPI.Infrastructure.Mapping.UserMapping;
using WebAPI.Models.DataTransferObjects.Product;
using WebAPI.Models.DataTransferObjects.User;
using WebAPI.Models.Responses.Messages;

namespace WebAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly ICheckedProductService checkedProductService;
        private readonly IMapper mapper;

        public ProductController(
            IProductService productService,
            ICheckedProductService checkedProductService,
            IMapper mapper)
        {
            this.checkedProductService = checkedProductService;
            this.productService = productService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProducts()
        {
            var products = await productService.GetProductsAsync();

            return Ok(mapper.Map<IEnumerable<ProductDTO>>(products));
        }

        [HttpGet("{productID}")]
        public async Task<ActionResult<MainProduct>> GetProduct(Guid productID)
        {
            var product = await productService.GetProductAsync(productID);

            return Ok(mapper.Map<MainProduct>(product));
        }



        [HttpPost]
        [AuthorizeRole(ApplicationRoles.Moderator, ApplicationRoles.Administrator)]
        public async Task<ActionResult> CreateProduct([FromBody] ProductCreationDTO productCreation)
        {
            if(productCreation == null || productCreation.Tobacco == null)
            {
                return await Task.FromResult(BadRequest());
            }

            var createdProduct = productService.CreateNewProduct(mapper.Map<Product>(productCreation));

            return Created("~/api/product", createdProduct);
        }

       /* [HttpPost]
        [Authorize(Roles = nameof(ApplicationRoles.Moderator))]
        [Authorize(Roles = nameof(ApplicationRoles.Administrator))]
        public Task<ActionResult> UpldateProduct()
        {
            var product = await productService.GetProductByIDAsync(productID);
            await productService.DeleteProduct(product);
        }*/

        [HttpDelete("{productID}")]
        [AuthorizeRole(ApplicationRoles.Moderator, ApplicationRoles.Administrator)]
        public async Task DeleteProduct(Guid productID)
        {
            var product = await productService.GetProductByIDAsync(productID);
            await productService.DeleteProduct(product);
        }
    }
}