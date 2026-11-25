
# 🏋️ SistemaAcademia — Sistema de Gerenciamento de Academia

Aplicação web desenvolvida em **C# (ASP.NET Core Razor Pages)** para informatizar a rotina operacional de uma academia de ginástica, abrangendo controle de matrículas, validação de acesso em catraca, prescrição de treinos, avaliações físicas e gestão financeira.

Projeto desenvolvido como entrega final consolidada (**TP5 — Fase de Construção / RUP**) para a disciplina de **Projeto de Bloco** do curso de **Engenharia de Software (Instituto Infnet)**.

---

## 📋 Funcionalidades Implementadas

* **Gestão de Alunos e Trancamento (`UC01`):** Cadastro de novos alunos, consulta de situação cadastral e trancamento/inativação de matrícula com registro de motivo na recepção.
* **Controle de Acesso na Catraca (`UC02`):** Validação em tempo real da situação cadastral (`StatusAtivo`) na catraca, liberando ou bloqueando a entrada e gravando o histórico completo de frequência (`frequencias.csv`).
* **Prescrição de Treinos (`UC03`):** Criação de fichas de treino personalizadas vinculadas ao aluno e ao professor responsável (CREF), com adição dinâmica de exercícios, séries e repetições (`treinos.csv`).
* **Avaliação Física e IMC (`UC04`):** Registro antropométrico (peso, altura e percentual de gordura) com cálculo e classificação automática do Índice de Massa Corporal (`avaliacoes.csv`).
* **Gestão de Planos e Pagamentos (`UC05`):** Cadastro de pacotes de assinatura (`planos.csv`) e baixa de mensalidades (`pagamentos.csv`), reativando automaticamente matrículas que estavam trancadas ou inativas.
* **Gestão de Equipe:** Cadastro e listagem de Professores (`professores.csv`) e Funcionários administrativos (`funcionarios.csv`).

---

## 🏗️ Arquitetura e Orientação a Objetos

O sistema foi estruturado aplicando os pilares da Programação Orientada a Objetos (herança, encapsulamento e responsabilidade única) e persistência relacional em arquivos `.csv`:

```text
SistemaAcademia/
├── Models/                     # Entidades de domínio
│   ├── Usuario.cs              # Superclasse base (IdUsuario, Nome, Cpf, Senha)
│   ├── Aluno.cs                # Herda de Usuario (Matricula, StatusAtivo, MotivoInativacao)
│   ├── Professor.cs            # Herda de Usuario (Cref, Especialidade)
│   ├── Funcionario.cs          # Herda de Usuario (Cargo, Turno)
│   ├── Plano.cs                # Planos e mensalidades
│   ├── Pagamento.cs            # Transações financeiras e ativação de matrícula
│   ├── Treino.cs               # Fichas de treino vinculadas a Aluno e Professor
│   ├── Exercicio.cs            # Exercícios que compõem um Treino
│   ├── Frequencia.cs           # Registros de entrada/bloqueio na catraca
│   └── AvaliacaoFisica.cs      # Medidas físicas, cálculo e classificação de IMC
├── Services/
│   └── GerenciadorCSV.cs       # Camada de persistência e leitura/escrita em arquivos .csv
└── Pages/                      # Interface Web (Razor Pages + Bootstrap 5)
    ├── Index.cshtml            # Alunos, Catraca & Avaliação Física
    ├── Equipe.cshtml           # Cadastro de Professores e Funcionários
    ├── Financeiro.cshtml       # Planos e Registro de Pagamentos
    └── Treinos.cshtml          # Prescrição de Treinos e Exercícios
🛠️ Tecnologias Utilizadas
Linguagem: C# (.NET 8)

Framework Web: ASP.NET Core Razor Pages

Front-end: HTML5, CSS3 e Bootstrap 5

Persistência: Arquivos locais estruturados em CSV (System.IO)

Modelagem e Processo: UML e RUP (Rational Unified Process)

🚀 Como Executar o Projeto
Clone este repositório ou baixe os arquivos do projeto.

Abra o arquivo de solução SistemaAcademia.sln no Visual Studio 2022 (ou superior).

Pressione F5 (ou clique em Executar) para iniciar a aplicação no navegador.

Os arquivos .csv de armazenamento são criados e atualizados automaticamente na raiz do projeto conforme os cadastros são realizados.

👨‍💻 Autor
João Paulo de Oliveira Serejo

Graduando em Engenharia de Software — Instituto Infnet


### Como adicionar ao seu repositório agora:
1. No **Gerenciador de Soluções** do Visual Studio, clique com o botão direito no projeto **`SistemaAcademia`** > **Adicionar** > **Novo Item** (ou crie um arquivo de texto na pasta raiz chamado exatamente **`README.md`**).
2. Cole o conteúdo acima, salve (`Ctrl + S`) e envie pelo terminal integrado (`Ctrl + '`):
   ```bash
   git add README.md
   git commit -m "Adiciona README.md com documentacao do projeto"
   git push
