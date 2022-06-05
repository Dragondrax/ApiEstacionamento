namespace ApiEstacionamento.Model
{
    public class ReservaReadModel
    {
        public string Nome_Proprietario { get; set; }
        public string Placa_Veiculo { get; set; }
        public string Modelo { get; set; }
        public DateTime Hora_Reserva { get; set; }
        public bool Pagamento { get; set; }
        public string Tipo_Veiculo { get; set; }
        public int Ano_Veiculo { get; set; }
        public string Telefone_Proprietario { get; set; }
        public string Nome_Estacionamento { get; set; }
        public string Telefone_Estacionamento { get; set; }
        public string Local { get; set; }
        public string Horario_Funcionamento { get; set; }
        public bool Seguro { get; set; }
        public bool Chave { get; set; }
    }
}
