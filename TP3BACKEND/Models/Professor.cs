using System;

namespace SistemaAcademia.Models
{
    public class Professor : Usuario
    {
        public string Cref { get; set; } = string.Empty;
        public string Especialidade { get; set; } = string.Empty;

        public Treino PrescreverTreino(Aluno aluno, string objetivo)
        {
            return new Treino
            {
                Objetivo = objetivo,
                DataCriacao = DateTime.Now
            };
        }

        public AvaliacaoFisica RegistrarAvaliacao(Aluno aluno, double peso, double altura, double percentualGordura)
        {
            var avaliacao = new AvaliacaoFisica
            {
                MatriculaAluno = aluno.Matricula,
                DataAvaliacao = DateTime.Now,
                Peso = peso,
                Altura = altura,
                PercentualGordura = percentualGordura
            };
            avaliacao.CalcularIMC();
            return avaliacao;
        }
    }
}