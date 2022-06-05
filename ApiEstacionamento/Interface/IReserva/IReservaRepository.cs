using ApiEstacionamento.Model;

namespace ApiEstacionamento.Interface.IReserva
{
    public interface IReservaRepository
    {
        public Task<string> CreateReserva(ReservaCreateModel model);
        public IEnumerable<ReservaReadModel> ReadReserva(int IdUser);
        public Task<string> UpdateReserva(ReservaUpdateModel model);
        public Task<string> DeleteReserva(int IdReserva);
    }
}
