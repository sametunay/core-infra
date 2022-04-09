using System.Net;
using Microsoft.AspNetCore.Mvc;
using MyGallery.Admin.Application.Dto;
using MyGallery.Admin.Application.Dto.Create;
using MyGallery.Admin.Application.Dto.Resource;
using MyGallery.Admin.Application.Dto.Update;
using MyGallery.Admin.Application.Service.Interfaces;
using MyGallery.Core.Domain.Dto;

namespace MyGallery.Admin.Api.Controller
{
    [ApiController]
    [Route("api/cars")]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpPost]
        [ProducesDefaultResponseType(typeof(ResultDto))]
        public async Task<IActionResult> CreateCarAsync([FromBody] CreateCarDto dto)
        {
            return Ok(await _carService.CreateAsync(dto));
        }

        [HttpPatch("{id}")]
        [ProducesDefaultResponseType(typeof(ResultDto))]
        public async Task<IActionResult> UpdateCarAsync(int id, [FromBody] UpdateCarDto dto)
        {
            return Ok(await _carService.UpdateAsync(id, dto));
        }

        [HttpDelete("{id}")]
        [ProducesDefaultResponseType(typeof(ResultDto))]
        public async Task<IActionResult> DeleteCarAsync(int id)
        {
            return Ok(await _carService.SoftDeleteAsync(id));
        }

        [HttpGet("{id}")]
        [ProducesDefaultResponseType(typeof(ResultDto))]
        [ProducesResponseType(typeof(ObjectResultDto<CarResource>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetCarAsync(int id)
        {
            return Ok(await _carService.GetByIdAsync<CarResource>(id));
        }

        [HttpGet]
        [ProducesDefaultResponseType(typeof(ResultDto))]
        [ProducesResponseType(typeof(ListResultDto<CarResource>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> ListCarAsync([FromQuery] PaginatorDto paginator)
        {
            return Ok(await _carService.ListAsync<CarResource>(paginator));
        }
    }
}