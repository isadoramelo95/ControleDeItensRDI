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
        string RemoverItemDoConatiner(int posicao);
        string AdicionarItem(int posicao, Item item);
        void AdicionarItens(List<Item> itens);
        string EsvaziarGeladeira();
        bool EstaCheio();
        bool EstaVazio();
    }
}
