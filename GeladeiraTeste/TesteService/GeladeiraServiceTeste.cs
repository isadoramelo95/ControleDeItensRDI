using Domain.Models;
using Moq;
using Repository.Interfaces;
using Services;

namespace GeladeiraTeste.TesteService
{
    public class GeladeiraServiceTeste
    {
        private readonly Mock<IRepository<Item>> _mockRepository;
        private readonly GeladeiraService _service;

        public GeladeiraServiceTeste()
        {
            _mockRepository = new Mock<IRepository<Item>>();
            _service = new GeladeiraService(_mockRepository.Object);
        }

        [Fact]
        public async Task AddNaGeladeira_ValorValido()
        {
            var item = new Item { Id = 0, Alimento = "Tomate", Quantidade = 5, Unidade = "kg" };
            _mockRepository.Setup(r => r.ValidarItemExistente(It.IsAny<int>())).Returns(false);
            _mockRepository.Setup(r => r.AddNaGeladeira(item)).Returns(Task.CompletedTask);

            var result = await _service.AddNaGeladeira(item);

            Assert.Equal("Item cadastrado com sucesso!", result);
            _mockRepository.Verify(r => r.AddNaGeladeira(item), Times.Once);
        }

        [Fact]
        public async Task RemoverItembyId_SucessoAoRemover()
        {
            var itemId = 1;
            _mockRepository.Setup(r => r.RemoverItembyId(itemId)).Returns(Task.CompletedTask);

            var result = await _service.RemoverItembyId(itemId);

            Assert.Equal("Item exclído com sucesso!", result);
            _mockRepository.Verify(r => r.RemoverItembyId(itemId), Times.Once);
        }

        [Fact]
        public async Task EditarItemNaGeladeira_Sucesso()
        {
            var item = new Item { Id = 1, Alimento = "Tomate", Quantidade = 5, Unidade = "kg" };
            _mockRepository.Setup(r => r.EditarItemNaGeladeira(item)).ReturnsAsync("Item alterado com sucesso!");

            var result = await _service.EditarItemNaGeladeira(item);

            Assert.Equal("Item alterado com sucesso!", result);
            _mockRepository.Verify(r => r.EditarItemNaGeladeira(item), Times.Once);
        }

        [Fact]
        public async Task GetItemById_Sucesso()
        {
            var item = new Item { Id = 1, Alimento = "Tomate", Quantidade = 5, Unidade = "kg" };
            _mockRepository.Setup(r => r.GetItemById(item.Id)).Returns(item);

            var result = _service.GetItemById(item.Id);

            Assert.NotNull(result);
            Assert.Equal("Tomate", result.Alimento);
        }

        [Fact]
        public async Task ListaDeItens_Sucesso()
        {
            var items = new List<Item>
            {
                new Item { Id = 1, Alimento = "Tomate", Quantidade = 5, Unidade = "kg" },
                new Item { Id = 2, Alimento = "Cenoura", Quantidade = 3, Unidade = "kg" }
            };
            _mockRepository.Setup(r => r.ListaDeItens()).ReturnsAsync(items);

            var result = await _service.ListaDeItens();

            Assert.Equal(2, result.Count);
            Assert.Contains(result, i => i.Alimento == "Tomate");
        }
    }
}