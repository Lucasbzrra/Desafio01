using AutoMapper;
using Desafio01.Data;
using Desafio01.Services;

var builder = WebApplication.CreateBuilder(args);
var ConnectionString = builder.Configuration.GetConnectionString("Server=localhost; port=5432; pooling=true; ;User Id=postgres; Password=0000; Database=Cartao");
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddNpgsql<CartaoDbContext>("Server=localhost; port=5432; pooling=true; ;User Id=postgres; Password=0000; Database=Cartao");

builder.Services.AddSwaggerGen();
builder.Services.AddTransient<CriptografiaDados>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
