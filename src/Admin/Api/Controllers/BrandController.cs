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
[Route("api/brands")]
public class BrandController : ControllerBase
{
    private readonly IBrandService _brandService;

    public BrandController(IBrandService brandService)
    {
        _brandService = brandService;
    }

    [HttpPost]
    [ProducesDefaultResponseType(typeof(ResultDto))]
    public async Task<IActionResult> CreateBrandAsync([FromBody] CreateBrandDto dto)
    {
        return Ok(await _brandService.CreateAsync(dto));
    }

    [HttpPatch("{id}")]
    [ProducesDefaultResponseType(typeof(ResultDto))]
    public async Task<IActionResult> UpdateBrandAsync(int id, [FromBody] UpdateBrandDto dto)
    {
        return Ok(await _brandService.UpdateAsync(id, dto));
    }

    [HttpDelete("{id}")]
    [ProducesDefaultResponseType(typeof(ResultDto))]
    public async Task<IActionResult> DeleteBrandAsync(int id)
    {
        return Ok(await _brandService.SoftDeleteAsync(id));
    }

    [HttpGet("{id}")]
    [ProducesDefaultResponseType(typeof(ResultDto))]
    [ProducesResponseType(typeof(ObjectResultDto<BrandResource>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetBrandAsync(int id)
    {
        return Ok(await _brandService.GetByIdAsync<BrandResource>(id));
    }

    [HttpGet]
    [ProducesDefaultResponseType(typeof(ResultDto))]
    [ProducesResponseType(typeof(ListResultDto<BrandResource>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> ListBrandAsync([FromQuery] PaginatorDto paginator)
    {
        return Ok(await _brandService.ListAsync<BrandResource>(paginator));
    }
}