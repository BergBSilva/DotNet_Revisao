using System;

namespace REVISAO
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[2];
            var indiceAluno = 0;
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario != "4")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        Console.WriteLine("Informe o nome do aluno:");
                        var aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();

                        Console.WriteLine("Informe a nota do aluno:");

                        if (decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {
                            aluno.Nota = nota;
                        }
                        else
                        {
                            throw new ArgumentException("Valor da nota deve ser decimal");
                        }

                        alunos[indiceAluno] = aluno;
                        indiceAluno += 1;

                        break;
                    case "2":
                        foreach (var a in alunos)
                        {
                            if (!string.IsNullOrEmpty(a.Nome))
                            {
                                Console.WriteLine($"ALUNO: {a.Nome} - NOTA: {a.Nota}");
                            }
                        }
                        break;
                    case "3":
                        decimal notaTotal = 0;
                        var nrAlunos = 0;

                        for (int i=0; i < alunos.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(alunos[i].Nome))
                            {
                                notaTotal = notaTotal + alunos[i].Nota;
                                nrAlunos++;
                            }
                        }

                        var mediaGeral = notaTotal / nrAlunos;
                        Conceito conceitoGeral = mediaGeral switch{
                            < 2 => Conceito.E,
                            < 4 => Conceito.D,
                            < 6 => Conceito.C,
                            < 8 => Conceito.B,
                            _ => Conceito.A
                        }; 
                        
                        /*var possibilidades = new Dictionary<int, Conceito>() {
                        {0, Conceito.E},
                        {1, Conceito.E},
                        {2, Conceito.E},
                        {3, Conceito.D},
                        {4, Conceito.D},
                        {5, Conceito.C},
                        {6, Conceito.C},
                        {7, Conceito.B},
                        {8, Conceito.B},
                        {9, Conceito.A},
                        {10, Conceito.A},
                        };
                        
                        conceitoGeral = possibilidades[(int) mediaGeral];
                       */  
                        Console.WriteLine($"MÉDIA GERAL: {mediaGeral} - CONCEITO: {conceitoGeral}");

                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1 - Inserir novo aluno");
            Console.WriteLine("2 - Listar alunos");
            Console.WriteLine("3 - Calcular média geral");
            Console.WriteLine("4 - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}