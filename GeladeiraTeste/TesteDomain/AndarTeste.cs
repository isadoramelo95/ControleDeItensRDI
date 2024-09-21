using Domain.Models;

namespace GeladeiraTeste.TesteDomain
{
    public class AndarTeste
    {

        [Fact]
        public void AvaliarAndares_DeveRetornarExcecaoParaNumeroAndarInvalido()
        {
            var andar = new Andar(1);
            var listaAndares = new List<Andar> { new Andar(0), new Andar(1) };

            var ex = Assert.Throws<Exception>(() => andar.AvaliarAndares(2, listaAndares));
            Assert.Equal("Numero do andar inválido!", ex.Message);
        }

        [Fact]
        public void ObterContainer_DeveRetornarContainerCorreto()
        {
            var andar = new Andar(1, 3); 
            
            var container = andar.ObterContainer(2);

            Assert.NotNull(container);
            Assert.Equal(2, container.NumeroDeContainer);
        }

        [Fact]
        public void ObterContainer_DeveRetornarNuloSeContainerNaoExistir()
        {
            var andar = new Andar(1, 2);

            var container = andar.ObterContainer(3);

            Assert.Null(container);
        }

        [Fact]
        public void ExibirItens_DeveRetornarMensagemCorretaComItensNosContainers()
        {
            var andar = new Andar(1, 2);
            var item1 = new Item { Id = 1, Alimento = "Maçã", Quantidade = 5, Classificacao = "Hortifruit" };
            var item2 = new Item { Id = 2, Alimento = "Leite", Quantidade = 2, Classificacao = "Hortifruit" };

            andar.ObterContainer(0)?.AdicionarItem(0, item1);
            andar.ObterContainer(1)?.AdicionarItem(1, item2);

            string resultado = andar.ExibirItens();

            Assert.Contains("Posição 0: Maçã, 5, Hortifruit", resultado);
            Assert.Contains("Posição 1: Leite, 2, Hortifruit", resultado);
        }

        [Fact]
        public void ExibirItens_DeveRetornarMensagemNenhumItemEncontradoSeVazio()
        {
            var andar = new Andar(1, 2);

            string resultado = andar.ExibirItens();
            Assert.Contains("Nenhum item encontrado no container", resultado);
        }
    }
}
