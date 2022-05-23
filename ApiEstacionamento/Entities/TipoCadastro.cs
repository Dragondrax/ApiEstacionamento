using System.ComponentModel.DataAnnotations;

namespace ApiEstacionamento.Entities
{
    public class TipoCadastro
    {
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; }
    }
}
