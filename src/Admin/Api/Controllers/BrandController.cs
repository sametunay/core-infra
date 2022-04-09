using System.Net;
using Microsoft.AspNetCore.Mvc;
using MyGallery.Admin.Application.Dto;
using MyGallery.Admin.Application.Dto.Create;
using MyGallery.Admin.Application.Dto.Resource;
using MyGallery.Admin.Application.Dto.Update;
using MyGallery.Admin.Application.Service.Interfaces;
using MyGallery.Core.Domain.Dto;

namespace MyGallery.Admin.Api.Controller;

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