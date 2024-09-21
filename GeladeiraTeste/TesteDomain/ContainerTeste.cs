using Domain.Models;

namespace GeladeiraTeste.TesteDomain
{
    public class ContainerTeste
    {
        [Fact]
        public void AdicionarItem_DeveAdicionarItemNaPosicaoCorreta()
        {
            var container = new Container(1);
            var item = new Item { Id = 1, Alimento = "Arroz", Quantidade = 10, Classificacao = "Hortifruit" };

            string resultado = container.AdicionarItem(0, item);

            Assert.Equal("Item adicionado à posição 0: Arroz, Hortifruit.", resultado);
        }

        [Fact]
        public void AdicionarItem_DeveRetornarPosicaoJaOcupada()
        {
            var container = new Container(1);
            var item1 = new Item { Id = 1, Alimento = "Feijão", Quantidade = 5, Classificacao = "Hortifruit" };
            var item2 = new Item { Id = 2, Alimento = "Macarrão", Quantidade = 3, Classificacao = "Hortifruit" };

            container.AdicionarItem(1, item1);
            string resultado = container.AdicionarItem(1, item2);

            Assert.Equal("A posição 1 já está ocupada.", resultado);
        }

        [Fact]
        public void RemoverItem_DeveRemoverItemCorretamente()
        {
            var container = new Container(1);
            var item = new Item { Id = 1, Alimento = "Feijão", Quantidade = 5, Classificacao = "Hortifruit" };
            container.AdicionarItem(2, item);

            string resultado = container.RemoverItemDoContainer(2);

            Assert.Equal("Item removido da posição 2", resultado);
        }

        [Fact]
        public void RemoverItem_DeveRetornarPosicaoVazia()
        {
            var container = new Container(1);

            string resultado = container.RemoverItemDoContainer(3);

            Assert.Equal("Essa posição 3 está vazia", resultado);
        }

        [Fact]
        public void EstaCheio_DeveRetornarFalsoSeNaoEstaCheio()
        {
            var container = new Container(1);

            bool resultado = container.EstaCheio();

            Assert.False(resultado);
        }

        [Fact]
        public void EstaVazio_DeveRetornarVerdadeiroSeEstaVazio()
        {
            var container = new Container(1);

            bool resultado = container.EstaVazio();

            Assert.True(resultado);
        }

        [Fact]
        public void EsvaziarContainer_DeveRemoverTodosOsItens()
        {
            var container = new Container(1);
            var item = new Item { Id = 1, Alimento = "Feijão", Quantidade = 5, Classificacao = "Hortifruit" };
            container.AdicionarItem(2, item);

            string resultado = container.EsvaziarContainer();

            Assert.Equal("Itens removidos dos containers.", resultado);
            Assert.True(container.EstaVazio());
        }
    }
}
