using ApiEstacionamento.Data.Context;
using ApiEstacionamento.Interface.ILogin;
using ApiEstacionamento.Model;
using ApiEstacionamento.Services;

namespace ApiEstacionamento.Data.Repository.Login
{
    public class LoginRepository : ILoginRepository
    {
        private readonly ApplicationDbContext _context;
        public LoginRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AlterLoginExisting(AlterLoginExistingModel model)
        {
            try
            {
                _context.Connection.Open();
                var result = _context.Logins.SingleOrDefault(b => b.Login == model.Login && b.Password == model.Senha);
                if (model.NovoEmail != "")
                    result.Login = model.NovoEmail;
                if (model.NovaSenha != "")
                    result.Password = model.NovaSenha;

                if(result != null)
                {
                    _context.Update(result);
                    _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch(Exception ex)
            {
                return false;
            }
            finally
            {
                _context.Dispose();
            }
        }

        public async Task<bool> Login(string Email, string Senha)
        {
            try
            {
                _context.Connection.Open();
                var access = from c1 in _context.Logins
                             where c1.Login == Email && c1.Password == Senha
                             select c1;

                _context.Connection.Close();

                if(access.Count() == 1)
                    return true;

                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                _context.Dispose();
            }
        }

        public async Task<bool> Register(RegisterModel model)
        {
            try
            {
                _context.Connection.Open();

                var countEmail = from c1 in _context.Logins
                                 where c1.Login == model.Login
                                 select c1;

                if(countEmail.Count() == 0)
                {
                    var encripty = new CreateHashEncrypting();
                    var senhaCriptografada = encripty.GerarHashSha256(model.Password);

                    Entities.LoginModel modelSave = new Entities.LoginModel
                    {
                        Login = model.Login,
                        Password = senhaCriptografada,
                        Nome = model.Nome,
                        Dt_Nascimento = model.Dt_Nascimento,
                        Cpf_Cnpj = model.Cpf_Cnpj,
                        Celular = model.Celular,
                        TipoCadastro = model.TipoCadastro
                    };

                    await _context.AddAsync(modelSave);
                    _context.SaveChanges();
                    _context.Connection.Close();
                    return true;
                }
                _context.Connection.Close();
                return false;
                
            }
            catch(Exception ex)
            {
                return false;
            }
            finally
            {
                _context.Dispose();
            }
        }
    }
}
