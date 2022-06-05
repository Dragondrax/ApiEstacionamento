using ApiEstacionamento.Data.Context;
using ApiEstacionamento.Interface.IReserva;
using ApiEstacionamento.Model;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ApiEstacionamento.Data.Repository.Reserva
{
    public class ReservasRepository : IReservaRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public ReservasRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<string> CreateReserva(ReservaCreateModel model)
        {
            try
            {
                var modelMapper = _mapper.Map<Entities.Reserva>(model);
                await _context.Reservas.AddAsync(modelMapper);
                _context.SaveChanges();
                return "Reserva Criada com Sucesso";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> DeleteReserva(int IdReserva)
        {
            try
            {
                var result = await _context.Reservas.SingleOrDefaultAsync(b => b.Id_Reserva == IdReserva);
                _context.Reservas.Remove(result);
                return "Deletado com Sucesso!";

            }
            catch(Exception ex) 
            {
                return ex.Message;
            }
        }

        public IEnumerable<ReservaReadModel> ReadReserva(int IdUser)
        {
            try
            {
                var result = from c1 in _context.Reservas.AsNoTracking().Where(c => c.Usuario_Id == IdUser)
                             join c2 in _context.Estacionamentos.AsNoTracking() on c1.Estacionamento_Id equals c2.Id_Estacionamento
                             select new ReservaReadModel
                             {
                                 Nome_Proprietario = c1.Nome_Proprietario,
                                 Placa_Veiculo = c1.Placa_Veiculo,
                                 Modelo = c1.Modelo,
                                 Hora_Reserva = c1.Hora_Reserva,
                                 Pagamento = c1.Pagamento,
                                 Tipo_Veiculo = c1.Tipo_Veiculo,
                                 Ano_Veiculo = c1.Ano_Veiculo,
                                 Telefone_Proprietario = c1.Telefone_Proprietario,
                                 Nome_Estacionamento = c2.Nome_Estacionamento,
                                 Telefone_Estacionamento = c2.Telefone,
                                 Local = c2.Local,
                                 Horario_Funcionamento = c2.Horario_Funcionamento,
                                 Seguro = c2.Seguro,
                                 Chave = c2.Chave
                             };

                return result;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<string> UpdateReserva(ReservaUpdateModel model)
        {
            try
            {
                var resultMapper = _mapper.Map<Entities.Reserva>(model);
                _context.Reservas.Update(resultMapper);
                _context.SaveChanges();
                return "Atualizado com Sucesso!";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
