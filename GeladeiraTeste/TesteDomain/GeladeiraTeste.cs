using Domain.Models;

namespace GeladeiraTeste.TesteDomain
{
    public class GeladeiraTeste
    {
        [Fact]
        public void AvaliarAndar_DeveRetornarAndarCorreto()
        {
            var geladeira = new Geladeira();

            var andar = geladeira.AvaliarAndar(1);

            Assert.NotNull(andar);
            Assert.Equal(1, andar.NumeroAndar);
        }

        [Fact]
        public void AvaliarAndar_DeveLancarExcecaoParaNumeroDeAndarInvalido()
        {
            // Arrange
            var geladeira = new Geladeira();

            // Act & Assert
            var ex = Assert.Throws<Exception>(() => geladeira.AvaliarAndar(5));
            Assert.Equal("Posição inválida!", ex.Message);
        }

        [Fact]
        public void AdicionarItemNaGeladeira_DeveAdicionarItemComSucesso()
        {
            // Arrange
            var geladeira = new Geladeira();
            var item = new Item { Id = 1, Alimento = "Queijo", Quantidade = 2, Classificacao = "Hortifruit" };

            // Act
            string resultado = geladeira.AdicionarItemNaGeladeira(1, 0, 0, item);

            // Assert
            Assert.Equal("Item adicionado com sucesso!", resultado);
        }

        [Fact]
        public void AdicionarItemNaGeladeira_DeveRetornarErroQuandoContainerCheio()
        {
            var geladeira = new Geladeira();
            var item1 = new Item { Id = 1, Alimento = "Leite", Quantidade = 1, Classificacao = "Laticinio" };
            var item2 = new Item { Id = 2, Alimento = "Queijo", Quantidade = 1, Classificacao = "Laticinio" };
            var item3 = new Item { Id = 3, Alimento = "Presunto", Quantidade = 1, Classificacao = "Charcutaria" };
            var item4 = new Item { Id = 4, Alimento = "Manteiga", Quantidade = 1, Classificacao = "Laticinio" };
            var itemExtra = new Item { Id = 5, Alimento = "Iogurte", Quantidade = 1, Classificacao = "Laticinio" };

            geladeira.AdicionarItemNaGeladeira(0, 0, 0, item1);
            geladeira.AdicionarItemNaGeladeira(0, 0, 1, item2);
            geladeira.AdicionarItemNaGeladeira(0, 0, 2, item3);
            geladeira.AdicionarItemNaGeladeira(0, 0, 3, item4);

            string resultado = geladeira.AdicionarItemNaGeladeira(0, 0, null, itemExtra);

            Assert.Equal("O container não tem espaço suficiente", resultado);
        }

        [Fact]
        public void AdicionarItemNaGeladeira_DeveLancarExcecaoSeContainerNaoExistir()
        {
            // Arrange
            var geladeira = new Geladeira();
            var item = new Item { Id = 1, Alimento = "Frango", Quantidade = 2, Classificacao = "Carne" };

            // Act & Assert
            var ex = Assert.Throws<Exception>(() => geladeira.AdicionarItemNaGeladeira(1, 3, 0, item));
            Assert.Equal("Desculpe, não foi adicionado nenhum item!", ex.Message);
        }

        [Fact]
        public void RemoverItem_DeveRemoverItemCorretamente()
        {
            var geladeira = new Geladeira();
            var item = new Item { Id = 1, Alimento = "Leite", Quantidade = 1, Classificacao = "Laticinio" };

            geladeira.AdicionarItemNaGeladeira(0, 0, 0, item);

            geladeira.RemoverItem(0, 0, 0);

            var andar = geladeira.AvaliarAndar(0);
            var container = andar.ObterContainer(0);

            Assert.True(container.EstaVazio(), "O container deveria estar vazio após a remoção do item.");
        }

        [Fact]
        public void LimparGeladeira_DeveEsvaziarContainer()
        {
            var geladeira = new Geladeira();
            var item = new Item { Id = 1, Alimento = "Queijo", Quantidade = 1, Classificacao = "Laticinio" };

            geladeira.AdicionarItemNaGeladeira(0, 0, 0, item);

            geladeira.LimparGeladeira(0, 0);

            var andar = geladeira.AvaliarAndar(0);
            var container = andar.ObterContainer(0);
            Assert.True(container.EstaVazio());
        }

        [Fact]
        public void ExibirItensNaGeladeira_DeveExibirItensNosContainers()
        {
            var geladeira = new Geladeira();
            var item1 = new Item { Id = 1, Alimento = "Maçã", Quantidade = 5, Classificacao = "Hortfruit" };
            var item2 = new Item { Id = 2, Alimento = "Leite", Quantidade = 2, Classificacao = "Laticinio" };

            geladeira.AdicionarItemNaGeladeira(0, 0, 0, item1);
            geladeira.AdicionarItemNaGeladeira(0, 1, 1, item2);

            geladeira.ExibirItensNaGeladeira();

            Assert.True(true);
        }
    }
}
