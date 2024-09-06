using GeladeiraCodeRDIVersity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryMigration;
using Services;
using System.ComponentModel;

namespace GeladeiraAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GeladeiraController : ControllerBase
    {
        GeladeiraService _service;
        private readonly GeladeiraContext _contexto;

        public GeladeiraController(GeladeiraContext contexto)
        {
            _contexto = contexto;
            _service = new GeladeiraService(_contexto);
        }

        [HttpHead]
        public IActionResult CheckStatusGeladeira()
        {
            var count = _contexto.Items.Count();
            Response.Headers.Append("Total", count.ToString());
            return Ok();
        }

        [HttpGet("ListaItens")]
        public ActionResult<IEnumerable<Item>> GetListaItens()
        {
            try
            {
                return Ok(_service.ListaDeItens());
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
                var item = _service.GetItemById(id);

                return Ok(item);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("AdicionarItem")]
        public IActionResult PostItem([FromBody] Item item)
        {
            try
            {
                _service.AddNaGeladeira(item);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddLista")]
        public IActionResult PostList([FromBody] List<Item> items)
        {
            if (items == null || !items.Any())
            {
                return BadRequest("A lista de itens não pode ser nula ou vazia.");
            }
            try
            {
                return Ok(_service.AdicionarListaItensGeladeira(items));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("AtualizarItem")]
        public IActionResult PutById([FromBody] Item item)
        {
            try
            {
                _service.EditarItemNaGeladeira(item);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return null;
        }

        [HttpDelete("RemoverPorId")]
        public ActionResult DeleteById(int id)
        {
            try
            {
                var item = _service.GetItemById(id);

                if (item == null)
                    return NotFound();

                _service.RemoverItembyId(id);

                return Ok("Item retirado!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[HttpDelete("EsvaziarGeladeira")]
        //public ActionResult EsvaziarGeladeiraCompleta([FromBody] List<int> id)
        //{
        //    try
        //    {
        //        var resultado = _service.EsvaziarGeladeira(id);
        //        return Ok(resultado);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

    }

}
