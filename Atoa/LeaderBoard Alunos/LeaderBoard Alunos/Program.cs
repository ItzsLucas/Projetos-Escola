using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderBoard_Alunos
{
    internal class Program
    {
        static public void Digite()
        {
            Console.WriteLine("Digite slgo para avançar...");
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
            do
            {

                Console.WriteLine("======= Gestor da Turma =======");
                Console.Write("\nDigite\n [1] Para adicionar aluno\n [2] Para remover aluno\n [3] Para pesquisar aluno\n [4] Para listar alunos\n [5] Para procurar aluno\n [0] Para sair\nOpção: ");
                do
                {
                    while (!int.TryParse(Console.ReadLine(), out Pescolha))
                    {
                        Console.WriteLine("Digite apenas numeros inteiros");
                    }
                    if (Pescolha < 0 || Pescolha > 5)
                    {
                        Console.WriteLine("Digite apenas numeros entre [0-5]");
                    }
                    Console.Write("\nOpção: ");
                } while (Pescolha < 0 || Pescolha > 5);
                Console.Clear();
                switch(Pescolha)
                {
                    case 1:
                        Console.WriteLine("======= Adicionar Aluno =======");
                        Console.Write("Digite o nome do aluno: ");
                        nome = Console.ReadLine();
                        Console.Write("Digite a nota do aluno: ");

                        do
                        {
                            while (!float.TryParse(Console.ReadLine(), out nota))
                            {
                                Console.WriteLine("Digite apenas numeros");
                            }
                            if (nota > 20 || nota < 0)
                            {
                                Console.WriteLine("Digite apenas numeros entre [0-20]");
                            }
                            Console.Write("\nOpção: ");

                        } while (nota > 20 || nota < 0);

                        Console.WriteLine("======= Adicionar Aluno =======");
                        nomes.Add(nome);
                        notas.Add(nota);
                        Console.WriteLine($"O aluno {nome} foi adicionado com a nota {nota}");
                        Digite();
                        break;

                    case 2:
                        if (nomes.Count < 1)
                        {
                            Console.WriteLine("É necessário ter alunos registrados par usar esta funçao");
                        }
                        else
                        {
                            int contador = 0, contador2 = 0;
                            Console.WriteLine("======= Remover Aluno =======");
                            Console.Write("\nDigite o nome do aluno que deseja remover: ");
                            NomeRemover = Console.ReadLine();
                            foreach(string item in nomes)
                            {
                                if(NomeRemover == item)
                                {
                                    nomes.Remove(NomeRemover);
                                }
                                else
                                {
                                    contador++;
                                }
                            }
                            foreach(float item in notas)
                            {
                                if (contador == contador2)
                                {
                                    notas.Remove(item);
                                }

                                else
                                {
                                    contador2++;
                                }
                            }
                        }
                        Digite();

                        break;
                }
            } while (Pescolha != 0);
        }
    }
}
