using ApiEstacionamento.Model;

namespace ApiEstacionamento.Interface.ILogin
{
    public interface ILoginRepository
    {
        IEnumerable<LoginResultModel> Login(string Email, string Senha);
        Task<bool> Register(RegisterModel model);
        Task<bool> AlterLoginExisting(AlterLoginExistingModel model);
    }
}
