using ApiEstacionamento.Data.Context;
using ApiEstacionamento.Data.Repository.CarteiraVirtual;
using ApiEstacionamento.Data.Repository.Estacionamento;
using ApiEstacionamento.Data.Repository.Login;
using ApiEstacionamento.Data.Repository.Reserva;
using ApiEstacionamento.Data.Repository.Veiculos;
using ApiEstacionamento.Interface.ICarteiraVirtual;
using ApiEstacionamento.Interface.IEstacionamento;
using ApiEstacionamento.Interface.ILogin;
using ApiEstacionamento.Interface.IReserva;
using ApiEstacionamento.Interface.IVeiculos;
using ApiEstacionamento.Mapper;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddAutoMapper(typeof(VeiculoProfiler));
builder.Services.AddAutoMapper(typeof(ReservaProfiler));
builder.Services.AddAutoMapper(typeof(VeiculoProfilerUpdate));
builder.Services.AddAutoMapper(typeof(ReservaProfilerUpdate));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("Estacionamento");
builder.Services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(connectionString));

builder.Services.AddScoped<ILoginRepository, LoginRepository>();
builder.Services.AddScoped<ICarteiraVirtual, CarteiraVirtualRepository>();
builder.Services.AddScoped<IEstacionamentoRepository, EstacionamentoRepository>();
builder.Services.AddScoped<IReservaRepository, ReservasRepository>();
builder.Services.AddScoped<IVeiculosRepository, VeiculosRepository>();


var app = builder.Build();

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod()
);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();

app.UseDefaultFiles();

app.UseStaticFiles();

app.UseCookiePolicy();

app.UseAuthorization();

app.MapControllers();

app.Run();
