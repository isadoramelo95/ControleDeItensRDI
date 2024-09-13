using Domain.Models;

namespace Services.Interfaces
{
    public interface IServices<Item>
    {
        Task<string> AddNaGeladeira(Item item);
        Task<string> AdicionarListaItensGeladeira(List<Item> items);
        Task<string> EditarItemNaGeladeira(Item item);
        Task<string> EsvaziarAndar(int numAndar);
        Item? GetItemById(int id);
        Task<List<Item>> ListaDeItens();
        Task<string> RemoverItembyId(int id);
    }
}
