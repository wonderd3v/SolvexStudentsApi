using AutoMapper;
using FluentValidation;
using GenericApi.Bl.Dto;
using GenericApi.Bl.Validations;
using GenericApi.Core.Settings;
using GenericApi.Model.Entities;
using GenericApi.Model.Repositories;
using GenericApi.Services.Services;
using Microsoft.Extensions.Options;
using Moq;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace GenericApi.Services.Tests.Mocks
{
    public class UserServiceMockTests
    {
        private IUserService _userService;

        [Theory]
        [InlineData("Hola1234,")]
        public async Task ShouldSaveUserAsync(string password)
        {
            #region Arrange
            var dto = new StudentDto
            {
                Name = "Emmanuel",
                UserName = "Emma",
                Password = password
            };
            var user = new User
            {
                Name = dto.Name,
                UserName = dto.UserName,
                Password = dto.Password
            };

            var validatorMock = new Mock<IValidator<StudentDto>>();
            validatorMock
                .Setup(x => x.Validate(dto))
                .Returns(new FluentValidation.Results.ValidationResult());

            var mapperMock = new Mock<IMapper>();
            mapperMock
                .Setup(x => x.Map<User>(It.IsAny<StudentDto>()))
               .Returns(user);

            var repositoryMock = new Mock<IUserRepository>();
            repositoryMock
                .Setup(x => x.Add(It.IsAny<User>()))
                .Callback<User>(x =>
                {
                    user.Id = 1;
                    user.Password = x.Password;
                    user.CreatedDate = System.DateTimeOffset.UtcNow;
                })
                .ReturnsAsync(user);

            mapperMock
                .Setup(x => x.Map(It.IsAny<User>(), It.IsAny<StudentDto>()))
                .Callback<User, StudentDto>((x, y) =>
                {
                    dto.Id = x.Id;
                    dto.Password = x.Password;
                    dto.CreatedDate = x.CreatedDate;
                })
                .Returns(dto);

            var optionMock = new Mock<IOptions<JwtSettings>>();

            _userService = new UserService(
                repositoryMock.Object,
                mapperMock.Object,
                validatorMock.Object,
                optionMock.Object
                );

            #endregion

            //Act
            var result = await _userService.AddAsync(dto);

            //Assert
            Assert.True(result.IsSuccess, result.Errors.FirstOrDefault());
            Assert.Equal(result.Entity, dto);
            Assert.Equal(result.Entity.UserName, user.UserName);
            Assert.NotEqual(result.Entity.Password, password);
            Assert.Equal(result.Entity.CreatedDate, user.CreatedDate);
        }

        [Fact]
        public async Task ShouldValidationFailed()
        {
            #region Arrange
            var validatorMock = new Mock<IValidator<StudentDto>>();
            validatorMock.Setup(x => x.Validate(It.IsAny<StudentDto>()))
                .Returns(new UserValidator().Validate(new StudentDto()));

            var mapperMock = new Mock<IMapper>();
            var repositoryMock = new Mock<IUserRepository>();
            var optionMock = new Mock<IOptions<JwtSettings>>();

            _userService = new UserService(
                repositoryMock.Object,
                mapperMock.Object,
                validatorMock.Object,
                optionMock.Object
                );

            #endregion

            //Act
            var result = await _userService.AddAsync(new StudentDto());

            //Assert
            Assert.False(result.IsSuccess);
        }

    }
}
