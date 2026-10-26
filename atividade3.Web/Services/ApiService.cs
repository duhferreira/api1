using System.Net.Http.Json;

namespace atividade3.Web.Services;

public class ApiService
{
    private readonly HttpClient _http;
    public ApiService(HttpClient http) => _http = http;

    public async Task<List<ProdutoDto>> ListarCombustiveis()
        => await _http.GetFromJsonAsync<List<ProdutoDto>>("produtos") ?? new();

    public async Task<List<MenorPrecoDto>> MenorPreco()
        => await _http.GetFromJsonAsync<List<MenorPrecoDto>>("produtos/menor-preco") ?? new();

    public async Task<List<HistoricoDto>> Historico(int produtoId)
        => await _http.GetFromJsonAsync<List<HistoricoDto>>($"produtos/historico/{produtoId}") ?? new();
}

// Os DTOs que estão fazendo falta para limpar os erros do seu Index e MenorPreco:
public class ProdutoDto { public int Id { get; set; } public string Nome { get; set; } public string Categoria { get; set; } }
public class MenorPrecoDto { public string Nome { get; set; } public string Categoria { get; set; } public decimal MenorPreco { get; set; } }
public class HistoricoDto { public DateTime Data { get; set; } public decimal Preco { get; set; } }
