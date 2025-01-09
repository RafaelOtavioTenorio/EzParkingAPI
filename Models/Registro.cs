namespace ez_parking_api.Models
{
    public class Registro
    {
        public int ID { get; set; }
        public DateTime Entrada { get; set; }
        public bool Active { get; set; }
        public DateTime? Saida { get; set; }
        public Estacionamento Local { get; set; }
        public double? Valor { get; set; }
    }
}
