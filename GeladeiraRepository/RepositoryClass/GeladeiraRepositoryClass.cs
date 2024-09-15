using GeladeiraCodeRDIVersity;
using Microsoft.Data.SqlClient;
using GeladeiraRepository.Interfaces;
using Microsoft.EntityFrameworkCore;
using GeladeiraRepository.Context;

namespace GeladeiraRepository.RepositoryClass
{
    public class GeladeiraRepositoryClass : IGeladeiraRepository<Item>
    {
        GeladeiraContext _context;

        public GeladeiraRepositoryClass(GeladeiraContext context)
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
        public List<Item> ListaDeItens() => _context.Items.ToList();

        public void AddNaGeladeira(Item item)
        {
            _context.Database.BeginTransaction();

            try
            {
                _context.Items.Add(item);
                _context.SaveChanges();
            }
            catch (SqlException ex)
            {
                throw new Exception($"Erro ao inserir item na geladeira: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao inserir item na geladeira: {ex.Message}");
            }
        }

        public void RemoverItembyId(int id)
        {
            try
            {
                var item = _context.Items.Find(id);

                if (item != null)
                {
                    _context.Remove(item);
                    _context.SaveChanges();
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

        public void EditarItemNaGeladeira(Item item)
        {
            try
            {
                _context.Update(item);
                _context.SaveChanges();
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
