﻿using GenericApi.Model.Repositories;
using GenericApi.Bl.Dto;
using GenericApi.Bl.Validations;
using GenericApi.Services.Services;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using GenericApi.Services.Tests.Fixtures;

namespace GenericApi.Services.Tests
{
    public class WorkShopServiceTests : IClassFixture<ServicesTestsFixture>
    {
        private readonly IWorkShopService _workShopService;

        public WorkShopServiceTests(ServicesTestsFixture fixture)
        {
            IWorkShopRepository repository = new WorkShopRepository(fixture.Context);

            var validator = new WorkShopValidator();

            _workShopService = new WorkShopService(repository, fixture.Mapper, validator);
        }

        [Fact]
        public async Task ShouldSaveWorkShopAsync()
        {
            //Arrange
            var requestDto = new WorkShopDto
            {
                Name = "Solvex WorkShop",
                Description = "We are here to practice a lot!",
                StartDate = new System.DateTime(2021, 06, 18),
                EndDate = null,
                ContentSupport = "https://github.com/EmmanuelJP/GenericApis",
            };

            //Act
            var result = await _workShopService.AddAsync(requestDto);

            //Assert
            Assert.True(result.IsSuccess, result.Errors.FirstOrDefault());
            Assert.NotNull(result.Entity);
            Assert.Empty(result.Errors);
        }

        [Fact]
        public async Task ShouldGetAllWorkShopsAsync()
        {
            //Act
            var result = await _workShopService.GetAllAsync();

            //Assert
            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task ShouldUpdateWorkShopAsync()
        {
            //Arrange
            var id = 1;

            var requestDto = new WorkShopDto
            {
                Id = 1,
                Name = "Solvex WorkShop",
                Description = "We are currently learning TDD",
                StartDate = new System.DateTime(2021, 06, 18),
                EndDate = null,
                ContentSupport = "https://github.com/EmmanuelJP/GenericApis",
            };

            //Act
            var result = await _workShopService.UpdateAsync(id, requestDto);

            //Assert
            Assert.True(result.IsSuccess, result.Errors.FirstOrDefault());
            Assert.NotNull(result.Entity);
            Assert.Equal(requestDto.Name, result.Entity.Name);

        }

        [Fact]
        public async Task ShouldDeleteWorkShopAsync()
        {
            //Arrange
            var id = 2;

            //Act
            var result = await _workShopService.DeleteByIdAsync(id);

            //Assert
            Assert.True(result.IsSuccess, result.Errors.FirstOrDefault());
            Assert.NotNull(result.Entity);
            Assert.True(result.Entity.Deleted);
        }
    }
}
