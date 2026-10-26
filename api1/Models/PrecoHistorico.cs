using System.ComponentModel.DataAnnotations.Schema;

namespace api1.Models;

[Table("coletas")]
public class PrecoHistorico
{
    [Column("id")] 
    public int Id { get; set; }

    [Column("id_combustiveis")]
    public int ProdutoId { get; set; }

    [Column("datas")]
    public DateTime Data { get; set; }

    [Column("precos")] 
    public decimal Preco { get; set; }
}
