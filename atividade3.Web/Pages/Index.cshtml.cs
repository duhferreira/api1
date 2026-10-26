using atividade3.Web.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace atividade3.Web.Pages;

public class IndexModel : PageModel
{
    private readonly ApiService _apiService;
    public List<ProdutoDto> Combustiveis { get; set; } = new();

    public IndexModel(ApiService apiService) => _apiService = apiService;

    public async Task OnGetAsync()
    {
        Combustiveis = await _apiService.ListarCombustiveis();
    }
}
