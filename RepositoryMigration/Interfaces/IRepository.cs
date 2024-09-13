using Domain.Models;

namespace Repository.Interfaces
{
    public interface IRepository<Item>
    {
        Task EditarItemNaGeladeira(Item item);
        Task AddNaGeladeira(Item item);
        Task<List<Item>> ListaDeItens();
        Task RemoverItembyId(int id);
        Item? GetItemById(int id);
        bool ValidarItemExistente (int id);
    }
}
