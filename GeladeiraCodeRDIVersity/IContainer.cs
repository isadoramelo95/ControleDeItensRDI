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
         void RemoverItemDoConatiner(int posicao);
        void AdicionarItem(int posicao, Item item);
        void AdicionarItens(List<Item> itens);
        void EsvaziarGeladeira();
        bool EstaCheio();
        bool EstaVazio();
    }
}
