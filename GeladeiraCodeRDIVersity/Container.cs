using Domain;

namespace GeladeiraCodeRDIVersity
{
    public class Container : IContainer
    {
        private const int limiteItens = 4;
        private readonly List<Item> _itens;

        public int NumeroDeContainer { get; set; }
        public int posicaoAtual { get; set; }

        public Container(int numeroContainer, int capacidade = limiteItens)
        {
            NumeroDeContainer = numeroContainer;
            _itens = new List<Item?>(new Item?[capacidade]);
        }

        public Container()
        {
        }

        public string RemoverItemDoConatiner(int posicao)
        {
            if (posicao < 0 || posicao >= limiteItens)
            return ("Posição incorreta");

            if (_itens[posicao] == null || _itens[posicao].Id == null)
            return ($"Essa posição {posicao} vazia");

            _itens[posicao] = null;
            return ($"Item removido da posição {posicao}");
        }

        public string AdicionarItem(int posicao, Item item)
        {
            if (posicao < 0 || posicao >= limiteItens)
                return ("Posição inválida.");

            if (item == null)
                return ("Item inválido.");

            if (_itens[posicao] != null)
                return ($"A posição {posicao} já está ocupada.");

            _itens[posicao] = item;
            return ($"Item adicionado à posição {posicao}: {item.Alimento}, {item.ClassificacaoDoAndar}.");
        }

        public string AlterarPosicaoItem(int posicaoAtual, int novaPosicao)
        {
            if (posicaoAtual < 0 || posicaoAtual >= limiteItens || novaPosicao < 0 || novaPosicao >= limiteItens)
                return "Posição inválida.";

            if (_itens[posicaoAtual] == null)
                return $"Não há item na posição {posicaoAtual} para mover.";

            if (_itens[novaPosicao] != null)
                return $"A posição {novaPosicao} já está ocupada.";

            _itens[novaPosicao] = _itens[posicaoAtual];
            _itens[posicaoAtual] = null;
            return $"Item movido da posição {posicaoAtual} para a posição {novaPosicao}.";
        }

        // add lista
        public void AdicionarItens(List<Item> itens)
        {
            foreach (var item in itens)
            {
                for (int i = 0; i < _itens.Count; i++)
                {
                    if (_itens[i] == null)
                    {
                        _itens[i] = item;
                        break;
                    }
                }
            }
        }

        public string ExibirItens()
        {
            for (int posicao = 0; posicao < limiteItens; posicao++)
            {
                var item = _itens[posicao];
                if (item != null)
                {
                    return ($"Posição {posicao}: {item.Alimento}, {item.Quantidade}, {item.ClassificacaoDoAndar}");
                }
            }
            return "Nenhum item encontrado no container.";
        }

        public bool EstaCheio()
        {
            return _itens.All(item => item != null && item.Id != null);
        }

        public bool EstaVazio()
        {
            return _itens.All(item => item == null || item.Id == null);
        }

        public string EsvaziarGeladeira()
        {
            _itens.Clear();
            return ($"Itens removidos dos containers.");
        }

    }
}
//controla a lista de itens
