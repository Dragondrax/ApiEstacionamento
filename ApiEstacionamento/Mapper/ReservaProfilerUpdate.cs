using ApiEstacionamento.Model;
using AutoMapper;

namespace ApiEstacionamento.Mapper
{
    public class ReservaProfilerUpdate : Profile
    {
        public ReservaProfilerUpdate()
        {
            CreateMap<ReservaUpdateModel, Entities.Reserva>();
            CreateMap<Entities.Reserva, ReservaUpdateModel>();
        }
    }
}
