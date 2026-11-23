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
}