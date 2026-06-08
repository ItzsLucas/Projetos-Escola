using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    internal class Program
    {
        static public void Digite()
        {
            Console.WriteLine("Digite alguma tecla para avançar...");
            Console.ReadKey();
            Console.Clear();
        }
        static void Main(string[] args)
        {
            int Pescolha, contador = 0;
            string nome;
            Queue<string> FilaDeEspera = new Queue<string>();

            do
            {
                Console.WriteLine("======= Queue =======");
                Console.Write("\nDigite\n [1] Para adicionar cliente\n [2] Para atender proximo\n [3] Para ver proximo cliente\n [4] Para Listar clientes\n [0] Para sair\nOpção: ");
                do
                {
                    while(!int.TryParse(Console.ReadLine(),out Pescolha))
                    {
                        Console.WriteLine("Digite apenas numeros inteiros");
                    }
                    if(Pescolha < 0 || Pescolha > 4)
                    {
                        Console.WriteLine("Digite apenas numeros entre [0-4]");
                    }
                    Console.Write("Opção: ");
                } while (Pescolha < 0 || Pescolha > 4);
                Console.Clear();
                switch(Pescolha)
                {
                    case 1:
                        contador++;
                        Console.WriteLine("======= Adicionar cliente =======");
                        Console.Write("Bem vindo, qual o seu nome: ");
                        nome = Console.ReadLine();
                        FilaDeEspera.Enqueue(nome);
                        Console.WriteLine($"Bem vindo {nome}, o seu ticket é o Nº{contador}");
                        Digite();
                        break;

                    case 2:
                        if(FilaDeEspera.Count == 0)
                        {
                            Console.WriteLine("Adicione algum cliente primeiro");
                            Digite();
                        }
                        else
                        {
                            Console.WriteLine("======= Atender cliente =======");
                            Console.WriteLine($"O clentem {FilaDeEspera.Peek()} foi atendido");
                            FilaDeEspera.Dequeue();
                            Digite();
                        }
                        
                        break;

                    case 3:
                        if (FilaDeEspera.Count == 0)
                        {
                            Console.WriteLine("Adicione algum cliente primeiro");
                            Digite();
                        }
                        else
                        {
                            Console.WriteLine("======= Ver proximo cliente =======");
                            Console.WriteLine($"O proximo cliente é o {FilaDeEspera.Peek()}");
                            Digite();
                        }

                        break;

                    case 4:
               
                        Console.WriteLine("======= Ver lista de clientes =======");

                        foreach(string item in FilaDeEspera)
                        {
                            Console.WriteLine($"{item}");
                        }
                        Digite();

                        break;
                }
            } while (Pescolha != 0);
        }
    }
}
