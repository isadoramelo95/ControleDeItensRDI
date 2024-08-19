namespace GeladeiraCodeRDIVersity
{
    public class Geladeira
    {
        private List<Andar> _andares;

        public Geladeira(int numAndares = 3)
        {
            _andares = new List<Andar>();

            for (int i = 0; i < numAndares; i++)
                _andares.Add(new Andar(i));
        }

        private Andar AvaliarAndar(int numAndar)
        {
            if (numAndar < 0 || numAndar >= _andares.Count)
                throw new Exception("Não foi encontrado o numero do andar");

            return _andares[numAndar];
        }

        public void AdicionarItemNaGeladeira(int numAndar, int numContainer, int? posicao, Item item)
        {
            var andar = AvaliarAndar(numAndar);
            var container = andar.ObterContainer(numContainer);

            if (container == null)
                throw new Exception("Desculpe, número do container é incorreto!");

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
                    Console.WriteLine("O container não tem espaço suficiente");
                }
            }

        }
        public void RemoverItem(int numAndar, int numContainer, int posicao)
        {
            var container = _andares[numAndar].ObterContainer(numContainer);
            container?.RemoverItemDoConatiner(posicao);
        }

        public void LimparContainer(int numAndar, int numContainer)
        {
            var container = _andares[numAndar].ObterContainer(numContainer);
            container?.EsvaziarGeladeira();
        }

        public void ExibirItens()
        {
            foreach (var andar in _andares)
                andar.ExibirItens();
        }
    }
}
//gerencia os andares

//subir no git
