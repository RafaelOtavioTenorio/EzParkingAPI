namespace ez_parking_api.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public int Tipo { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public int CPF { get; set; }
        public DateOnly DataNascimento { get; set; }
        public List<Veiculo> Veiculos { get; set; }
        public bool Active { get; set; }
    }
}
