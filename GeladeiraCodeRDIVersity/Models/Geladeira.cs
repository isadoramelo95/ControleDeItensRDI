namespace Domain.Models
{
    public class Geladeira
    {
        private List<Andar> _andares;
        private const int length = 3;
        public Item Item { get; set; }

        public Geladeira()
        {
            _andares = new List<Andar>();
            for (int i = 0; i < length; i++)
                _andares.Add(new Andar(i));

        }

        public Andar AvaliarAndar(int numAndar)
        {
            if (numAndar < 0 || numAndar >= length)
                throw new Exception("Posição inválida!");
            return _andares[numAndar];
        }


        public string AdicionarItemNaGeladeira(int? numAndar, int numContainer, int? posicao, Item item)
        {
            int andarSelecionado = numAndar ?? 0;

            var andar = AvaliarAndar(andarSelecionado);
            var container = andar.ObterContainer(numContainer);

            if (container == null)
                throw new Exception("Desculpe, não foi adicionado nenhum item!");

            if (posicao.HasValue && posicao.Value >= 0)
            {
                container.AdicionarItem(posicao.Value, item);
            }
            else
            {
                if (!container.EstaCheio())
                {
                    container.AdicionarItens(new List<Item> { item });
                }
                else
                {
                    return "O container não tem espaço suficiente";
                }
            }

            return "Item adicionado com sucesso!";
        }
        public void RemoverItem(int numAndar, int numContainer, int posicao)
        {
            var container = _andares[numAndar].ObterContainer(numContainer);
            container?.RemoverItemDoConatiner(posicao);
        }

        public void LimparGeladeira(int numAndar, int numContainer)
        {
            var container = _andares[numAndar].ObterContainer(numContainer);
            container?.EsvaziarContainer();
        }

        public void ExibirItensNaGeladeira()
        {
            foreach (var andar in _andares)
                andar.ExibirItens();
        }
    }
}
//gerencia os andares

