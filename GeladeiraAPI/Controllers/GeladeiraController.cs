using GeladeiraCodeRDIVersity;
using Microsoft.AspNetCore.Mvc;

namespace GeladeiraAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GeladeiraController : ControllerBase
    {
        private List<Item> listItems;
        private List<Andar> andarList;

        private readonly Container _container;
        private readonly Andar _andar;
        private readonly Geladeira _geladeira;

        //public class AdicionarItemRequest
        //{
        //    public Geladeira Geladeira { get; set; }
        //    public Container Container { get; set; }
        //    public Andar Andar { get; set; }
        //    public Item Item { get; set; }
        //}

        public GeladeiraController()
        {
            var objItemMorango = new Item() { Id = 1, Alimento = "morango", Quantidade = 1, Unidade = "Cacho", Classificacao = "Hortifruti" };
            var objItemUva = new Item() { Id = 2, Alimento = "Uva", Quantidade = 1, Unidade = "Cacho", Classificacao = "Hortifruti" };
            var objItemTomate = new Item() { Id = 3, Alimento = "Tomate", Quantidade = 1, Unidade = "", Classificacao = "Hortifruti" };
            var objItemBanana = new Item() { Id = 4, Alimento = "Banana", Quantidade = 1, Unidade = "Penca", Classificacao = "Hortifruti" };

            var objItemTomatePelado = new Item() { Id = 5, Alimento = "Tomate Pelado", Quantidade = 1, Unidade = "Lata", Classificacao = "Laticínios e Enlatados" };
            var objItemCremeLeite = new Item() { Id = 6, Alimento = "Creme de Leite", Quantidade = 1, Unidade = "Caixa", Classificacao = "Laticínios e Enlatados" };
            var objItemLeite = new Item() { Id = 7, Alimento = "Leite", Quantidade = 1, Unidade = "Litro", Classificacao = "Laticínios e Enlatados" };

            var objItemBacon = new Item() { Id = 8, Alimento = "Bacon", Quantidade = 1, Unidade = "Kilos", Classificacao = "Charcutaria, Carnes e Ovos" };
            var objItemCarne = new Item() { Id = 9, Alimento = "Carne", Quantidade = 1, Unidade = "kilos", Classificacao = "Charcutaria, Carnes e Ovos" };
            var objItemOvos = new Item() { Id = 10, Alimento = "Ovos", Quantidade = 1, Unidade = "duzia", Classificacao = "Charcutaria, Carnes e Ovos" };

            listItems = new List<Item>() { objItemMorango, objItemUva, objItemTomate, objItemBanana , objItemTomatePelado, objItemCremeLeite,
                objItemLeite,objItemBacon,objItemCarne,objItemOvos};

            andarList = new List<Andar>();

            _container = new Container();
            _andar = new Andar();
            _geladeira = new Geladeira();
        }

        [HttpHead("{id}")]
        public IActionResult CheckItemExists(int id)
        {
            var item = listItems.FirstOrDefault(p => p.Id == id);
            if (item != null)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<Item>> Get()
        {
            if (listItems == null || !listItems.Any())
            {
                return NotFound("Nenhum item encontrado.");
            }
            return Ok(listItems);
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var item = listItems.FirstOrDefault(p => p.Id == id);

            if (item != null)
            {
                int posicao = listItems.IndexOf(item);

                return Ok(new
                {
                    Item = item,
                    Posicao = posicao,
                    Andar = _andar.NumeroAndar,
                    Container = _container.NumeroDeContainer
                });
            }
            else
            {
                return NotFound("Item não encontrado.");
            }
        }

        [HttpPost]

        public IActionResult PostItem([FromBody] Item item)
        {
            if (item.Alimento == null)
            {
                return BadRequest("Preencha o item");
            }

            listItems.Add(item);

            return Ok($"{item} foi adicionado com sucesso");
        }

        [HttpPut("{id}")]
        public ActionResult<List<Item>> PutById(int id, [FromBody] Item value)
        {
            var geladeira = listItems.Where(p => p.Id == id).FirstOrDefault();

            if (geladeira == null)
            {
                NotFound();
                return new List<Item>();
            }

            geladeira.Alimento = value.Alimento;
            geladeira.Quantidade = value.Quantidade;
            geladeira.Unidade = value.Unidade;
            geladeira.Classificacao = value.Classificacao;

            return listItems;
        }

        [HttpPut("Editar")]
        public ActionResult PutByPosition(int andar, int container, int posicaoAtual, int novaPosicao)
        {
            try
            {
                var andarSelecionado = _geladeira.AvaliarAndar(andar);
                if (andarSelecionado == null)
                {
                    return NotFound($"Andar {andar} não encontrado.");
                }

                var containerSelecionado = andarSelecionado.ObterContainer(container);
                if (containerSelecionado == null)
                {
                    return NotFound($"Container {container} não encontrado.");
                }

                var resultado = containerSelecionado.AlterarPosicaoItem(posicaoAtual, novaPosicao);

                if (resultado.Contains("inválida") || resultado.Contains("não existe item") || resultado.Contains("ocupada"))
                {
                    return BadRequest(resultado);
                }

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteById(int id)
        {
            var item = listItems.FirstOrDefault(p => p.Id == id);

            if (item == null || id <= 0)
            {
                return NotFound("Item não encontrado.");
            }

            listItems.Remove(item);
             
            return Ok($"Item com ID {id} foi excluído com sucesso.");
        }

        [HttpDelete("remover")]
        public ActionResult DeleteByPosition(int numAndar, int numContainer, int posicao)
        {
            try
            {
                var andarSelecionado = andarList.FirstOrDefault(a => a.NumeroAndar == numAndar);
                if (andarSelecionado == null)
                {
                    return NotFound($"Andar {numAndar} não encontrado.");
                }

                var containerSelecionado = andarSelecionado.ObterContainer(numContainer);
                if (containerSelecionado == null)
                {
                    return NotFound($"Container {numContainer} não encontrado.");
                }

                containerSelecionado.RemoverItemDoConatiner(posicao);

                return Ok($"Item removido da posição {posicao} no container {numContainer} no andar {numAndar}.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        //[HttpPost("AdicionarItens")]
        //public ActionResult<string> Post([FromBody] AdicionarItemRequest addItem)
        //{
        //    if (addItem == null || addItem.Item == null)
        //    {
        //        return BadRequest("O campo está vazio, por favor adicione um valor");
        //    }
        //    try
        //    {
        //        int andarEscolhido = 0;

        //        var resultado = _geladeira.AdicionarItemNaGeladeira(
        //                andarEscolhido,
        //                addItem.Container.NumeroDeContainer,
        //                addItem.Geladeira.Posicao,
        //                addItem.Item
        //                  );
        //        if (resultado.Contains("não tem espaço suficiente"))
        //        {
        //            return BadRequest(resultado);
        //        }

        //        return Ok("Item adicionado com sucesso.");
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest($"Erro ao adicionar item: {ex.Message}");
        //    }
        //}
    }

}
