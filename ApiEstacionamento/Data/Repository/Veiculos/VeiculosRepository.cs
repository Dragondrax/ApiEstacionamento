using ApiEstacionamento.Data.Context;
using ApiEstacionamento.Interface.IVeiculos;
using ApiEstacionamento.Model;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ApiEstacionamento.Data.Repository.Veiculos
{
    public class VeiculosRepository : IVeiculosRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public VeiculosRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<string> CreateVeiculos(VeiculoCreateModel model)
        {
            try
            {
                var modelMapper = _mapper.Map<Entities.Carro>(model);
                await _context.Carros.AddAsync(modelMapper);
                _context.SaveChanges();
                return "Dados Criados com Sucesso";
            }
            catch (Exception ex)
            {
                return $"Erro: {ex.Message}";
            }
            finally
            {
                _context.Dispose();
            }
        }

        public async Task<string> DeleteVeiculos(int Id)
        {
            try
            {
                var result = _context.Carros.SingleOrDefault(b => b.Id_Carro == Id);
                _context.Carros.Remove(result);
                _context.SaveChanges();
                return "Deletado";
            }
            catch(Exception ex)
            {
                return $"Erro: {ex.Message}";
            }
            finally
            {
                _context.Dispose();
            }
        }

        public IEnumerable<Entities.Carro> ReadVeiculosPorDono(int Id_User)
        {
            try
            {
                var result = from c1 in _context.Carros
                             where c1.User_Id == Id_User
                             select c1;

                return result;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<string> UpdateVeiculos(VeiculoUpdateModel model)
        {
            try
            {
                _context.Carros.AsNoTracking().SingleOrDefault(b => b.Id_Carro == model.Id_Carro);
                var modelMapper = _mapper.Map<Entities.Carro>(model);
                
                
                _context.Carros.Update(modelMapper);
                _context.SaveChanges();

                return "Dados Atualizados com Sucesso";
            }
            catch (Exception ex)
            {
                return $"Erro: {ex.Message}";
            }
            finally 
            {
                _context.Dispose();
            }

        }
    }
}
