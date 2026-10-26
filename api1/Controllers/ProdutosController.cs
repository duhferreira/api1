using api1.Data;
using api1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutosController : ControllerBase
{
    private readonly AppDbContext _db;

    public ProdutosController(AppDbContext db) => _db = db;

    // 1. Listar todos os tipos de combustíveis da AOP2
    [HttpGet]
    public async Task<IActionResult> Listar()
        => Ok(await _db.Produtos.ToListAsync());

    // 2. Buscar o Menor Preço de cada combustível (Igual à sua query SQL!)
    [HttpGet("menor-preco")]
    public async Task<IActionResult> MenorPreco()
    {
        var resultado = await _db.PrecosHistoricos
            .GroupBy(p => p.ProdutoId)
            .Select(g => new
            {
                ProdutoId = g.Key,
                MenorPreco = g.Min(x => x.Preco)
            })
            .Join(_db.Produtos,
                x => x.ProdutoId,
                p => p.Id,
                (x, p) => new
                {
                    p.Nome,
                    p.Categoria,
                    x.MenorPreco
                })
            .ToListAsync();

        return Ok(resultado);
    }

    // 3. Buscar o Histórico de Coletas de um combustível específico (Para alimentar o gráfico)
    [HttpGet("historico/{produtoId:int}")]
    public async Task<IActionResult> Historico(int produtoId)
    {
        var dados = await _db.PrecosHistoricos
            .Where(p => p.ProdutoId == produtoId)
            .OrderBy(p => p.Data)
            .Select(p => new { p.Data, p.Preco })
            .ToListAsync();

        return Ok(dados);
    }
}
