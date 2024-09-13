using Domain.Interface;

namespace Domain.Models
{
    public class Container : IContainer
    {
        private const int limiteItens = 4;
        public Item _item;
        public Andar _andar;
        public int NumeroDeContainer { get; set; }
        private readonly List<Item> Items;

        public Container(int numeroContainer)
        {
            NumeroDeContainer = numeroContainer;
            Items = new List<Item>();
            _item = new Item();

            LimparContainer();
        }

        public Container()
        {
        }

        public void RemoverItemDoConatiner(int posicao)
        {
            if (posicao < 0 || posicao >= limiteItens)
            {
                Console.WriteLine("Posição incorreta");
                return;
            }
            if (Items[posicao] == null || Items[posicao].Id == null)
            {
                Console.WriteLine($"Essa posição {posicao} vazia");
                return;
            }
            Items[posicao] = null;
            Console.WriteLine($"Item removido da posição {posicao}");
        }

        public string AdicionarItem(int posicao, Item item)
        {
            AvaliarPosicaoAtual(posicao);

            if (item == null)
                return "Item inválido.";

            if (Items[posicao] != null)
                return $"A posição {posicao} já está ocupada.";

                Items[posicao] = item;
           return $"Item adicionado à posição {posicao}: {item.Alimento}, {item.Classificacao}.";
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

            if (Items[posicaoAtual] == null)
                return $"Não há item na posição {posicaoAtual} para mover.";

            if (Items[novaPosicao] != null)
                return $"A posição {novaPosicao} já está ocupada.";

            Items[novaPosicao] = Items[posicaoAtual];
            Items[posicaoAtual] = null;
            return $"Item movido da posição {posicaoAtual} para a posição {novaPosicao}.";
        }

        public void AdicionarItens(List<Item> itens)
        {
            foreach (var item in itens)
            {
                for (int i = 0; i < Items.Count; i++)
                {
                    if (Items[i] == null)
                    {
                        Items[i] = item;
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
                if (posicao >= Items.Count)
                {
                    break;
                }

                var item = Items[posicao];
                if (item != null && item.Id != null)
                {
                    mensagem += $"Posição {posicao}: {item.Alimento}, {item.Quantidade}, {item.Classificacao}\n";
                }
            }
            return string.IsNullOrEmpty(mensagem) ? "Nenhum item encontrado no container." : mensagem;
        }

        public bool EstaCheio()
        {
            return Items.All(item => item != null && item.Id != null);
        }

        public bool EstaVazio()
        {
            return Items.All(item => item == null || item.Id == null);
        }

        public void LimparContainer()
        {
            Items.Clear();
            for (int i = 0; i < limiteItens; i++)
            {
                Items.Add(new Item());
            }
        }

        public string EsvaziarContainer()
        {
            Items.Clear();
            return $"Itens removidos dos containers.";
        }

    }
}
//controla a lista de itens
