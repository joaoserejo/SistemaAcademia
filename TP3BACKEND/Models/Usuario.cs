namespace SistemaAcademia.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;

        public bool Autenticar(string cpf, string senha)
        {
            return Cpf == cpf && Senha == senha;
        }

        public void AtualizarDados(string novoNome)
        {
            if (!string.IsNullOrWhiteSpace(novoNome))
            {
                Nome = novoNome;
            }
        }
    }
}