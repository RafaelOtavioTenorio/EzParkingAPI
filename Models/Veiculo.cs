namespace ez_parking_api.Models
{
    public class Veiculo
    {
        public int ID { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }
        public string Cor {  get; set; }
        public Registro RegAtual { get; set; }
        public List<Registro> Historico { get; set; }
        public bool Active { get; set; }
    }
}
