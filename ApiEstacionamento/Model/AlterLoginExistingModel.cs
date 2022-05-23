namespace ApiEstacionamento.Model
{
    public class AlterLoginExistingModel
    {
        public string Login { get; set; }
        public string Senha { get; set; }
        public string NovaSenha { get; set; } = "";
        public string NovoEmail { get; set; } = "";
    }
}
