using System.ComponentModel.DataAnnotations;

namespace ApiEstacionamento.Model
{
    public class RegisterModel
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public DateTime Dt_Nascimento { get; set; }
        [Required]
        public string Cpf_Cnpj { get; set; }
        [Required]
        public string Celular { get; set; }
        [Required]
        public int TipoCadastro { get; set; }
        public string result { get; set; }
    }
}
