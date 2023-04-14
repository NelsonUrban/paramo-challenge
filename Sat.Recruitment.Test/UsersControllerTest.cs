using System;
using Moq;
using Sat.Recruitment.Api.Controllers;
using Sat.Recruitment.Business.Dtos;
using Xunit;
using Sat.Recruitment.Business.Services.Abstract;
using Sat.Recruitment.Business.Services.Concrete;
using Sat.Recruitment.DataAccess.Repositories;
using AutoMapper;
using Sat.Recruitment.Business.Profiles;
using Sat.Recruitment.DataAccess.Repositories.Concrete;
using Microsoft.AspNetCore.Mvc;
using Sat.Recruitment.Custom.Services.Abstract;
using Sat.Recruitment.Custom.Services.Concrete;

namespace Sat.Recruitment.Test
{
    [CollectionDefinition("Tests", DisableParallelization = true)]
    public class UsersControllerTest
    {
        private readonly Mock<IMoneyService> _moneyService;
        private readonly Mock<UserProfile> _userProfile;
        private readonly IFileService _fileService;
        public UsersControllerTest()
        {
            this._moneyService = new Mock<IMoneyService>();
            this._userProfile = new Mock<UserProfile>();
            this._fileService = new FileService();
        }

        [Fact]
        public async void Post_OnSuccess_Returns_UserCreated()
        {
            //Arrange          
            IUserRepository _userRepository = new UserRepository(_fileService);
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(_userProfile.Object));
            IMapper mapper = new Mapper(configuration);

            IUserService userService = new UserService(_userRepository, mapper, _moneyService.Object);

            var userDto = new CreateUserDto
            {
                Name = "Mike",
                Email = "mike@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                UserType = "+349 1122354215",
                Money = Convert.ToDecimal("124")
            };

            //Act
            var userController = new UsersController(userService);

            var result = await userController.CreateUser(userDto);
            OkObjectResult objectResults = (OkObjectResult)result;
            UserReponseDto valueResult = (UserReponseDto)objectResults.Value;

            //Assert
            Assert.IsType<OkObjectResult>(objectResults);
            Assert.Equal(200, objectResults.StatusCode);
            Assert.True(valueResult.IsSuccess);
            Assert.Equal("User Created", valueResult.Errors);
        }

        [Fact]
        public async void Post_BadRequest_Returns_UserDuplicated()
        {
            //Arrange         
            IUserRepository _userRepository = new UserRepository(_fileService);
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(_userProfile.Object));
            IMapper mapper = new Mapper(configuration);

            IUserService userService = new UserService(_userRepository, mapper, _moneyService.Object);

            var userDto = new CreateUserDto
            {
                Name = "Agustina",
                Email = "Agustina@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                UserType = "Normal",
                Money = Convert.ToDecimal("124")
            };

            //Act
            var userController = new UsersController(userService);

            var result = await userController.CreateUser(userDto);
            BadRequestObjectResult objectResults = (BadRequestObjectResult)result;
          
            //Assert         
            Assert.IsType<BadRequestObjectResult>(objectResults);
            Assert.Equal(400, objectResults.StatusCode);          
            Assert.Equal("The user is duplicated", objectResults.Value);
        }
        [Fact]
        public async void Post_BadRequest_Returns_EmailIsNotValid()
        {
            //Arrange         
            IUserRepository _userRepository = new UserRepository(_fileService);
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(_userProfile.Object));
            IMapper mapper = new Mapper(configuration);

            IUserService userService = new UserService(_userRepository, mapper, _moneyService.Object);

            var userDto = new CreateUserDto
            {
                Name = "Agustina",
                Email = "Agustina.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                UserType = "Normal",
                Money = Convert.ToDecimal("124")
            };

            //Act
            var userController = new UsersController(userService);

            var result = await userController.CreateUser(userDto);
            BadRequestObjectResult objectResults = (BadRequestObjectResult)result;

            //Assert         
            Assert.IsType<BadRequestObjectResult>(objectResults);
            Assert.Equal(400, objectResults.StatusCode);
            Assert.Equal("The email has invalid format", objectResults.Value);
        }
    }
}
