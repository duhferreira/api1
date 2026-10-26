using System.ComponentModel.DataAnnotations.Schema;

namespace api1.Models;

[Table("combustiveis")]
public class Produto
{
    [Column("id_combustiveis")]
    public int Id { get; set; }

    [Column("tipos")]
    public string Nome { get; set; } = string.Empty;

    [NotMapped]
    public string Categoria { get; set; } = "Combustível";
}