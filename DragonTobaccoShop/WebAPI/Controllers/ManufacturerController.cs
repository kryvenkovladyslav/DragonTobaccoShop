using Abstractions.BusinessLayer.Services;
using AutoMapper;
using Domain.ApplicationModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Models.DataTransferObjects.Manufacturer;
using WebAPI.Models.Responses.Messages;

namespace WebAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ManufacturerController : Controller
    {
        private readonly IManufacturerService<Manufacturer, Guid> manufacturerService;
        private readonly IMapper mapper;

        public ManufacturerController(IManufacturerService<Manufacturer, Guid> manufacturerService, IMapper mapper)
        {
            this.manufacturerService = manufacturerService;
            this.mapper = mapper;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<ManufacturerCreationDTO>> CreateNewManufacturer([FromBody] ManufacturerCreationDTO manufacturerDTO)
        {
            if (manufacturerDTO == null)
            {
                return BadRequest(new InvalidObjectResponse());
            }

            var mappedManufacturer = mapper.Map<Manufacturer>(manufacturerDTO);

            if (await manufacturerService.IsAlreadyExist(mappedManufacturer))
            {
                return BadRequest(new ModelAlreadyExistResponse(mappedManufacturer.Name, nameof(Manufacturer)));
            }

            await manufacturerService.CreateAsync(mappedManufacturer);

            return Created("~/api/manufacturer", new ManufacturerCreatedResponse());
        }

        [HttpPut]
        [AllowAnonymous]
        public async Task<ActionResult> UpdateManufacturer([FromBody] UpdateManufaturerDTO<Guid> manufacturerDTO)
        {
            if (manufacturerDTO == null)
            {
                return BadRequest(new InvalidObjectResponse());
            }

            var mappedManufacturer = mapper.Map<Manufacturer>(manufacturerDTO);

            if (await manufacturerService.IsAlreadyExist(mappedManufacturer))
            {
                return BadRequest(new ModelAlreadyExistResponse(mappedManufacturer.Name, nameof(Manufacturer)));
            }

            if (await manufacturerService.FirstOrDefaultAsync(m => m.ID == mappedManufacturer.ID) == null)
            {
                return BadRequest(new ModelNotExistResponse(nameof(Manufacturer)));
            }

            await manufacturerService.UpdateAsync(mappedManufacturer);

            return Ok(new ModelUpdatedResponse(nameof(Manufacturer)));
        }

        [HttpDelete]
        [AllowAnonymous]
        public async Task<ActionResult> DeleteManufacturer([FromBody] ManufacturerDTO<Guid> manufacturerDTO)
        {
            if (manufacturerDTO == null)
            {
                return BadRequest(new InvalidObjectResponse());
            }

            var mappedManufacturer = mapper.Map<Manufacturer>(manufacturerDTO);


            if (await manufacturerService.FirstOrDefaultAsync(m => m.ID == mappedManufacturer.ID) == null)
            {
                return BadRequest(new ModelNotExistResponse(nameof(Manufacturer)));
            }

            await manufacturerService.DeleteAsync(mappedManufacturer);

            return Ok(new ModelDeletedResponse(nameof(Manufacturer)));
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<ICollection<ManufacturerDTO<Guid>>>> GetAllManufaturers()
        {
            var manufacturers = await manufacturerService.GetAllAsync();

            return Ok(mapper.Map<ICollection<ManufacturerDTO<Guid>>>(manufacturers));
        }

        [HttpGet("{manufaturerID}")]
        [AllowAnonymous]
        public async Task<ActionResult<ICollection<ManufacturerDTO<Guid>>>> GetAllManufaturerWithTobacco(Guid manufaturerID)
        {
            var manufacturers = await manufacturerService.GetManufacturerWithTobaccosAsync(manufaturerID);

            return Ok(mapper.Map<ICollection<ManufacturerWithTobaccoDTO>>(manufacturers));
        }
    }
}