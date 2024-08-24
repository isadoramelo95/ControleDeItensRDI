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

        public GeladeiraController()
        {
            var objItemMorango = new Item() { Id = 1, Alimento = "morango", Quantidade = 1, Unidade = "Cacho", Classificacao = "Hortifruti" };
            var objItemUva = new Item() { Id = 2, Alimento = "Uva", Quantidade = 1, Unidade = "Cacho", Classificacao = "Hortifruti" };
            var objItemTomate = new Item() { Id = 3, Alimento = "Tomate", Quantidade = 1, Unidade = "", Classificacao = "Hortifruti" };
            var objItemBanana = new Item() { Id = 4, Alimento = "Banana", Quantidade = 1, Unidade = "Penca", Classificacao = "Hortifruti" };

            var objItemTomatePelado = new Item() { Id = 5, Alimento = "Tomate Pelado", Quantidade = 1, Unidade = "Lata", Classificacao = "Latic�nios e Enlatados" };
            var objItemCremeLeite = new Item() { Id = 6, Alimento = "Creme de Leite", Quantidade = 1, Unidade = "Caixa", Classificacao = "Latic�nios e Enlatados" };
            var objItemLeite = new Item() { Id = 7, Alimento = "Leite", Quantidade = 1, Unidade = "Litro", Classificacao = "Latic�nios e Enlatados" };

            var objItemBacon = new Item() { Id = 8, Alimento = "Bacon", Quantidade = 1, Unidade = "Kilos", Classificacao = "Charcutaria, Carnes e Ovos" };
            var objItemCarne = new Item() { Id = 9, Alimento = "Carne", Quantidade = 1, Unidade = "kilos", Classificacao = "Charcutaria, Carnes e Ovos" };
            var objItemOvos = new Item() { Id = 10, Alimento = "Ovos", Quantidade = 1, Unidade = "duzia", Classificacao = "Charcutaria, Carnes e Ovos" };

            listItems = new List<Item>() { objItemMorango, objItemUva, objItemTomate, objItemBanana , objItemTomatePelado, objItemCremeLeite,
                objItemLeite,objItemBacon,objItemCarne,objItemOvos};

            andarList = new List<Andar>();

            _container = new Container();
            _andar = new Andar();
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
                Console.WriteLine("A lista de itens est� vazia ou nula.");
                return NotFound("Nenhum item encontrado.");
            }

            Console.WriteLine($"Itens encontrados: {listItems.Count}");
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
                return NotFound("Item n�o encontrado.");
            }
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
                var andarSelecionado = _andar.ObterContainer(andar);
                if (andarSelecionado == null)
                {
                    return NotFound($"Andar {andar} n�o encontrado.");
                }

                var containerSelecionado = _andar.ObterContainer(container);
                if (containerSelecionado == null)
                {
                    return NotFound($"Container {container} n�o encontrado.");
                }

                containerSelecionado.AlterarPosicaoItem(posicaoAtual, novaPosicao);

                return Ok($"Item movido da posi��o {posicaoAtual} para a posi��o {novaPosicao} no container {container} no andar {andar}.");
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
                return NotFound("Item n�o encontrado.");
            }

            listItems.Remove(item);

            return Ok($"Item com ID {id} foi exclu�do com sucesso.");
        }

        [HttpDelete("remover")]
        public ActionResult DeleteByPosition(int numAndar, int numContainer, int posicao)
        {
            try
            {
                var andarSelecionado = andarList.FirstOrDefault(a => a.NumeroAndar == numAndar);
                if (andarSelecionado == null)
                {
                    return NotFound($"Andar {numAndar} n�o encontrado.");
                }

                var containerSelecionado = andarSelecionado.ObterContainer(numContainer);
                if (containerSelecionado == null)
                {
                    return NotFound($"Container {numContainer} n�o encontrado.");
                }

                containerSelecionado.RemoverItemDoConatiner(posicao);

                return Ok($"Item removido da posi��o {posicao} no container {numContainer} no andar {numAndar}.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}
