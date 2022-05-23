namespace ApiEstacionamento.Model
{
    public class Estacionamento
    {
        public int Id_Estacionamento { get; set; }
        public string Nome_Estacionamento { get; set; }
        public string Cnpj { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Local { get; set; }
        public string Qtd_Vagas { get; set; }
        public string Horario_Funcionamento { get; set; }
        public bool Seguro { get; set; }
        public bool Chave { get; set; }
        public string Telefone { get; set; }
        public string Data_Cadastro { get; set; }
    }
}
