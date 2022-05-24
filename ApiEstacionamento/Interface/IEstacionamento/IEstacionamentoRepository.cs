using ApiEstacionamento.Model;

namespace ApiEstacionamento.Interface.IEstacionamento
{
    public interface IEstacionamentoRepository
    {
        public Task<IEnumerable<Entities.Estacionamento>> EstacionamentoReadGeral();
        public Task<Entities.Estacionamento> EstacionamentoReadEspecifico(int IdEstacionamento);
        public Task<string> EstacionamentoCreate(EstacionamentoCreateModel model);
        public Task<string> EstacionamentoUpdate(EstacionamentoUpdateModel model);
    }
}
