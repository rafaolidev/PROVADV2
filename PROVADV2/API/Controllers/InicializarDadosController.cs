using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/inicializar")]
    public class InicializarDadosController : ControllerBase
    {
        private readonly DataContext _context;
        public InicializarDadosController(DataContext context)
        {
            _context = context;
        }

        //POST: api/inicializar/create
        [HttpPost]
        [Route("create")]
        public IActionResult Create()
        {
            _context.Categorias.AddRange(new Categoria[]
                {
                    new Categoria { CategoriaId = 1, Nome = "Jogos" },
                    new Categoria { CategoriaId = 2, Nome = "Periféricos" },
                }
            );
            _context.Produtos.AddRange(new Produto[]
                {
                    new Produto { ProdutoId = 1, Nome = "Kenshi", Preco = 24, Quantidade = 3, CategoriaId = 1, Genero = "Simulação Sandbox"},
                    new Produto { ProdutoId = 2, Nome = "Sims 4", Preco = 100, Quantidade = 1, CategoriaId = 1, Genero = "Simulação"},
                    new Produto { ProdutoId = 3, Nome = "Fone JBL", Preco = 380, Quantidade = 8, CategoriaId = 2, Genero = "",},
                }
            );
            _context.Pagamentos.AddRange(new Pagamento[]
                {
                    new Pagamento { PagamentoId = 1, Forma = "Cartão de Credito", Desconto = 0, Juros = 2},
                    new Pagamento { PagamentoId = 2, Forma = "Pix", Desconto = 10, Juros = 0},
                }
            );
            _context.SaveChanges();
            return Ok(new { message = "Dados inicializados com sucesso!" });
        }
    }
}