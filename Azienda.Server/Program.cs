using Azienda.Shared;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AziendaDbContext>(opt => opt.UseSqlServer(
    @"Data Source=MSI\SQLEXPRESS;Database=AziendaDb;Integrated Security=True;Trusted_Connection=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;"));

builder.Services.AddCors();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(b => b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.UseHttpsRedirection();

app.MapGet("api/impiegatieta", (AziendaDbContext db) => db.ImpiegatiEta.ToList());


app.Run();

