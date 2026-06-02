using System;
using System.Collections.Generic;

namespace LeaderBoard_Alunos
{
    internal class Program
    {
        static public void Digite()
        {
            Console.WriteLine("\nDigite algo para avançar...");
            Console.ReadKey();
            Console.Clear();
        }

        static void Main(string[] args)
        {
            List<float> notas = new List<float>();
            List<string> nomes = new List<string>();

            int Pescolha;
            string nome, NomeRemover;
            float nota;
            bool Valida = false;

            do
            {
                Console.WriteLine("======= Gestor da Turma =======");
                Console.Write("\nDigite:\n [1] Para adicionar aluno\n [2] Para remover aluno\n [3] Para pesquisar aluno\n [4] Para listar alunos\n [0] Para sair\n\nOpção: ");
                do
                {
                    while (!int.TryParse(Console.ReadLine(), out Pescolha))
                    {
                        Console.Write("Digite apenas números inteiros: ");
                    }
                    if (Pescolha < 0 || Pescolha > 4)
                    {
                        Console.Write("Digite apenas números entre [0-4]: ");
                    }
                } while (Pescolha < 0 || Pescolha > 4);

                Console.Clear();

                switch (Pescolha)
                {
                    case 1:
                        Console.WriteLine("======= Adicionar Aluno =======");
                        Console.Write("Digite o nome do aluno: ");
                        nome = Console.ReadLine();

                        Console.Write("Digite a nota do aluno (0-20): ");
                        do
                        {
                            while (!float.TryParse(Console.ReadLine(), out nota))
                            {
                                Console.Write("Digite apenas números: ");
                            }
                            if (nota > 20 || nota < 0)
                            {
                                Console.Write("Digite apenas números entre [0-20]: ");
                            }
                        } while (nota > 20 || nota < 0);

                        nomes.Add(nome);
                        notas.Add(nota);

                        Console.WriteLine($"\nO aluno {nome} foi adicionado com a nota {nota}!");
                        Digite();
                        break;

                    case 2:
                        Valida = false;
                        if (nomes.Count < 1)
                        {
                            Console.WriteLine("É necessário ter alunos registados para usar esta função.");
                        }
                        else
                        {
                            Console.WriteLine("======= Remover Aluno =======");
                            Console.Write("Digite o nome do aluno que deseja remover: ");
                            NomeRemover = Console.ReadLine();

                            for (int i = 0; i < nomes.Count; i++)
                            {
                                if (nomes[i].ToLower() == NomeRemover.ToLower())
                                {
                                    Console.WriteLine($"O aluno {nomes[i]} com a nota {notas[i]} foi removido.");
                                    nomes.RemoveAt(i);
                                    notas.RemoveAt(i);
                                    Valida = true;
                                    break;
                                }
                            }

                            if (!Valida)
                            {
                                Console.WriteLine("Aluno não encontrado.");
                            }
                        }
                        Digite();
                        break;

                    case 3:
                        Valida = false;
                        if (nomes.Count < 1)
                        {
                            Console.WriteLine("É necessário ter alunos registados para usar esta função.");
                        }
                        else
                        {
                            Console.WriteLine("======= Procurar Aluno =======");
                            Console.Write("Digite o nome do aluno que deseja procurar: ");
                            string nomeProcurar = Console.ReadLine();

                            for (int i = 0; i < nomes.Count; i++)
                            {
                                if (nomes[i].ToLower() == nomeProcurar.ToLower())
                                {
                                    Console.WriteLine($"\nAluno encontrado! -> Posição {i + 1}º | Nome: {nomes[i]} | Nota: {notas[i]}");
                                    Valida = true;
                                }
                            }

                            if (!Valida)
                            {
                                Console.WriteLine("Aluno não encontrado.");
                            }
                        }
                        Digite();
                        break;

                    case 4:
                        Console.WriteLine("======= Listar Alunos =======");
                        if (nomes.Count == 0)
                        {
                            Console.WriteLine("Nenhum aluno registado.");
                        }
                        else
                        {
                            for (int i = 0; i < nomes.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}º - Aluno: {nomes[i]} | Nota: {notas[i]} valores");
                            }
                        }
                        Digite();
                        break;
                }
            } while (Pescolha != 0);

            Console.WriteLine("Obrigado por utilizar o nosso programa!");
            Console.ReadKey();
        }
    }
}
