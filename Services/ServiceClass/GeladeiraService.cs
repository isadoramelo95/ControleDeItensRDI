using GeladeiraCodeRDIVersity;
using System.Data.SqlClient;
using Services.Interfaces;
using GeladeiraRepository.Interfaces;

namespace Services.ServiceClass
{
    public class GeladeiraService : IGeladeiraService<Item>
    {
        IGeladeiraRepository<Item> _repository;
        public GeladeiraService(IGeladeiraRepository<Item> repository) =>
            _repository = repository;

        public void AddNaGeladeira(Item item)
        {
            _repository.AddNaGeladeira(item);
        }

        private bool ValidarItemExistente(Item item)
        {
            var listaItensExistentes = ListaDeItens();

            if (listaItensExistentes == null || !listaItensExistentes.Any())
                return false;

            listaItensExistentes = listaItensExistentes?.Where(i => i.NumeroContainer == item.NumeroContainer
                                                                                        && i.NumeroAndar == item.NumeroAndar
                                                                                        && i.Posicao == item.Posicao
                                                                                        && i.Id == item.Id).ToList();
            var itemValidado = listaItensExistentes?.FirstOrDefault();

            return itemValidado != null;

        }

        public string AdicionarListaItensGeladeira(List<Item> items)
        {
            foreach (Item item in items)
            {
                var itensContainer = ListaDeItens();

                itensContainer = itensContainer?.Where(c => c.NumeroAndar == item.NumeroAndar
                                                                             && c.NumeroContainer == item.NumeroContainer).ToList();

                if (itensContainer is not null)
                    _repository.AddNaGeladeira(item);

                else
                    throw new Exception("Container já está cheio!");
            }

            return "Itens adicionados com sucesso!";
        }
        public Item? GetItemById(int id)
        {
            Item? item = new Item();
            try
            {
                if (id <= 0)
                    return null;

                item.Id = id;
                return _repository.GetItemById(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Item> ListaDeItens() =>
           _repository.ListaDeItens();

        public string EditarItemNaGeladeira(Item item)
        {
            try
            {
                if (item != null)
                {
                    _repository.EditarItemNaGeladeira(item);

                    return "Item alterado com sucesso!";
                }
                else
                    return "Item inválido!";
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
                    throw new Exception("ID do item inválido ou incorreto! Tente novamente.");
                else
                {
                    _repository.RemoverItembyId(id);

                    return "Item exclído com sucesso!";
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

        public string EsvaziarPorContainer(int numAndar, int numContainer, int posicao)
        {
            var andar = ListaDeItens();

            andar = andar?.Where(a => a.NumeroAndar == numAndar
            && a.NumeroContainer == numContainer
            && a.Posicao == posicao).ToList();

            if (andar != null)
            {
                foreach (var item in andar)
                {
                    _repository.RemoverItembyId((int)item.Id);
                }
            }
            else
                throw new Exception("Andar selecionado está vazio");

            return "Andar esvaziado com sucesso!";
        }

        public bool AvaliarItem(int id) =>
            _repository.ValidarItemExistente(id);

    }
}