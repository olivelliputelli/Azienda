using Azienda.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;

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

/* R vista ImpiegatiEtaVista */
app.MapGet("api/impiegatieta", 
   (AziendaDbContext db) => db.ImpiegatiEta.ToList());

/* CRUD tabella Impiegati */
app.MapGet("api/dipartimenti",
   async (AziendaDbContext db) => await db.Dipartimenti.ToListAsync());

app.MapGet("api/dipartimenti/{id}",
    (AziendaDbContext db, int id) => db.Dipartimenti.SingleOrDefault(d => d.DipartimentoId==id));

app.MapPost("api/dipartimenti", 
    (AziendaDbContext db, Dipartimento dip) => { db.Dipartimenti.Add(dip); db.SaveChanges(); });

app.MapPut("api/dipartimenti",
    (AziendaDbContext db, Dipartimento dip) => {
        var d = db.Dipartimenti.Find(dip.DipartimentoId);
        d.Nome = dip.Nome;
        d.Localita = dip.Localita;
        d.Provincia = dip.Provincia;
        db.SaveChanges(); 
    });

app.MapDelete("api/dipartimenti/{id}",
    (AziendaDbContext db, int id) => { db.Remove(db.Dipartimenti.Find(id)); db.SaveChanges(); });

/*  CRUD tabella TodoItems */
app.MapGet("api/TodoItems",
   (AziendaDbContext db) => db.TodoItems.ToList());

app.Run();

