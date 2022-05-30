using ApiEstacionamento.Model;

namespace ApiEstacionamento.Interface.IVeiculos
{
    public interface IVeiculosRepository
    {
        public Task<string> CreateVeiculos(VeiculoCreateModel model);
        public IEnumerable<Entities.Carro> ReadVeiculosPorDono(int Id_User);
        public Task<string> UpdateVeiculos(VeiculoUpdateModel model);
        public Task<string> DeleteVeiculos(int Id);
    }
}
