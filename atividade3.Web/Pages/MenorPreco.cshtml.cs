using atividade3.Web.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;

namespace atividade3.Web.Pages;

public class MenorPrecoModel : PageModel
{
    private readonly ApiService _apiService;
    public List<MenorPrecoDto> MenoresPrecos { get; set; } = new();
    public string TextoResumo { get; set; } = string.Empty;

    public MenorPrecoModel(ApiService apiService) => _apiService = apiService;

    public async Task OnGetAsync()
    {
        MenoresPrecos = await _apiService.MenorPreco();

        var sb = new StringBuilder();
        sb.AppendLine("🔥 Confira os Menores Preços de Combustíveis hoje:");
        foreach (var item in MenoresPrecos)
        {
            sb.AppendLine($"• {item.Nome}: R$ {item.MenorPreco:N2}");
        }
        sb.AppendLine("\nEncontrado via Sistema de Monitoramento.");
        TextoResumo = sb.ToString();
    }
}

