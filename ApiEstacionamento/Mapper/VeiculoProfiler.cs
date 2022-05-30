using ApiEstacionamento.Model;
using AutoMapper;

namespace ApiEstacionamento.Mapper
{
    public class VeiculoProfiler : Profile
    {
        public VeiculoProfiler()
        {
            CreateMap<VeiculoCreateModel, Entities.Carro>();
            CreateMap<Entities.Carro, VeiculoCreateModel>();
        }
    }
}
