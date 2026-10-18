using System.Collections.Generic;
using System.IO;
using SistemaAcademia.Models;

namespace SistemaAcademia.Services
{
    public class GerenciadorCSV
    {
        private readonly string _caminhoArquivo = "alunos.csv";

        public void SalvarAluno(Aluno aluno)
        {
            using (StreamWriter sw = new StreamWriter(_caminhoArquivo, true))
            {
                sw.WriteLine(aluno.ToCSV());
            }
        }

        public List<Aluno> ListarAlunos()
        {
            var alunos = new List<Aluno>();
            if (File.Exists(_caminhoArquivo))
            {
                using (StreamReader sr = new StreamReader(_caminhoArquivo))
                {
                    string linha;
                    while ((linha = sr.ReadLine()) != null)
                    {
                        string[] dados = linha.Split(';');
                        if (dados.Length == 4)
                        {
                            alunos.Add(new Aluno
                            {
                                Matricula = int.Parse(dados[0]),
                                Nome = dados[1],
                                Cpf = dados[2],
                                StatusAtivo = bool.Parse(dados[3])
                            });
                        }
                    }
                }
            }
            return alunos;
        }
    }
}