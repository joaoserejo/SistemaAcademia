namespace SistemaAcademia.Models
{
    public class Aluno : Usuario
    {
        public int Matricula { get; set; }
        public bool StatusAtivo { get; set; } = true;
        public string MotivoInativacao { get; set; } = "-";

        public void AtivarMatricula()
        {
            StatusAtivo = true;
            MotivoInativacao = "-";
        }

        public void InativarMatricula(string motivo)
        {
            StatusAtivo = false;
            MotivoInativacao = string.IsNullOrWhiteSpace(motivo) ? "Trancamento solicitado" : motivo;
        }

        public bool PodeAcessarAcademia()
        {
            return StatusAtivo;
        }

        public string ToCSV()
        {
            return $"{Matricula};{Nome};{Cpf};{StatusAtivo};{MotivoInativacao}";
        }
    }
}