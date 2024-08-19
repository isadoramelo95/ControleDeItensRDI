using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeladeiraCodeRDIVersity
{
    public class Container : IContainer
    {

        private const int LimiteItens = 4;
        private readonly List<Item> _itens;

        public int NumeroDeContainer { get; private set; }

        public Container(int numeroContainer, int capacidade = LimiteItens)
        {
            NumeroDeContainer = numeroContainer;
            _itens = new List<Item>();

            InicializarItens(capacidade);
        }

        private void InicializarItens(int capacidade)
        {
            for (int i = 0; i < capacidade; i++)
                _itens.Add(new Item());
        }

        private void ValidarPosicao(int posicao)
        {
            if (posicao < 0 || posicao >= LimiteItens)
                throw new Exception("Posição inválida!");
        }

        public void ColocarItem(int posicao, Item item)
        {
            ValidarPosicao(posicao);

            if (_itens[posicao] != null && _itens[posicao].Id != null)
            {
                Console.WriteLine($"Essa posição {posicao} está ocupada");
                return;
            }

            _itens[posicao] = item;
        }

        public void RemoverItem(int posicao)
        {
            ValidarPosicao(posicao);

            if (_itens[posicao] == null || _itens[posicao].Id == null)
            {
                Console.WriteLine($"Essa posição {posicao} foi removida e está vazia!");
                return;
            }

            _itens[posicao] = new Item();
        }

        public void RemoverTodosItens()
        {
            _itens.Clear();
            Console.WriteLine($"Itens removidos dos containers.");
        }

        public bool EstaCheio()
        {
            return _itens.All(item => item != null && item.Id != null);
        }

        public bool EstaVazio()
        {
            return _itens.All(item => item == null || item.Id == null);
        }

        public void LimparContainer()
        {
            InicializarItens(LimiteItens);
        }

        public void AdicionarItens(List<Item> itens)
        {
            if (itens.Count > LimiteItens)
            {
                Console.WriteLine($"A geladeira não comporta este item no momento.");
                return;
            }

            int posicao = 0;
            foreach (var item in itens)
            {
                while (posicao < LimiteItens && _itens[posicao].Id != null)
                    posicao++;

                if (posicao < LimiteItens)
                    _itens[posicao] = item;
                else
                {
                    Console.WriteLine("O container está cheio!");
                    break;
                }
            }
        }

        public void ExibirItens()
        {
            Console.WriteLine($"Container {NumeroDeContainer}:");
            for (int posicao = 0; posicao < LimiteItens; posicao++)
            {
                var item = _itens[posicao];
                if (item != null && item.Id != null)
                    Console.WriteLine($"Posição {posicao}: {item.Classificacao}");
            }
        }
    }
}



//controla a lista de itens