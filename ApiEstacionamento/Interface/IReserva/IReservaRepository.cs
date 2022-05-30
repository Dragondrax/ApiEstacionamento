using ApiEstacionamento.Model;

namespace ApiEstacionamento.Interface.IReserva
{
    public interface IReservaRepository
    {
        public Task<string> CreateReserva(ReservaCreateModel model);
        public Task<string> ReadReserva();
        public Task<string> UpdateReserva();
        public Task<string> DeleteReserva();
    }
}
