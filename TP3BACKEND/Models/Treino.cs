using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaAcademia.Models
{
    public class Treino
    {
        public int IdTreino { get; set; }
        public int MatriculaAluno { get; set; }
        public string CrefProfessor { get; set; } = string.Empty;
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
}