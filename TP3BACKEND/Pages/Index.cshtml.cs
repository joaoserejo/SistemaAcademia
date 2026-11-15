using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaAcademia.Models;
using SistemaAcademia.Services;
using System.Collections.Generic;
using System.Linq;

namespace SistemaAcademia.Pages
{
    public class IndexModel : PageModel
    {
        private readonly GerenciadorCSV _gerenciador = new GerenciadorCSV();

        public List<Aluno> Alunos { get; set; } = new List<Aluno>();
        public List<AvaliacaoFisica> Avaliacoes { get; set; } = new List<AvaliacaoFisica>();

        [BindProperty]
        public Aluno NovoAluno { get; set; } = new Aluno();

        [BindProperty]
        public AvaliacaoFisica NovaAvaliacao { get; set; } = new AvaliacaoFisica();

        [TempData]
        public string MensagemCatraca { get; set; }

        public void OnGet()
        {
            Alunos = _gerenciador.ListarAlunos();
            Avaliacoes = _gerenciador.ListarAvaliacoes();
        }

        public IActionResult OnPostCadastrarAluno()
        {
            if (!string.IsNullOrWhiteSpace(NovoAluno.Nome) && NovoAluno.Matricula > 0)
            {
                NovoAluno.AtivarMatricula();
                _gerenciador.SalvarAluno(NovoAluno);
            }
            return RedirectToPage();
        }

        public IActionResult OnPostInativarAluno(int matricula, string motivo)
        {
            _gerenciador.InativarAluno(matricula, motivo);
            return RedirectToPage();
        }

        public IActionResult OnPostRegistrarAvaliacao()
        {
            if (NovaAvaliacao.MatriculaAluno > 0 && NovaAvaliacao.Peso > 0 && NovaAvaliacao.Altura > 0)
            {
                NovaAvaliacao.CalcularIMC();
                _gerenciador.SalvarAvaliacao(NovaAvaliacao);
            }
            return RedirectToPage();
        }

        public IActionResult OnPostSimularCatraca(int matriculaCatraca)
        {
            var aluno = _gerenciador.ListarAlunos().FirstOrDefault(a => a.Matricula == matriculaCatraca);
            var frequencia = new Frequencia { MatriculaAluno = matriculaCatraca };

            if (aluno == null)
            {
                MensagemCatraca = $"Erro: Matrícula {matriculaCatraca} não encontrada.";
            }
            else if (frequencia.ValidarERegistrarAcesso(aluno))
            {
                MensagemCatraca = $"Acesso LIBERADO para {aluno.Nome} ({frequencia.DataHora:HH:mm:ss}).";
            }
            else
            {
                MensagemCatraca = $"Acesso BLOQUEADO para {aluno.Nome}. Motivo: {aluno.MotivoInativacao}.";
            }
            return RedirectToPage();
        }
    }
}