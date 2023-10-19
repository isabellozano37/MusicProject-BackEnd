using Data;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MusicProject.Controllers;
using MusicProject.IService;
using MusicProject.Models;
using MusicProject.Service;
using System.Collections.ObjectModel;

namespace TestProject1
{
    [TestClass]
    public class UsersControllersTests
    {
        [TestMethod]
        public void Test_InsertUsers_ValidUser_ReturnsOkResult()
        {
            // Arrange
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            var options = new DbContextOptionsBuilder<ServiceContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            using (var serviceContext = new ServiceContext(options))
            {
                var usersService = new UsersService(serviceContext);
                var controller = new UsersControllers(configuration, usersService, serviceContext);
                var userToInsert = new Users
                {
                    FirstName = "Isabel",
                    LastName = "Lozano",
                    UserName = "Isa23",
                    Email = "Isabel@gmail.com",
                    Password = "12345",
                    Id_Roll = 1 // Puedes establecer otras propiedades según sea necesario
                };
                // Act
                var result = controller.Post(userToInsert);
                serviceContext.SaveChanges();
                // Assert
                Assert.IsNotNull(result);
            }
        }

        [TestMethod]
        public void Test_Login_ValidCredentials_ReturnsToken()
        {
            // Arrange
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            var options = new DbContextOptionsBuilder<ServiceContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            using (var serviceContext = new ServiceContext(options))
            {
                var usersService = new UsersService(serviceContext);
                var controller = new UsersControllers(configuration, usersService, serviceContext);
                var loginRequest = new LoginRequestModel
                {
                    UserName = "Isa23",
                    Password = "12345"
                };
                // Suponiendo que has configurado tu base de datos de prueba con datos de usuario de muestra
                // Act
                var result = controller.Login(loginRequest);
                // Assert
                var token = result;
                Assert.IsNotNull(token);
            }
        }
    }
}
