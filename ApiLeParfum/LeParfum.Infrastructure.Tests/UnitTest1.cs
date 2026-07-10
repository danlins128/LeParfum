using Xunit;
using LeParfum.Infrastructure.Security.Token;

namespace LeParfum.Infrastructure.Tests;

public class UnitTest1
{
    [Fact]
    public void GenerateToken_Returns_Valid_Jwt_Token()
    {
        // Arrange: Inicializamos o serviço com uma chave secreta de exemplo
        var secretKey = "super_secret_key_which_is_long_enough_for_security";
        var tokenService = new TokenService(secretKey);
        var userId = "12345";
        var userName = "testuser";

        // Act: Chamamos o método para gerar o token com dados de exemplo
        var token = tokenService.GenerateToken(userId, userName);

        // Assert: Verificamos se o token gerado não está nulo ou vazio
        Assert.NotNull(token); // Verifica se o token não é nulo
        Assert.NotEmpty(token); // Verifica se o token não é uma string vazia
        Assert.Contains(".", token); // Verifica se o token contém pelo menos um ponto, indicando que é um JWT válido
        // Podemos adicionar mais verificações, como decodificar o token e verificar as claims, se necessário exemplo: Assert.notnullorempty(tokenService.DecodeToken(token)); // Verifica se o token pode ser decodificado corretamente
        
    }
}
