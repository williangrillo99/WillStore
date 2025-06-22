using Api.Extensions;
using Application;
using CorrelationId;           
using Infra;                    

var builder = WebApplication.CreateBuilder(args);  

// Add services to the container.

// Configuração do CorrelationId (identificador único por requisição, útil para rastreamento e logs).
builder.Services.AddCorrelationIdConfiguration();

// Registra dependências das camadas
builder.Services.AddInfra(builder.Configuration);
builder.Services.AddApplication();

// Configuração do logging para usar o Seq (ferramenta de logs estruturados, visualização e análise local ou cloud).
builder.Services.AddLogging(opts =>
{
    opts.AddSeq(
        builder.Configuration.GetSection("Seq")   // Busca configurações do Seq em "appsettings.json".
    );
});

builder.Services.AddControllers();

builder.Services.AddOpenApi();

var app = builder.Build();    

// Ativa o middleware que injeta e propaga o CorrelationId automaticamente nos requests e logs.
app.UseCorrelationId();

if (app.Environment.IsDevelopment()) app.MapOpenApi();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();