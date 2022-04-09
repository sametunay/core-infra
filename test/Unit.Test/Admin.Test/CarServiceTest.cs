using System.Threading.Tasks;
using AutoMapper;
using FakeItEasy;
using MyGallery.Admin.Application.Dto.Create;
using MyGallery.Admin.Application.Dto.Resource;
using MyGallery.Admin.Application.Dto.Update;
using MyGallery.Admin.Application.Mapper;
using MyGallery.Admin.Application.Service.Implementation;
using MyGallery.Admin.Application.Service.Interfaces;
using MyGallery.Core.Domain.Dto;
using MyGallery.Core.Domain.Entities;
using MyGallery.Core.Domain.Exceptions;
using MyGallery.Core.Infrastructor.Repositories.Interfaces;
using Xunit;

namespace MyGallery.Test.AdminTest
{
    public class CarServiceTest
    {
        private ICarRepository _carRepository;
        private ICarCategoryRepository _carCategoryRepository;
        private IBrandRepository _brandRepository;
        private IMapper _mapper;
        private ICarService _carService;

        public CarServiceTest()
        {
            _carRepository = A.Fake<ICarRepository>();
            _carCategoryRepository = A.Fake<ICarCategoryRepository>();
            _brandRepository = A.Fake<IBrandRepository>();

            var mappingConfig = new MapperConfiguration(mc => mc.AddAdminProfiles()); //TODO: shared
            _mapper = mappingConfig.CreateMapper();

            _carService = new CarService(_carRepository, _mapper, _carCategoryRepository, _brandRepository);
        }

        [Fact]
        public async Task ShouldFail_CreateCar_Given_Non_Exist_CarCategoryId()
        {
            var dto = A.Fake<CreateCarDto>();

            A.CallTo(() => _brandRepository.AnyAsync(dto.BrandId)).Returns(true);
            A.CallTo(() => _carCategoryRepository.AnyAsync(dto.CarCategoryId)).Returns(false);

            await Assert.ThrowsAsync<NotFoundException>(async () => await _carService.CreateAsync(dto));
        }

        [Fact]
        public async Task ShouldSuccess_CreateCar_Given_Exist_CarCategoryId()
        {
            var dto = A.Fake<CreateCarDto>();

            A.CallTo(() => _brandRepository.AnyAsync(dto.BrandId)).Returns(true);
            A.CallTo(() => _carCategoryRepository.AnyAsync(dto.CarCategoryId)).Returns(true);

            var result = await _carService.CreateAsync(dto);

            Assert.True(result.IsSuccess());
        }

        [Fact]
        public async Task ShouldFail_CreateCar_Given_Non_Exist_BrandId()
        {
            var dto = A.Fake<CreateCarDto>();

            A.CallTo(() => _brandRepository.AnyAsync(dto.BrandId)).Returns(false);
            A.CallTo(() => _carCategoryRepository.AnyAsync(dto.CarCategoryId)).Returns(true);

            await Assert.ThrowsAsync<NotFoundException>(async () => await _carService.CreateAsync(dto));
        }

        [Fact]
        public async Task ShouldSuccess_CreateCar_Given_Exist_BrandId()
        {
            var dto = A.Fake<CreateCarDto>();

            A.CallTo(() => _brandRepository.AnyAsync(dto.BrandId)).Returns(true);
            A.CallTo(() => _carCategoryRepository.AnyAsync(dto.CarCategoryId)).Returns(true);

            var result = await _carService.CreateAsync(dto);

            Assert.True(result.IsSuccess());
        }

        [Fact]
        public async Task ShouldFail_UpdateCar_Given_Non_Exist_Id()
        {
            int id = 7;
            var dto = new UpdateCarDto();

            A.CallTo(() => _brandRepository.AnyAsync(dto.BrandId)).Returns(true);
            A.CallTo(() => _carCategoryRepository.AnyAsync(dto.CarCategoryId)).Returns(true);
            A.CallTo(() => _carRepository.GetByIdAsync(id)).Returns(null as Car);

            await Assert.ThrowsAsync<NotFoundException>(async () => await _carService.UpdateAsync(id, dto));
        }

