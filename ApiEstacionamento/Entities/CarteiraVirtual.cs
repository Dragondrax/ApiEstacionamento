using System.ComponentModel.DataAnnotations;

namespace ApiEstacionamento.Entities
{
    public class CarteiraVirtual
    {
        [Key]
        public int carteira_id { get; set; }
        public int user_id { get; set; }
        public int estacionamento_id { get; set; }
        public float Creditos { get; set; }
        public LoginModel Usuario { get; set; }

    }
}
