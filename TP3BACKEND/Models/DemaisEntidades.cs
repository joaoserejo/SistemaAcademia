using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaAcademia.Models
{
    public class Plano
    {
        public int IdPlano { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public double ValorMensal { get; set; }

        public double CalcularValorComDesconto(double percentualDesconto)
        {
            return ValorMensal - (ValorMensal * (percentualDesconto / 100.0));
        }
    }

    public class Exercicio
    {
        public int IdExercicio { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int Series { get; set; }
        public int Repeticoes { get; set; }

        public void AtualizarCarga(int novasSeries, int novasRepeticoes)
        {
            Series = novasSeries;
            Repeticoes = novasRepeticoes;
        }
    }

    public class Treino
    {
        public int IdTreino { get; set; }
        public string Objetivo { get; set; } = string.Empty;
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public List<Exercicio> Exercicios { get; set; } = new List<Exercicio>();

        public void AdicionarExercicio(Exercicio exercicio)
        {
            Exercicios.Add(exercicio);
        }

        public void RemoverExercicio(int idExercicio)
        {
            var item = Exercicios.FirstOrDefault(e => e.IdExercicio == idExercicio);
            if (item != null) Exercicios.Remove(item);
        }
    }

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

    public class Pagamento
    {
        public int IdPagamento { get; set; }
        public DateTime DataPagamento { get; set; } = DateTime.Now;
        public double ValorPago { get; set; }
        public string Status { get; set; } = "Pendente";

        public bool ProcessarPagamento(Aluno aluno, Plano plano)
        {
            if (aluno == null || plano == null) return false;
            ValorPago = plano.ValorMensal;
            DataPagamento = DateTime.Now;
            Status = "Aprovado";
            aluno.AtivarMatricula();
            return true;
        }
    }
}