using System.ComponentModel.DataAnnotations;

namespace ApiEstacionamento.Entities
{
    public class LoginModel
    {
        [Key]
        public int Id_User { get; set; }
        public string Login{ get; set; }
        public string Password { get; set; }
        public string Nome { get; set; }
        public DateTime Dt_Nascimento { get; set; }
        public string Cpf_Cnpj { get; set; }
        public string Celular { get; set; }
        public int TipoCadastro { get; set; }
        public virtual CarteiraVirtual Carteira { get; set; }
        public virtual Estacionamento Estacionamento { get; set; }
        public virtual ICollection<Carro> Carros { get; set; }
        public virtual ICollection<Reserva> Reserva { get; set; }
    }
}
