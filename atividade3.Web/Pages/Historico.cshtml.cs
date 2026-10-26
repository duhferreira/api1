using atividade3.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace atividade3.Web.Pages;

public class HistoricoModel : PageModel
{
    private readonly ApiService _apiService;
    public string JsonDados { get; set; } = "[]";
    public int CombustivelId { get; set; }

    public HistoricoModel(ApiService apiService) => _apiService = apiService;

    public async Task<IActionResult> OnGetAsync(int id)
    {
        if (id <= 0) return RedirectToPage("/Index");
        CombustivelId = id;

        // Consome o endpoint histórico que você configurou ontem na API
        var dados = await _apiService.Historico(id);
        JsonDados = JsonSerializer.Serialize(dados);
        return Page();
    }
}
