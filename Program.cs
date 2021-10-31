using System;
using dotnet_dio_learn;

namespace DotnetInDio
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            int index = 0;
            string userOption = getUserOptions();

            while (userOption != "5")
            {
                switch (userOption)
                {
                    case "1":
                        // Nome do aluno
                        Console.WriteLine("Informe o nome do aluno.");
                        Aluno aluno = new Aluno();
                        aluno.nome = Console.ReadLine();

                        // Nota do aluno
                        Console.WriteLine("Informe a nota do aluno.");
                        if (decimal.TryParse(Console.ReadLine(), out decimal nota))
                            aluno.nota = nota;
                        else
                            throw new Exception("Nota inválida.");

                        // Adiciona o aluno na lista
                        alunos[index] = aluno;
                        index++;

                        break;
                    case "2":
                        // Imprime os alunos
                        foreach (var item in alunos)
                        {
                            if (item != null)
                                Console.WriteLine($"Nome: {item.nome} - Nota: {item.nota}");
                        }
                        break;
                    case "3":
                        // TODO: Calcular média geral.
                        var total = 0.0m;
                        var count = 0;
                        foreach (var item in alunos)
                        {
                            if (item != null)
                            {
                                total += item.nota;
                                count++;
                            }
                        }

                        var media = total / count;
                        Conceito conceito;
                        if (media <= 3)
                            conceito = Conceito.E;
                        else if (media <= 5)
                            conceito = Conceito.D;
                        else if (media <= 7)
                            conceito = Conceito.C;
                        else if (media <= 9)
                            conceito = Conceito.B;
                        else
                            conceito = Conceito.A;

                        Console.WriteLine($"A média da turma é: {media} - Conceito: {conceito}");
                        break;
                    case "4":
                        // TODO: Calcular média por aluno.
                        break;
                    default:
                        Console.WriteLine("Opção inválida, tente novamente.");
                        break;
                }

                userOption = getUserOptions();
            }
        }

        private static string getUserOptions()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1. Insira um novo aluno.");
            Console.WriteLine("2. Listar alunos.");
            Console.WriteLine("3. Calcular média geral.");
            Console.WriteLine("4. Calcular média por aluno.");
            Console.WriteLine("5. Sair.");
            Console.WriteLine();

            string userOption = Console.ReadLine();
            return userOption;
        }
    }
}
