using GeladeiraCodeRDIVersity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RepositoryMigration;
using System.ComponentModel;
using System.Linq;

namespace Services
{
    public class GeladeiraService
    {
        GeladeiraContext _contexto;
        public GeladeiraService(GeladeiraContext contexto)
        {
            _contexto = contexto;
        }

        public string AddNaGeladeira(Item item)
        {
            try
            {
                //_contexto.Database.BeginTransaction();

                if (item != null)
                {
                    var itemnageladeira = GetItemById((int)item.Id);

                    if (itemnageladeira != null)
                    {
                        if (itemnageladeira.Alimento == item.Alimento
                            && itemnageladeira.NumeroAndar == item.NumeroAndar
                            && itemnageladeira.NumeroContainer == item.NumeroContainer
                            && itemnageladeira.Classificacao == item.Classificacao
                            && itemnageladeira.Id == (int)item.Id)
                        {
                            return "item existente no sistema!";
                        }
                    }

                    if (itemnageladeira == null)
                    {
                        var item_entity = new Item()
                        {
                            Alimento = item.Alimento
                        ,
                            Classificacao = item.Classificacao
                        ,
                            NumeroContainer = item.NumeroContainer
                        ,
                            NumeroAndar = item.NumeroAndar
                        ,
                            Posicao = item.Posicao
                        ,
                            Quantidade = item.Quantidade
                        ,
                            Unidade = item.Unidade
                        };

                        _contexto.Add(item_entity);
                        _contexto.SaveChanges();
                        _contexto.Database.CommitTransaction();

                        if (item == null || item.Id <= 0 || string.IsNullOrEmpty(item.Alimento))
                        {
                            return "Item inválido! O nome do alimento e ID são obrigatórios.";
                        }

                    }
                    else
                        return "erro ao cadastrar!";
                }
                return "item cadastrado com sucesso na geladeira!";
            }
            catch (SqlException)
            {
                _contexto.Database.RollbackTransaction();
                return "não foi possível se comunicar com a base de dados!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string AdicionarListaItensGeladeira(List<Item> items)
        {
            _contexto.Database.BeginTransaction();
            foreach (Item item in items)
            {
                var itensContainer = _contexto.Items.Where(c => c.Id == item.Id
                && c.NumeroAndar == item.NumeroAndar
                && c.NumeroContainer == item.NumeroContainer).ToList();

                if (itensContainer is not null)
                    AddNaGeladeira(item);

                else
                    throw new Exception("Container já está cheio!");
            }

            return "Itens adicionados com sucesso!";
        }
        public Item? GetItemById(int id)
        {
            var item = new Item();

            try
            {
                if (id <= 0)
                {
                    return null;
                }

                item.Id = id;
                return _contexto.Items.SingleOrDefault(x => x.Id == id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Item>? ListaDeItens()
        {
            try
            {
                return _contexto.Items.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string EditarItemNaGeladeira(Item item)
        {
            try
            {
                if (item == null)
                {
                    return "O item é nulo.";
                }

                if (item != null)
                {
                    if (item.Id == null || item.Id <= 0)
                    {
                        return "O ID do item é inválido!";
                    }

                    if (string.IsNullOrEmpty(item.Alimento))
                    {
                        return "O nome do alimento é obrigatório!";
                    }

                    var itemGeladeiraAtual = GetItemById((int)item.Id);

                    if (itemGeladeiraAtual is null)
                    {
                        return "Item não encontrado na geladeira!";
                    }

                    itemGeladeiraAtual.Alimento = item.Alimento;
                    itemGeladeiraAtual.NumeroAndar = item.NumeroAndar;
                    itemGeladeiraAtual.NumeroContainer = item.NumeroContainer;
                    itemGeladeiraAtual.Posicao = item.Posicao;
                    itemGeladeiraAtual.Quantidade = item.Quantidade;
                    itemGeladeiraAtual.Classificacao = item.Classificacao;
                    itemGeladeiraAtual.Unidade = item.Unidade;

                    _contexto.Update(itemGeladeiraAtual);
                    _contexto.SaveChanges();

                    return "Item alterado com sucesso!";
                }
                else
                {
                    return "Item inválido!";
                }
            }
            catch (SqlException)
            {
                return "Não foi possível se comunicar com a base de dados!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string RemoverItembyId(int id)
        {
            try
            {
                if (id == 0)
                {
                    return "ID do item inválido!";
                }
                else
                {
                    var item = GetItemById(id);

                    if (item != null)
                    {
                        _contexto.Items.Remove(item);
                        _contexto.SaveChanges();

                        return $"O item '{item.Alimento}' foi removido!";
                    }
                    else
                    {
                        return "Item não encontrado no sistema!";
                    }
                }
            }
            catch (SqlException)
            {
                return "Não foi possível se comunicar com a base de dados!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        //public string EsvaziarGeladeira(List<int> id)
        //{
        //    if (id.Any())
        //    {
        //        var itensParaRemover = _contexto.Items
        //            .Where(i => id.Contains((int)i.Id))
        //            .ToList();

        //        if (itensParaRemover.Any())
        //        {
        //            _contexto.Items.RemoveRange(itensParaRemover);
        //            _contexto.SaveChanges();
        //            return "Container esvaziado com sucesso!";
        //        }
        //        else
        //        {
        //            return "Nenhum item encontrado para remover!";
        //        }
        //    }
        //    else
        //    {
        //        return "Lista de IDs está vazia!";
        //    }
        //}
    }
}