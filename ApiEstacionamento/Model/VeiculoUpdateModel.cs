namespace ApiEstacionamento.Model
{
    public class VeiculoUpdateModel
    {
        public int Id_Carro { get; set; }
        public int User_Id { get; set; }
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public string Situacao_Carro { get; set; }
        public bool Seguro { get; set; }
        public string Tipo_Veiculo { get; set; }
        public string Fabricante { get; set; }
        public int Ano_Fabricacao { get; set; }
    }
}
