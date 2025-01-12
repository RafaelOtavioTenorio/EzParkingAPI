using System.Text.Json.Serialization;

namespace ez_parking_api.Models
{
    public class User
    {
        [JsonIgnore]
        public int ID { get; set; }

        public string Nome { get; set; }
        public int Tipo { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string CPF { get; set; }
        public DateOnly DataNascimento { get; set; }
        public List<int> Veiculos { get; set; }
        public bool Active { get; set; }
    }
}
