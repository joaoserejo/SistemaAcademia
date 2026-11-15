using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using SistemaAcademia.Models;

namespace SistemaAcademia.Services
{
    public class GerenciadorCSV
    {
        private readonly string _arquivoAlunos = "alunos.csv";
        private readonly string _arquivoAvaliacoes = "avaliacoes.csv";

        public void SalvarAluno(Aluno aluno)
        {
            using (StreamWriter sw = new StreamWriter(_arquivoAlunos, true))
            {
                sw.WriteLine(aluno.ToCSV());
            }
        }

        public List<Aluno> ListarAlunos()
        {
            var alunos = new List<Aluno>();
            if (File.Exists(_arquivoAlunos))
            {
                using (StreamReader sr = new StreamReader(_arquivoAlunos))
                {
                    string linha;
                    while ((linha = sr.ReadLine()) != null)
                    {
                        string[] dados = linha.Split(';');
                        if (dados.Length >= 4)
                        {
                            alunos.Add(new Aluno
                            {
                                Matricula = int.Parse(dados[0]),
                                Nome = dados[1],
                                Cpf = dados[2],
                                StatusAtivo = bool.Parse(dados[3]),
                                MotivoInativacao = dados.Length >= 5 ? dados[4] : "-"
                            });
                        }
                    }
                }
            }
            return alunos;
        }

        public void InativarAluno(int matricula, string motivo)
        {
            var alunos = ListarAlunos();
            var aluno = alunos.FirstOrDefault(a => a.Matricula == matricula);
            if (aluno != null)
            {
                aluno.InativarMatricula(motivo);
                using (StreamWriter sw = new StreamWriter(_arquivoAlunos, false))
                {
                    foreach (var a in alunos)
                    {
                        sw.WriteLine(a.ToCSV());
                    }
                }
            }
        }

        public void SalvarAvaliacao(AvaliacaoFisica avaliacao)
        {
            using (StreamWriter sw = new StreamWriter(_arquivoAvaliacoes, true))
            {
                sw.WriteLine(avaliacao.ToCSV());
            }
        }

        public List<AvaliacaoFisica> ListarAvaliacoes()
        {
            var lista = new List<AvaliacaoFisica>();
            if (File.Exists(_arquivoAvaliacoes))
            {
                using (StreamReader sr = new StreamReader(_arquivoAvaliacoes))
                {
                    string linha;
                    while ((linha = sr.ReadLine()) != null)
                    {
                        string[] dados = linha.Split(';');
                        if (dados.Length == 6)
                        {
                            lista.Add(new AvaliacaoFisica
                            {
                                MatriculaAluno = int.Parse(dados[0]),
                                DataAvaliacao = DateTime.ParseExact(dados[1], "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture),
                                Peso = double.Parse(dados[2], CultureInfo.InvariantCulture),
                                Altura = double.Parse(dados[3], CultureInfo.InvariantCulture),
                                PercentualGordura = double.Parse(dados[4], CultureInfo.InvariantCulture),
                                Imc = double.Parse(dados[5], CultureInfo.InvariantCulture)
                            });
                        }
                    }
                }
            }
            return lista;
        }
    }
}