        [Fact]
        public async Task ShouldSuccess_UpdateCar_Given_Exist_Id()
        {
            int id = 9;
            var dto = new UpdateCarDto();

            A.CallTo(() => _brandRepository.AnyAsync(dto.BrandId)).Returns(true);
            A.CallTo(() => _carCategoryRepository.AnyAsync(dto.CarCategoryId)).Returns(true);
            A.CallTo(() => _carRepository.GetByIdAsync(id)).Returns(A.Fake<Car>());

            var result = await _carService.UpdateAsync(id, dto);

            Assert.True(result.IsSuccess());
        }

        [Fact]
        public async Task ShouldFail_UpdateCar_Given_Non_Exist_CarCategoryId()
        {
            var id = 2;
            var dto = new UpdateCarDto();

            A.CallTo(() => _carRepository.GetByIdAsync(id)).Returns(A.Fake<Car>());
            A.CallTo(() => _brandRepository.AnyAsync(dto.BrandId)).Returns(true);
            A.CallTo(() => _carCategoryRepository.AnyAsync(dto.CarCategoryId)).Returns(false);

            await Assert.ThrowsAsync<NotFoundException>(async () => await _carService.UpdateAsync(id, dto));
        }

        [Fact]
        public async Task ShouldFail_UpdateCar_Given_Non_Exist_BrandId()
        {
            var id = 4;
            var dto = new UpdateCarDto();

            A.CallTo(() => _carRepository.GetByIdAsync(id)).Returns(A.Fake<Car>());
            A.CallTo(() => _carCategoryRepository.AnyAsync(dto.CarCategoryId)).Returns(true);
            A.CallTo(() => _brandRepository.AnyAsync(dto.BrandId)).Returns(false);

            await Assert.ThrowsAsync<NotFoundException>(async () => await _carService.UpdateAsync(id, dto));
        }

        [Fact]
        public async Task ShouldSuccess_UpdateCar_Given_Exist_CarCategoryId()
        {
            var id = 1;
            var dto = new UpdateCarDto();

            A.CallTo(() => _carRepository.GetByIdAsync(id)).Returns(A.Fake<Car>());
            A.CallTo(() => _carCategoryRepository.AnyAsync(dto.CarCategoryId)).Returns(true);
            A.CallTo(() => _brandRepository.AnyAsync(dto.BrandId)).Returns(true);

            var result = await _carService.UpdateAsync(id, dto);
            Assert.True(result.IsSuccess());
        }

        [Fact]
        public async Task ShouldSuccess_UpdateCar_Given_Exist_BrandId()
        {
            var id = 8;
            var dto = new UpdateCarDto();

            A.CallTo(() => _carRepository.GetByIdAsync(id)).Returns(A.Fake<Car>());
            A.CallTo(() => _carCategoryRepository.AnyAsync(dto.CarCategoryId)).Returns(true);
            A.CallTo(() => _brandRepository.AnyAsync(dto.BrandId)).Returns(true);

            var result = await _carService.UpdateAsync(id, dto);
            Assert.True(result.IsSuccess());
        }

        [Fact]
        public async Task ShouldFail_DeleteCar_Given_Non_Exist_Id()
        {
            int id = 7;

            A.CallTo(() => _carRepository.GetByIdAsync(id)).Returns(null as Car);

            await Assert.ThrowsAsync<NotFoundException>(async () => await _carService.SoftDeleteAsync(id));
        }

        [Fact]
        public async Task ShouldSuccess_DeleteCar_Given_Exist_Id()
        {
            int id = 7;

            A.CallTo(() => _carRepository.GetByIdAsync(id)).Returns(A.Fake<Car>());

            var result = await _carService.SoftDeleteAsync(id);
            Assert.True(result.IsSuccess());
        }

        [Fact]
        public async Task ShouldFail_GetById_Given_Exist_Id()
        {
            var id = 5;

            A.CallTo(() => _carRepository.GetByIdAsync(id)).Returns(null as Car);

            await Assert.ThrowsAsync<NotFoundException>(async () => await _carService.GetByIdAsync<CarResource>(id));
        }

        [Fact]
        public async Task ShouldSuccess_GetById_Given_Exist_Id()
        {
            var id = 7;
            var car = A.Fake<Car>();
            car.CreateAudit();

            A.CallTo(() => _carRepository.GetByIdAsync(id)).Returns(car);

            var result = await _carService.GetByIdAsync<CarResource>(id);

            Assert.Null(result.ErrorCode);
            Assert.NotNull(result.Data);
            Assert.IsType<ObjectResultDto<CarResource>>(result);
        }
    }
}