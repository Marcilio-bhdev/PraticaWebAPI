using Microsoft.AspNetCore.Mvc;
using ProdutosWebAPI.Models;
using System.Collections.Generic;

namespace ProdutosWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        static readonly IProdutoRepositorio repositorio = new ProdutoRepositorio();

        [HttpGet]
        public IEnumerable<Produto> GetTodos() 
        {
            return repositorio.GetALL();
        
        }

        [HttpGet("{id}", Name ="GetProduto")]
        public IActionResult GetProdutoId(int id)
        {
            Produto produto = repositorio.GetById(id);
            if (produto == null)
            {
                return NotFound();
            }
            return new ObjectResult(produto);
        }

        [HttpPost]
        public IActionResult CriarProduto([FromBody] Produto item) 
        {
            if (item == null)
            {
                return BadRequest();
            }
            item = repositorio.Add(item);
            return CreatedAtRoute("GetProduto", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarProduto(int id, [FromBody] Produto item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            item.Id = id;
            if (!repositorio.Update(item))
            {
                return NotFound();
            }
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaProduto(int id) 
        {
            Produto item = repositorio.GetById(id);
            if (item == null)
            {
                return BadRequest();
            }
            repositorio.Remove(id);
            return new NoContentResult();
        }
    }
}