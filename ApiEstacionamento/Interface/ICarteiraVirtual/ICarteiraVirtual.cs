using ApiEstacionamento.Entities;
using ApiEstacionamento.Model;
using Microsoft.AspNetCore.Mvc;

namespace ApiEstacionamento.Interface.ICarteiraVirtual
{
    public interface ICarteiraVirtual
    {
        Task<string> RegisterCarteiraVirtual(NovaCarteiraVirtual model);
        Task<CarteiraVirtual> ReadCarteiraVirtual(int Id);
        Task<string> TransferenciaCarteiraVirtual(CarteiraVirtualTransferencia model);
        Task<string> TransferenciaEntradaCarteiraVirtual(TransferenciaEntradaCarteiraVirtual model);
        Task<string> TransferenciaSaidaCarteiraVirtual(TransferenciaEntradaCarteiraVirtual model);
    }
}
