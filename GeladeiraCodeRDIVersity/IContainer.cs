using GeladeiraCodeRDIVersity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface IContainer
    {
        void ColocarItem(int posicao, Item item);
        void RemoverItem(int posicao);
        void LimparContainer();
        void AdicionarItens(List<Item> itens);
        bool EstaCheio();
        bool EstaVazio();
    }
}
