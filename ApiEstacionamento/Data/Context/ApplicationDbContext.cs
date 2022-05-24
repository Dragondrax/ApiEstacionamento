//using ApiEstacionamento.Data.Mapping;
using ApiEstacionamento.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace ApiEstacionamento.Data.Context
{
    public class ApplicationDbContext : IdentityDbContext, IDisposable
    {
        public IDbConnection Connection => Database.GetDbConnection();
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<LoginModel> Logins { get; set; } //Tabela de Login
        public DbSet<Carro> Carros { get; set; } //Tabela de carros
        public DbSet<CarteiraVirtual> CarteirasVirtuais { get; set; }
        public DbSet<Estacionamento> Estacionamentos { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<TipoCadastro> TipoCadastro { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<LoginModel>()
                .HasOne(estacionamento => estacionamento.Estacionamento)
                .WithOne(usuario => usuario.Usuario)
                .HasForeignKey<Estacionamento>(estacionamento => estacionamento.User_Id);

            builder.Entity<LoginModel>()
                .HasOne(carteira => carteira.Carteira)
                .WithOne(usuario => usuario.Usuario)
                .HasForeignKey<CarteiraVirtual>(carteira => carteira.user_id);

            builder.Entity<Carro>()
                .HasOne(carros => carros.Usuario)
                .WithMany(usuario => usuario.Carros)
                .HasForeignKey(carros => carros.User_Id);

            builder.Entity<Reserva>()
                .HasOne(reserva => reserva.Usuario)
                .WithMany(usuario => usuario.Reserva)
                .HasForeignKey(reserva => reserva.Usuario_Id)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Reserva>()
                .HasOne(reserva => reserva.Estacionamento)
                .WithMany(estacionamento => estacionamento.Reservas)
                .HasForeignKey(reserva => reserva.Estacionamento_Id)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Reserva>()
                .HasOne(reserva => reserva.Carro)
                .WithMany(carro => carro.Reservas)
                .HasForeignKey(reserva => reserva.Carro_Id)
                .OnDelete(DeleteBehavior.NoAction);



            base.OnModelCreating(builder);
        }
    }
}
