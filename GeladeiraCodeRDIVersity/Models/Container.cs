using Domain.Interface;

namespace Domain.Models
{
    public class Container : IContainer
    {
        private const int limiteItens = 4;
        public Item _item;
        public Andar _andar;
        public int NumeroDeContainer { get; set; }
        private readonly List<Item> item;

        public Container(int numeroContainer)
        {
            NumeroDeContainer = numeroContainer;
            item = new List<Item>(new Item[limiteItens]);
        }

        public Container()
        {
        }

        public string RemoverItemDoContainer(int posicao)
        {
            if (posicao < 0 || posicao >= limiteItens)
                return "Posição incorreta";

            if (item[posicao] == null || item[posicao].Id == null)
                return $"Essa posição {posicao} está vazia";

            item[posicao] = null;
            return $"Item removido da posição {posicao}";
        }

        public string AdicionarItem(int posicao, Item itemAdd)
        {
            AvaliarPosicaoAtual(posicao);

            if (itemAdd == null)
                return "Item inválido.";

            if (item[posicao] != null && item[posicao].Id != null)
                return $"A posição {posicao} já está ocupada.";

            item[posicao] = itemAdd;
            return $"Item adicionado à posição {posicao}: {itemAdd.Alimento}, {itemAdd.Classificacao}.";
        }

        public static void AvaliarPosicaoAtual(int posicao)
        {
            if (posicao < 0 || posicao >= limiteItens)
                throw new Exception( "Posição incorreta");
        }

        public string AlterarPosicaoItem(int posicaoAtual, int novaPosicao)
        {
            if (posicaoAtual < 0 || posicaoAtual >= limiteItens || novaPosicao < 0 || novaPosicao >= limiteItens)
                return "Posição inválida.";

            if (item[posicaoAtual] == null)
                return $"Não há item na posição {posicaoAtual} para mover.";

            if (item[novaPosicao] != null)
                return $"A posição {novaPosicao} já está ocupada.";

            item[novaPosicao] = item[posicaoAtual];
            item[posicaoAtual] = null;
            return $"Item movido da posição {posicaoAtual} para a posição {novaPosicao}.";
        }

        public void AdicionarItens(List<Item> itens)
        {
            foreach (var itemAdd in itens)
            {
                for (int i = 0; i < item.Count; i++)
                {
                    if (item[i] == null)
                    {
                        item[i] = itemAdd;
                        break;
                    }
                }
            }
        }

        public string ExibirItensContainer()
        {
            var mensagem = "";
            for (int posicao = 0; posicao < limiteItens; posicao++)
            {
                if (item[posicao] != null && item[posicao].Id != null)
                {
                    mensagem += $"Posição {posicao}: {item[posicao].Alimento}, {item[posicao].Quantidade}, {item[posicao].Classificacao}\n";
                }
            }
            return string.IsNullOrEmpty(mensagem) ? "Nenhum item encontrado no container." : mensagem;
        }

        public bool EstaCheio()
        {
            return item.All(i => i != null && i.Id != null);
        }

        public bool EstaVazio()
        {
            return item.All(i => i == null || i.Id == null);
        }

        public void LimparContainer()
        {
            item.Clear();
            for (int i = 0; i < limiteItens; i++)
            {
                item.Add(new Item());
            }
        }
        public string EsvaziarContainer()
        {
            item.Clear();
            return $"Itens removidos dos containers.";
        }

    }
}