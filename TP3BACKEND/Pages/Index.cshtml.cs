using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaAcademia.Models;
using SistemaAcademia.Services;
using System.Collections.Generic;

namespace SistemaAcademia.Pages
{
    public class IndexModel : PageModel
    {
        private readonly GerenciadorCSV _gerenciador = new GerenciadorCSV();

        public List<Aluno> Alunos { get; set; } = new List<Aluno>();

        [BindProperty]
        public Aluno NovoAluno { get; set; }

        public void OnGet()
        {
            Alunos = _gerenciador.ListarAlunos();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                NovoAluno.StatusAtivo = true;
                _gerenciador.SalvarAluno(NovoAluno);
            }
            return RedirectToPage();
        }
    }
}