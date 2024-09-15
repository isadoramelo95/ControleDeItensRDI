using GeladeiraCodeRDIVersity;

namespace GeladeiraRepository.Interfaces
{
    public interface IGeladeiraRepository<TEntity> where TEntity : class
    {
        void EditarItemNaGeladeira(Item item);
        void AddNaGeladeira(Item item);
        List<TEntity> ListaDeItens();
        void RemoverItembyId(int id);
        Item? GetItemById(int id);
        bool ValidarItemExistente(int id);
    }
}
