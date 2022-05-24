using ApiEstacionamento.Data.Context;
using ApiEstacionamento.Entities;
using ApiEstacionamento.Interface.IEstacionamento;
using ApiEstacionamento.Model;

namespace ApiEstacionamento.Data.Repository.Estacionamento
{
    public class EstacionamentoRepository : IEstacionamentoRepository
    {
        private readonly ApplicationDbContext _context;
        public EstacionamentoRepository (ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> EstacionamentoCreate(EstacionamentoCreateModel model)
        {
            try
            {
                var Data = new Entities.Estacionamento
                {
                    User_Id = model.User_Id,
                    Nome_Estacionamento = model.Nome_Estacionamento,
                    Cnpj = model.Cnpj,
                    Local = model.Local,
                    Qtd_Vagas = model.Qtd_Vagas,
                    Horario_Funcionamento = model.Horario_Funcionamento,
                    Seguro = model.Seguro,
                    Chave = model.Chave,
                    Telefone = model.Telefone,
                    Data_Cadastro = Convert.ToString(DateTime.Now)
                };

                await _context.Estacionamentos.AddAsync(Data);
                _context.SaveChanges();
                return "Criado com Sucesso!";
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

        public async Task<Entities.Estacionamento> EstacionamentoReadEspecifico(int IdEstacionamento)
        {
            try
            {
                var result = _context.Estacionamentos.SingleOrDefault(b => b.Id_Estacionamento == IdEstacionamento);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                _context.Dispose();
            }
        }

        public async Task<IEnumerable<Entities.Estacionamento>> EstacionamentoReadGeral()
        {
            try
            {
                var result = _context.Estacionamentos.ToList();
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                _context.Dispose();
            }
        }

        public async Task<string> EstacionamentoUpdate(EstacionamentoUpdateModel model)
        {
            try
            {
                var result = _context.Estacionamentos.SingleOrDefault(b => b.Id_Estacionamento == model.Id_Estacionamento);

                result.Nome_Estacionamento = model.Nome_Estacionamento;
                result.Cnpj = model.Cnpj;
                result.Local = model.Local;
                result.Qtd_Vagas = model.Qtd_Vagas;
                result.Horario_Funcionamento = model.Horario_Funcionamento;
                result.Seguro = model.Seguro;
                result.Chave = model.Chave;
                result.Telefone = model.Telefone;

                _context.Estacionamentos.Update(result);
                _context.SaveChanges();

                return "Alteracoes Efetuadas Com Sucesso";

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
