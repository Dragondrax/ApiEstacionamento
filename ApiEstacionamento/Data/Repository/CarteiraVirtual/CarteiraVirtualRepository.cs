using ApiEstacionamento.Data.Context;
using ApiEstacionamento.Interface.ICarteiraVirtual;
using ApiEstacionamento.Model;

namespace ApiEstacionamento.Data.Repository.CarteiraVirtual
{
    public class CarteiraVirtualRepository : ICarteiraVirtual
    {
        private readonly ApplicationDbContext _context;
        public CarteiraVirtualRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Entities.CarteiraVirtual> ReadCarteiraVirtual(int Id)
        {
            try
            {
                _context.Connection.Open();
                var result = _context.CarteirasVirtuais.SingleOrDefault(b => b.user_id == Id);
                return result;
            }
            catch (Exception ex)
            {
                return new Entities.CarteiraVirtual();
            }
            finally
            {
                _context.Dispose();
            }
        }

        public async Task<string> RegisterCarteiraVirtual(NovaCarteiraVirtual model)
        {
            try
            {
                var result = new Entities.CarteiraVirtual{
                    user_id = model.Id_Usuario,
                    Creditos = model.Credito
                };
                await _context.CarteirasVirtuais.AddAsync(result);
                _context.SaveChanges();
                return "Sucesso";
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

        public async Task<string> TransferenciaCarteiraVirtual(CarteiraVirtualTransferencia model)
        {
            try
            {
                var creditoCarteiraSaida = _context.CarteirasVirtuais.SingleOrDefault(b => b.carteira_id == model.Id_Carteira_Saida);
                var creditoCarteiraEntrada = _context.CarteirasVirtuais.SingleOrDefault(b => b.carteira_id == model.Id_Carteira_Entrada);

                var novoCreditoSaida = creditoCarteiraSaida.Creditos - model.Creditos;
                if(novoCreditoSaida >= 0)
                {
                    creditoCarteiraSaida.Creditos = novoCreditoSaida;
                    _context.CarteirasVirtuais.Update(creditoCarteiraSaida);

                    var novoCreditoEntrada = creditoCarteiraEntrada.Creditos + model.Creditos;
                    creditoCarteiraEntrada.Creditos = novoCreditoEntrada;
                    _context.CarteirasVirtuais.Update(creditoCarteiraEntrada);

                    _context.SaveChanges();

                    return "Pagamento Efetuado com Sucesso";
                }
                return "Falta de Crédito na Carteira";
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
        public async Task<string> TransferenciaEntradaCarteiraVirtual(TransferenciaEntradaCarteiraVirtual model)
        {
            try
            {
                var creditoAtual = _context.CarteirasVirtuais.SingleOrDefault(b => b.carteira_id == model.CardeiraId);
                var novoCredito = creditoAtual.Creditos + model.Credito;

                creditoAtual.Creditos = novoCredito;
                _context.Update(creditoAtual);
                _context.SaveChanges();

                return "Credito Adicionado com Sucesso";
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
        public async Task<string> TransferenciaSaidaCarteiraVirtual(TransferenciaEntradaCarteiraVirtual model)
        {
            try
            {
                var creditoAtual = _context.CarteirasVirtuais.SingleOrDefault(b => b.carteira_id == model.CardeiraId);
                
                var novoCredito = creditoAtual.Creditos - model.Credito;

                if(novoCredito > 0)
                {
                    creditoAtual.Creditos = novoCredito;
                    _context.Update(creditoAtual);
                    _context.SaveChanges();

                    return "Credito Removido com Sucesso";
                }
                return "Falta de Crédito na Carteira";
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
