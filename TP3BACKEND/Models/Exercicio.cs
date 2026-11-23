namespace SistemaAcademia.Models
{
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
}