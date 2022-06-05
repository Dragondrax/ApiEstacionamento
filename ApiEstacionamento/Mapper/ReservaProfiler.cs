using ApiEstacionamento.Entities;
using ApiEstacionamento.Model;
using AutoMapper;

namespace ApiEstacionamento.Mapper
{
    public class ReservaProfiler : Profile
    {
        public ReservaProfiler()
        {
            CreateMap<ReservaCreateModel, Entities.Reserva>();
            CreateMap<Entities.Reserva, ReservaCreateModel>();

        }
    }
}
