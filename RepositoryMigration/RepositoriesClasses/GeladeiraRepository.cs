using Domain.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Interfaces;

namespace Repository.RepositoriesClasses
{
    public class GeladeiraRepository : IRepository<Item>
    {
        GeladeiraContext _context;

        public GeladeiraRepository(GeladeiraContext context)
        {
            _context = context;
        }

        public Item? GetItemById(int id)
        {
            try
            {
                var itemPorId = _context.Items.Where(i => i.Id == id).ToList();
                return itemPorId != null ? itemPorId.FirstOrDefault() : null;
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<List<Item>> ListaDeItens() => await _context.Items.ToListAsync();

        public async Task AddNaGeladeira(Item item)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    await _context.Items.AddAsync(item);
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch (SqlException ex)
                {
                    await transaction.RollbackAsync();
                    throw new Exception($"Erro ao inserir item na geladeira: {ex.Message}");
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw new Exception($"Erro ao inserir item na geladeira: {ex.Message}");
                }
            }
        }

        public async Task RemoverItembyId(int id)
        {
            try
            {
                var item = await _context.Items.FindAsync(id);

                if (item != null)
                {
                    _context.Remove(item);
                    await _context.SaveChangesAsync();
                }
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task EditarItemNaGeladeira(Item item)
        {
            try
            {
                _context.Entry(item).State = EntityState.Modified;

                _context.Update(item);
                await _context.SaveChangesAsync();
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool ValidarItemExistente(int id) => _context.Items.Any(e => e.Id == id);

    }

}
