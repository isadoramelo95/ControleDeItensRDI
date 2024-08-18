using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeladeiraCodeRDIVersity
{
    public class Andar
    {
            private readonly List<Container> _containers;

            public int NumeroAndar { get; private set; }

            public Andar(int numeroAndar, int qntContainers = 2)
            {
                NumeroAndar = numeroAndar;
                _containers = new List<Container>();

                for (int i = 0; i < qntContainers; i++)
                    _containers.Add(new Container(i));
            }

            public Container? ObterContainer(int qtContainers) =>
                _containers?.FirstOrDefault(container => container.NumeroDeContainer == qtContainers);

            public void ExibirItens()
            {
                Console.WriteLine($"Andar {NumeroAndar}:");
                foreach (var container in _containers)
                    container.ExibirItens();
            }
        }
    }

//os andares são 3: hortifruit, laticínios e enlatados, charcutaria, carnes e ovos
//gerencia a lista containers
