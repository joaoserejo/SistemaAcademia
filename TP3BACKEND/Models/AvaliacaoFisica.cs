using System;
using System.Globalization;

namespace SistemaAcademia.Models
{
    public class AvaliacaoFisica
    {
        public int IdAvaliacao { get; set; }
        public int MatriculaAluno { get; set; }
        public DateTime DataAvaliacao { get; set; } = DateTime.Now;
        public double Peso { get; set; }
        public double Altura { get; set; }
        public double PercentualGordura { get; set; }
        public double Imc { get; set; }

        public double CalcularIMC()
        {
            if (Altura > 0)
            {
                Imc = Math.Round(Peso / (Altura * Altura), 2);
            }
            return Imc;
        }

        public string ClassificarIMC()
        {
            double valor = Imc > 0 ? Imc : CalcularIMC();
            if (valor < 18.5) return "Abaixo do peso";
            if (valor < 25.0) return "Peso normal";
            if (valor < 30.0) return "Sobrepeso";
            return "Obesidade";
        }

        public string ToCSV()
        {
            CalcularIMC();
            return string.Format(CultureInfo.InvariantCulture,
                "{0};{1:dd/MM/yyyy HH:mm};{2};{3};{4};{5}",
                MatriculaAluno, DataAvaliacao, Peso, Altura, PercentualGordura, Imc);
        }
    }
}