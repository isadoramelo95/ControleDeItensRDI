using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Interfaces;
using Repository.RepositoriesClasses;

namespace GeladeiraTeste.TesteRepository
{
    public class GeladeiraRepositoryTeste
    {

        private GeladeiraContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<GeladeiraContext>()
                .UseInMemoryDatabase(databaseName: "GeladeiraTestDatabase")
                .Options;

            return new GeladeiraContext(options);
        }

        [Fact]
        public async Task AddNaGeladeira_Sucesso()
        {
            var context = GetInMemoryDbContext();
            var repository = new GeladeiraRepository(context);
            var item = new Item
            {
                Id = 1,
                Alimento = "Tomate",
                Quantidade = 5,
                Unidade = "kg",
                Classificacao = "Hortifruit",
                NumeroAndar = 1,
                NumeroContainer = 2,
                Posicao = 1
            };

            await repository.AddNaGeladeira(item);

            var result = await context.Items.FindAsync(item.Id);
            Assert.NotNull(result);
            Assert.Equal(item.Alimento, result.Alimento);
        }

        [Fact]
        public async Task RemoverItembyId_Sucesso()
        {
            var context = GetInMemoryDbContext();
            var repository = new GeladeiraRepository(context);
            var item = new Item
            {
                Id = 1,
                Alimento = "Tomate",
                Quantidade = 5,
                Unidade = "kg",
                Classificacao = "Hortifruit",
                NumeroAndar = 1,
                NumeroContainer = 2,
                Posicao = 1
            };
            await context.Items.AddAsync(item);
            await context.SaveChangesAsync();

            await repository.RemoverItembyId(1);

            var result = await context.Items.FindAsync(1);
            Assert.Null(result);
        }

        [Fact]
        public async Task RemoverItembyIdNaoRemove_NaoExisteId()
        {
            var context = GetInMemoryDbContext();
            var repository = new GeladeiraRepository(context);
            await repository.RemoverItembyId(1);

            var result = await context.Items.FindAsync(1);
            Assert.Null(result);
        }

        [Fact]
        public async Task EditarItemNaGeladeira_Sucesso()
        {
            var context = GetInMemoryDbContext();
            var repository = new GeladeiraRepository(context);
            var existingItem = new Item
            {
                Id = 1,
                Alimento = "Tomate",
                Quantidade = 5,
                Unidade = "kg",
                Classificacao = "Hotifruit",
                NumeroAndar = 1,
                NumeroContainer = 2,
                Posicao = 1
            };
            await context.Items.AddAsync(existingItem);
            await context.SaveChangesAsync();

            var updatedItem = new Item { Id = 1, Alimento = "Cenoura", Quantidade = 10, Unidade = "kg" };
            var result = await repository.EditarItemNaGeladeira(updatedItem);

            Assert.Equal("Item atualizado com sucesso!", result);
            var itemAfterUpdate = await context.Items.FindAsync(1);
            Assert.Equal(updatedItem.Alimento, itemAfterUpdate.Alimento);
        }

        [Fact]
        public async Task EditarItemNaGeladeira_Erro()
        {
            var context = GetInMemoryDbContext();
            var repository = new GeladeiraRepository(context);
            var item = new Item
            {
                Id = 1,
                Alimento = "Tomate",
                Quantidade = 5,
                Unidade = "kg",
                Classificacao = "Hortifruit",
                NumeroAndar = 1,
                NumeroContainer = 2,
                Posicao = 1
            };
            var exception = await Assert.ThrowsAsync<Exception>(() => repository.EditarItemNaGeladeira(item));
            Assert.Contains("Item não encontrado", exception.Message);
        }

        [Fact]
        public void ValidarItemExistente_Sucesso()
        {
            var context = GetInMemoryDbContext();
            var repository = new GeladeiraRepository(context);
            var item = new Item
            {
                Id = 1,
                Alimento = "Tomate",
                Quantidade = 5,
                Unidade = "kg",
                Classificacao = "Hortifruit",
                NumeroAndar = 1,
                NumeroContainer = 2,
                Posicao = 1
            };
            context.Items.Add(item);
            context.SaveChanges();

            var result = repository.ValidarItemExistente(item.Id);
            Assert.True(result);
        }

        [Fact]
        public void ValidarItemExistente_QuandoNaoExiste()
        {
            var context = GetInMemoryDbContext();
            var repository = new GeladeiraRepository(context);
            var result = repository.ValidarItemExistente(1);
            Assert.False(result);
        }
    }
}
