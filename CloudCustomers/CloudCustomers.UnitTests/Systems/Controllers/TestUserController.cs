using CloudCustomers.API.Controllers;
using CloudCustomers.API.Models;
using CloudCustomers.API.Services;
using CloudCustomers.UnitTests.Fixtures;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace CloudCustomers.UnitTests.Systems.Controllers;

public class TestUserController
{
    [Fact]
    public async Task Get_OnSucess_ReturnStatusCode200()
    {
        //Arrange - Organizar
        //Configura o sistema de teste e o organiza para estar pronto para o teste
        var mockUsersService = new Mock<IUsersService>();

        mockUsersService.Setup(service => service.GetAllUsers())
        .ReturnsAsync(UsersFixture.GetTestUsers());

        var sut = new UserController(mockUsersService.Object);

        //Act - Ação
        //Chamadas de métodos que vamos testar
        var result = (OkObjectResult)await sut.Get();

        //Assert - Asserto
        //Resultado/Afirmação da organização e ação aplicadas no teste
        result.StatusCode.Should().Be(200);

    }

    [Fact]
    public async void Get_OnSuccess_InvokesUserServiceExactlyOnce()
    {
        //Arrange - Organizar
        var mockUsersService = new Mock<IUsersService>();

        mockUsersService.Setup(service => service.GetAllUsers())
            .ReturnsAsync(new List<User>());

        var sut = new UserController(mockUsersService.Object);

        //Act - Ação
       var result = await sut.Get();

        //Assert - Asserto
        mockUsersService.Verify(service =>
        service.GetAllUsers(), Times.Once());

    }

    [Fact]
    public async Task Get_OnSuccess_ReturnsListOfUsers() 
    {
        //Arrange
        var mockUsersService = new Mock<IUsersService>();

        mockUsersService.Setup(service => service.GetAllUsers())
            .ReturnsAsync(UsersFixture.GetTestUsers());

        var sut = new UserController(mockUsersService.Object);

        //Act
        var result = await sut.Get();

        //Assert
        result.Should().BeOfType<OkObjectResult>();
        var objectResult = (OkObjectResult)result;
        objectResult.Value.Should().BeOfType<List<User>>();
    } 
    
    [Fact]
    public async Task Get_OnNoUsersFound_Returns404() 
    {
        //Arrange
        var mockUsersService = new Mock<IUsersService>();

        mockUsersService.Setup(service => service.GetAllUsers())
            .ReturnsAsync(new List<User>());

        var sut = new UserController(mockUsersService.Object);

        //Act
        var result = await sut.Get();

        //Assert
        result.Should().BeOfType<NotFoundResult>();
        var objectResult = (NotFoundResult)result;
        objectResult.StatusCode.Should().Be(404);
      
    }
}