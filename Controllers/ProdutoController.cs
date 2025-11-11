using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApiProdutos.Data;
using WebApiProdutos.Models;

namespace WebApiProdutos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {

        private readonly AppDbContext _context;
        public ProdutoController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public ActionResult<List<ProdutoModel>> BuscarProdutos()
        {
            var produtos = _context.Produtos.ToList();
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public ActionResult<ProdutoModel> BuscarProdutoPorId(int id)
        {
            var produto = _context.Produtos.Find(id);

            if (produto == null)
            {
                return NotFound("Registro não Localizado");
            }

            return Ok(produto);
        }

        [HttpPost]
        public ActionResult<ProdutoModel> CriarProduto(ProdutoModel ProdutoModel)
        {
            if (ProdutoModel == null)
            {
                return BadRequest("Ocorreu um erro na solicitação!");
            }

            _context.Produtos.Add(ProdutoModel);
            _context.SaveChanges();


            return CreatedAtAction(nameof(BuscarProdutoPorId), new { id = ProdutoModel.Id }, ProdutoModel);
        }


        [HttpPut("{id}")]
        public ActionResult<ProdutoModel> EditarProduto(ProdutoModel ProdutoModel, int id)
        {
            var produto = _context.Produtos.Find(id);

            if (produto == null)
            {
                return NotFound("Resgistro não localizado!");
            }

            produto.Nome = ProdutoModel.Nome;
            produto.Descricao = ProdutoModel.Descricao;
            produto.Marca = ProdutoModel.Marca;
            produto.QuantidadeEstoque = ProdutoModel.QuantidadeEstoque;


            _context.Produtos.Update(produto);
            _context.SaveChanges();

            return NoContent();

        }

        [HttpDelete("{id}")]

        public ActionResult<ProdutoModel> DeletarProduto(int id)
        {
            var produto = _context.Produtos.Find(id);

            if (produto == null)
            {
                return NotFound("Registro não localiazdo! ");
            }

            _context.Produtos.Remove(produto);
            _context.SaveChanges();

            return NoContent();
        }
    }
}