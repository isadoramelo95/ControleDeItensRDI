namespace Domain.Models
{
    public class Andar
    {
        private readonly List<Container> _containers;

        public int NumeroAndar { get; private set; }

        public Andar()
        {
        }
        public Andar(int numeroAndar, int qntContainers = 2)
        {
            NumeroAndar = numeroAndar;
            _containers = new List<Container>();

            for (int i = 0; i < qntContainers; i++)
                _containers.Add(new Container(i));
        }

        public void AvaliarAndares(int numAndar, List<Andar> lstAndares)
        {
            if (numAndar < 0 || numAndar >= lstAndares.Count)
                throw new Exception("Numero do andar inválido!");
        }
        public Container? ObterContainer(int numeroContainer) =>
        _containers.FirstOrDefault(container => container.NumeroDeContainer == numeroContainer);

        public string ExibirItens()
        {
            var mensagem = $"Andar {NumeroAndar}:\n";
            foreach (var container in _containers)
            {
                var containerItens = container.ExibirItensContainer();
                mensagem += containerItens + "\n";
            }
            return mensagem;
        }
    }
}
