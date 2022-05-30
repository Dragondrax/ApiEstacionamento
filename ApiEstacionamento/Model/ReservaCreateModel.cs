namespace ApiEstacionamento.Model
{
    public class ReservaCreateModel
    {
        public int Estacionamento_Id { get; set; }
        public int Usuario_Id { get; set; }
        public string Nome_Proprietario_Reserva { get; set; }
        public string Placa_Veiculo { get; set; }
        public string Modelo { get; set; }
        public DateTime Hora_Reserva { get; set; } = DateTime.Now;
        public bool Pagamento { get; set; }
        public string Qtd_Horas_Reservadas { get; set; }
        public string Tipo_Veiculo { get; set; }
        public int Ano_Veiculo { get; set; }
        public string Telefone_Proprietario { get; set; }
    }
}
