using Microsoft.EntityFrameworkCore;
using api1.Models;

namespace api1.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Produto> Produtos => Set<Produto>();
    public DbSet<PrecoHistorico> PrecosHistoricos => Set<PrecoHistorico>();
}