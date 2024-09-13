using Domain.Models;

namespace Domain.Interface
{
    public interface IContainer
    {
        void RemoverItemDoConatiner(int posicao);
        string AdicionarItem(int posicao, Item item);
        void AdicionarItens(List<Item> itens);
        string EsvaziarContainer();
        bool EstaCheio();
        bool EstaVazio();
    }
}
