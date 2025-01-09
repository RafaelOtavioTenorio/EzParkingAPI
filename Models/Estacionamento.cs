namespace ez_parking_api.Models
{
    public class Estacionamento
    {
        public int ID { get; set; }
        public string Endereco { get; set; }
        public int? NumPiso {  get; set; }
        public int? NumVaga { get; set; }
        public List<Registro> Historico { get; set; }
        public bool Cobrado { get; set; }
        public bool Active { get; set; }
    }
}
