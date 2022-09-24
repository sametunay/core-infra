using System.Net;
using Microsoft.AspNetCore.Mvc;
using CI.Admin.Application.Dto;
using CI.Admin.Application.Dto.Create;
using CI.Admin.Application.Dto.Resource;
using CI.Admin.Application.Dto.Update;
using CI.Admin.Application.Service.Interfaces;
using CI.Core.Domain.Dto;

namespace CI.Admin.Api.Controller;

[ApiController]
[Route("api/car-categories")]
public class CarCategoryController : ControllerBase
{
    private readonly ICarCategoryService _carCategoryService;

    public CarCategoryController(ICarCategoryService carCategoryService)
    {
        _carCategoryService = carCategoryService;
    }

    [HttpPost]
    [ProducesDefaultResponseType(typeof(ResultDto))]
    public async Task<IActionResult> CreateCarCategoryAsync([FromBody] CreateCarCategoryDto dto)
    {
        return Ok(await _carCategoryService.CreateAsync(dto));
    }

    [HttpPatch("{id}")]
    [ProducesDefaultResponseType(typeof(ResultDto))]
    public async Task<IActionResult> UpdateCarCategoryAsync(int id, [FromBody] UpdateCarCategoryDto dto)
    {
        return Ok(await _carCategoryService.UpdateAsync(id, dto));
    }

    [HttpDelete("{id}")]
    [ProducesDefaultResponseType(typeof(ResultDto))]
    public async Task<IActionResult> DeleteCarCategoryAsync(int id)
    {
        return Ok(await _carCategoryService.SoftDeleteAsync(id));
    }

    [HttpGet("{id}")]
    [ProducesDefaultResponseType(typeof(ResultDto))]
    [ProducesResponseType(typeof(ObjectResultDto<CarCategoryResource>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetCarCategoryAsync(int id)
    {
        return Ok(await _carCategoryService.GetByIdAsync<CarCategoryResource>(id));
    }

    [HttpGet]
    [ProducesDefaultResponseType(typeof(ResultDto))]
    [ProducesResponseType(typeof(ListResultDto<CarCategoryResource>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> ListCarCategoryAsync([FromQuery] PaginatorDto paginator)
    {
        return Ok(await _carCategoryService.ListAsync<CarCategoryResource>(paginator));
    }
}