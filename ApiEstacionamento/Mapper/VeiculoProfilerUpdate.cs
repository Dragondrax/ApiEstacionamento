using ApiEstacionamento.Model;
using AutoMapper;

namespace ApiEstacionamento.Mapper
{
    public class VeiculoProfilerUpdate : Profile
    {
        public VeiculoProfilerUpdate()
        {
            CreateMap<VeiculoUpdateModel, Entities.Carro>();
            CreateMap<Entities.Carro, VeiculoUpdateModel>();
        }
    }
}
