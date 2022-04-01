using CloudCustomers.API.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Xunit;

namespace CloudCustomers.UnitTests.Systems.Controllers;

public class TestUserController
{
    [Fact]
    public async Task Get_ReturnStatusCode200()
    {
        //Arrange - Organizar
        //Configura o sistema de teste e o organiza para estar pronto para o teste
        var sut = new UserController();

        //Act - Ação
        //Chamadas de métodos que vamos testar
        var result = (OkObjectResult)await sut.Get();

        //Assert - Asserto
        //Resultado/Afirmação da organização e ação aplicadas no teste
        result.StatusCode.Should().Be(200);

    }
}