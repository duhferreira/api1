using api1.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options => {
    options.AddPolicy("PermitirTudo", policy => {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});


// 1. Registra o banco de dados MySQL usando a conexão do appsettings.json
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("Default"),
        new MySqlServerVersion(new Version(8, 0, 0))));

// 2. Adiciona o suporte moderno a Controllers e Documentação nativa do .NET
builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();
app.UseCors("PermitirTudo");


// 3. Ativa a rota de documentação em ambiente de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();