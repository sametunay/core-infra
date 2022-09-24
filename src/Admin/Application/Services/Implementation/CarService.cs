using AutoMapper;
using CI.Admin.Application.Dto.Create;
using CI.Admin.Application.Dto.Update;
using CI.Admin.Application.Service.Interfaces;
using CI.Core.Domain.Dto;
using CI.Core.Domain.Entities;
using CI.Core.Infrastructure.Repositories.Interfaces;

namespace CI.Admin.Application.Service.Implementation
{
    public class CarService : BaseService<Car, int, ResultDto>, ICarService
    {
        private readonly ICarCategoryRepository _carCategoryRepository;
        private readonly IBrandRepository _brandRepository;

        public CarService(ICarRepository repository, IMapper mapper, ICarCategoryRepository carCategoryRepository, IBrandRepository brandRepository) : base(repository, mapper)
        {
            _carCategoryRepository = carCategoryRepository;
            _brandRepository = brandRepository;
        }

        public override async Task<ResultDto> CreateAsync<TDto>(TDto dto)
        {
            if (typeof(TDto) == typeof(CreateCarDto))
            {
                await base.IdCheck<CarCategory, int, ICarCategoryRepository>((dto as CreateCarDto).CarCategoryId, _carCategoryRepository);
                await base.IdCheck<Brand, int, IBrandRepository>((dto as CreateCarDto).BrandId, _brandRepository);
            }

            return await base.CreateAsync(dto);
        }

        public override async Task<ResultDto> UpdateAsync<TDto>(int key, TDto dto)
        {
            if (typeof(TDto) == typeof(UpdateCarDto))
            {
                await base.IdCheck<CarCategory, int, ICarCategoryRepository>((dto as CreateCarDto).CarCategoryId, _carCategoryRepository);
                await base.IdCheck<Brand, int, IBrandRepository>((dto as CreateCarDto).BrandId, _brandRepository);
            }

            return await base.UpdateAsync(key, dto);
        }
    }
}