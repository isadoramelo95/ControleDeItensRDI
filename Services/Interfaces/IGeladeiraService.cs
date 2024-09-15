using GeladeiraCodeRDIVersity;

namespace Services.Interfaces
{
    public interface IGeladeiraService<TEntity> where TEntity : class
    {
        void AddNaGeladeira(Item item);
        string AdicionarListaItensGeladeira(List<Item> items);
        string EditarItemNaGeladeira(Item item);
        string EsvaziarPorContainer(int numAndar, int numContainer, int posicao);
        Item? GetItemById(int id);
        List<Item> ListaDeItens();
        string RemoverItembyId(int id);
    }
}
