using GeladeiraCodeRDIVersity;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace GeladeiraAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GeladeiraController : ControllerBase
    {
        IGeladeiraService<Item> _services;
        public GeladeiraController(IGeladeiraService<Item> services)
        {
            _services = services;
        }

        [HttpHead("{id}")]
        public IActionResult CheckStatusGeladeira()
        {
            List<Item> Items = _services.ListaDeItens();
            Response.Headers.Append("Total", Items.Count.ToString());
            return Ok();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Item>> GetListaItens()
        {
            try
            {
                _services.ListaDeItens();
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            try
            {
                var item = _services.GetItemById(id);

                return Ok(item);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]

        public IActionResult PostItem([FromBody] Item item)
        {
            try
            {
                _services.AddNaGeladeira(item);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("AtualizarItem")]
        public ActionResult<List<Item>> PutById([FromBody] Item item)
        {
            try
            {
                _services.EditarItemNaGeladeira(item);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteById(int id)
        {
            try
            {
                var item = _services.GetItemById(id);

                if (item == null)
                    return NotFound();

                _services.RemoverItembyId(id);

                return Ok("Item retirado da geladeira!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("remover")]
        public ActionResult EsvaziarPorContainer(int numAndar, int numContainer, int posicao)
        {
            try
            {
                return Ok(_services.EsvaziarPorContainer(numAndar, numContainer, posicao));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("AdicionarItensPorLista")]
        public ActionResult<string> Post([FromBody] List<Item> items)
        {
            if (items == null || !items.Any())
            {
                return BadRequest("A lista de itens não pode ser nula ou vazia.");
            }
            try
            {
                return Ok(_services.AdicionarListaItensGeladeira(items));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}
