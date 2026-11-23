using System;

namespace SistemaAcademia.Models
{
    public class Pagamento
    {
        public int IdPagamento { get; set; }
        public int MatriculaAluno { get; set; }
        public string DescricaoPlano { get; set; } = string.Empty;
        public DateTime DataPagamento { get; set; } = DateTime.Now;
        public double ValorPago { get; set; }
        public string Status { get; set; } = "Pendente";

        public bool ProcessarPagamento(Aluno aluno, Plano plano)
        {
            if (aluno == null || plano == null) return false;
            MatriculaAluno = aluno.Matricula;
            DescricaoPlano = plano.Descricao;
            ValorPago = plano.ValorMensal;
            DataPagamento = DateTime.Now;
            Status = "Aprovado";
            aluno.AtivarMatricula();
            return true;
        }
    }
}