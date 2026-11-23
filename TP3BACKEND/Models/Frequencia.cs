using System;

namespace SistemaAcademia.Models
{
    public class Frequencia
    {
        public int IdFrequencia { get; set; }
        public int MatriculaAluno { get; set; }
        public DateTime DataHora { get; set; } = DateTime.Now;
        public bool AcessoLiberado { get; set; }

        public bool ValidarERegistrarAcesso(Aluno aluno)
        {
            DataHora = DateTime.Now;
            AcessoLiberado = aluno != null && aluno.PodeAcessarAcademia();
            return AcessoLiberado;
        }
    }
}