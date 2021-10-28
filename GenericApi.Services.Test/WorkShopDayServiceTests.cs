﻿using GenericApi.Model.Repositories;
using GenericApi.Bl.Dto;
using GenericApi.Bl.Validations;
using GenericApi.Services.Services;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using GenericApi.Services.Tests.Fixtures;

namespace GenericApi.Services.Tests
{
    public class WorkShopDayServiceTests : IClassFixture<ServicesTestsFixture>
    {
        private readonly IWorkShopDayService _workShopDayService;

        public WorkShopDayServiceTests(ServicesTestsFixture fixture)
        {
            IWorkShopDayRepository repository = new WorkShopDayRepository(fixture.Context);

            var validator = new WorkShopDayValidator();

            _workShopDayService = new WorkShopDayService(repository, fixture.Mapper, validator);
        }

        [Fact]
        public async Task ShouldSaveWorkShopDayAsync()
        {
            //Arrange
            var requestDto = new WorkShopDayDto
            {
                Day = (Core.Enums.WeekDay)2,
                Mode = (Core.Enums.WorkShopDayMode)1,
                ModeLocation = "(MS Teams - https://bit.ly/3wE024J)",
                StartHour = "10 am",
                EndHour = null,
                WorkShopId = 1
            };

            //Act
            var result = await _workShopDayService.AddAsync(requestDto);

            //Assert
            Assert.True(result.IsSuccess, result.Errors.FirstOrDefault());
            Assert.NotNull(result.Entity);
            Assert.Empty(result.Errors);
        }

        [Fact]
        public async Task ShouldGetAllWorkShopDaysAsync()
        {
            //Act
            var result = await _workShopDayService.GetAllAsync();

            //Assert
            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task ShouldUpdateWorkShopDayAsync()
        {
            //Arrange
            var id = 1;
            var requestDto = new WorkShopDayDto
            {
                Id = 1,
                Day = (Core.Enums.WeekDay) 3,
                Mode = (Core.Enums.WorkShopDayMode) 1,
                ModeLocation = "(MS Teams - https://bit.ly/3wE024J)",
                StartHour = "10 am",
                EndHour = null,
                WorkShopId = 1
            };

            //Act
            var result = await _workShopDayService.UpdateAsync(id, requestDto);

            //Assert
            Assert.True(result.IsSuccess, result.Errors.FirstOrDefault());
            Assert.NotNull(result.Entity);
            Assert.Equal(requestDto.Day, result.Entity.Day);
        }

        [Fact]
        public async Task ShouldDeleteWorkShopDayAsync()
        {
            //Arrange
            var id = 2;

            //Act
            var result = await _workShopDayService.DeleteByIdAsync(id);

            //Assert
            Assert.True(result.IsSuccess, result.Errors.FirstOrDefault());
            Assert.NotNull(result.Entity);
            Assert.True(result.Entity.Deleted);
        }
    }
}
