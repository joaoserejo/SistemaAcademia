using System.Numerics;

namespace SistemaAcademia.Models
{
    public class Funcionario : Usuario
    {
        public string Cargo { get; set; } = string.Empty;
        public string Turno { get; set; } = string.Empty;

        public void TrancarMatriculaAluno(Aluno aluno, string motivo)
        {
            aluno.InativarMatricula(motivo);
        }

        public void ConfirmarPagamento(Pagamento pagamento, Aluno aluno, Plano plano)
        {
            pagamento.ProcessarPagamento(aluno, plano);
        }
    }
}