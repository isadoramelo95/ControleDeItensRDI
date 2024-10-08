using Domain.Models;
using Domain.ResourceTeste;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.RepositoriesClasses;

namespace GeladeiraTeste.TesteService
{
    public class LogingTeste
    {
        private GeladeiraContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<GeladeiraContext>()
                .UseInMemoryDatabase(databaseName: "GeladeiraTestDB")
                .Options;

            return new GeladeiraContext(options);
        }

        [Fact]
        public async Task GerarUsuario_Sucesso()
        {
            //Arrange
            var context = GetInMemoryDbContext();
            var repository = new UsuarioRepository(context);
            var usuario = new Usuario { Id = 1, Email = "teste@teste.com", Nome ="Teste", UserName = "Teste1", SenhaHash = "teste123" };

            //Act
            await repository.AdicionarUsuarioAsync(usuario, CancellationToken.None);

            //Assert
            var usuarioAdicionado = context.Usuarios.FirstOrDefault(i => i.Id == usuario.Id);
            Assert.NotNull(usuarioAdicionado);
            Assert.Equal("teste@teste.com", usuarioAdicionado?.Email);

        }

        [Fact]
        public async Task GetUsuario_Sucesso()
        {
            //Arrange
            var context = GetInMemoryDbContext();
            var repository = new UsuarioRepository(context);
            var usuario = new Usuario { Id = 1, Email = "teste@teste.com", Nome = "Teste", UserName = "Teste1", SenhaHash = "teste123" };
            await repository.AdicionarUsuarioAsync(usuario, CancellationToken.None);

            var loginResource = new LoginResource(usuario.Nome, "teste123");

            //Act
            var receberUsuario = await repository.GetUsusarioAsync(loginResource, CancellationToken.None);

            //Assert
            Assert.NotNull(receberUsuario);
            Assert.Equal("teste@teste.com", receberUsuario?.Email);

        }
    }
}
