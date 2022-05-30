using ApiEstacionamento.Data.Context;
using ApiEstacionamento.Interface.IReserva;
using ApiEstacionamento.Model;

namespace ApiEstacionamento.Data.Repository.Reserva
{
    public class ReservasRepository : IReservaRepository
    {
        private readonly ApplicationDbContext _context;
        public ReservasRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<string> CreateReserva(ReservaCreateModel model)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteReserva()
        {
            throw new NotImplementedException();
        }

        public Task<string> ReadReserva()
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateReserva()
        {
            throw new NotImplementedException();
        }
    }
}
