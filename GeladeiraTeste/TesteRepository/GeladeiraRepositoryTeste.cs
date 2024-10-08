﻿using Domain.Models;
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
            // Arrange
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

            // Act
            await repository.AddNaGeladeira(item);

            var result = await context.Items.FindAsync(item.Id);
            Assert.NotNull(result);
            Assert.Equal(item.Alimento, result.Alimento);
        }

        [Fact]
        public async Task RemoverItembyId_Sucesso()
        {
            // Arrange
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
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new GeladeiraRepository(context);
            
            // Act
            await repository.RemoverItembyId(1);

            // Assert
            var result = await context.Items.FindAsync(1);
            Assert.Null(result);
        }

        [Fact]
        public async Task EditarItemNaGeladeira_Sucesso()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new GeladeiraRepository(context);

            var existingItem = new Item
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
            await context.Items.AddAsync(existingItem);
            await context.SaveChangesAsync();

            var updatedItem = new Item
            {
                Id = 1,
                Alimento = "Cenoura",
                Quantidade = 10,
                Unidade = "kg"
            };

            var result = await repository.EditarItemNaGeladeira(updatedItem);

            Assert.Equal("Item atualizado com sucesso!", result);

            var itemDepoisDoUpdate = await context.Items.FindAsync(1);
            Assert.Equal(updatedItem.Alimento, itemDepoisDoUpdate.Alimento);
            Assert.Equal(updatedItem.Quantidade, itemDepoisDoUpdate.Quantidade);
            Assert.Equal(updatedItem.Unidade, itemDepoisDoUpdate.Unidade);
        }

        [Fact]
        public async Task EditarItemNaGeladeira_Erro()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new GeladeiraRepository(context);
            var item = new Item
            {
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
            // Arrange
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
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new GeladeiraRepository(context);

            var existingItem = context.Items.Find(1);
            Assert.Null(existingItem);
          
        }
    }
}
