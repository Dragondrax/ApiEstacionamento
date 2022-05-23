using System.ComponentModel.DataAnnotations;

namespace ApiEstacionamento.Entities
{
    public class Reserva
    {
        [Key]
        public int Id_Reserva { get; set; }
        public int Estacionamento_Id { get; set; }
        public int Usuario_Id { get; set; }
        public int Carro_Id { get; set; }
        public string Nome_Proprietario { get; set; }
        public string Placa_Veiculo { get; set; } 
        public string Modelo { get; set; }
        public DateTime Hora_Reserva { get; set; }
        public bool Pagamento { get; set; }
        public string Qtd_Horas_Reservadas { get; set; }
        public string Tipo_Veiculo { get; set; }
        public int Ano_Veiculo { get; set; }
        public string Telefone_Proprietario { get; set; }
        public virtual LoginModel Usuario { get; set; }
        public virtual Estacionamento Estacionamento { get; set; } 
        public virtual Carro Carro { get; set; }
    }
}
