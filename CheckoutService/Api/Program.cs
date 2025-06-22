using Api.Extensions;
using CorrelationId;
using Infra;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCorrelationIdConfiguration();

builder.Services.AddInfra(builder.Configuration);

builder.Services.AddLogging(opts =>
{
    opts.AddSeq(
        builder.Configuration.GetSection("Seq")
    );
});

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

app.UseCorrelationId();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) app.MapOpenApi();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();