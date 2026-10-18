namespace SistemaAcademia.Models
{
    public class Aluno
    {
        public int Matricula { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public bool StatusAtivo { get; set; }

        public string ToCSV()
        {
            return $"{Matricula};{Nome};{Cpf};{StatusAtivo}";
        }
    }
}