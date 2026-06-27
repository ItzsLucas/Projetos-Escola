using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Oficina
{
    internal class Program
    {

        public static void Digite ()
        {
            Console.WriteLine("Digite Qualquer Coisa Para Avançar ...");
            Console.ReadKey();
            Console.Clear();
        }
        static void Main(string[] args)
        {
            string clientes = "clientes.txt";
            string automoveis = "automoveis.txt";
            int Pescolha, opcao;

            do
            {
                Console.Clear();
                Console.WriteLine("======= Oficina =======");
                Console.Write("\nDigite\n [1] - Menu clientes\n [2] - Menu automoveis\n [3] - Pesquisas \n [0] - Sair \nOpção: ");
                do
                {
                    while(!int.TryParse(Console.ReadLine(),out Pescolha))
                    {
                        Console.WriteLine("Digite apneas números inteiros");
                    }
                    if(Pescolha > 3 || Pescolha < 0)
                    {
                        Console.WriteLine("Digite apenas números entre [0-3]");
                    }
                } while (Pescolha > 3 || Pescolha < 0);
                Console.Clear();


                switch(Pescolha)
                {
                    case 1:
                        Console.WriteLine("======= Menu Clientes =======");
                        Console.Write("\nDigite\n [1] - Inserir Novo Cliente\n [2] - Ver Clientes\n [3] - Mostrar Dados de um Cliente (Por ID)\n [0] - Voltar ao Menu Principal \nOpção: ");
                        do
                        {
                            while (!int.TryParse(Console.ReadLine(), out opcao))
                            {
                                Console.WriteLine("Digite apneas números inteiros");
                            }
                            if (opcao > 3 || opcao < 0)
                            {
                                Console.WriteLine("Digite apenas números entre [0-3]");
                            }
                        } while (opcao > 3 || opcao < 0);


                        break;

                    case 2:

                        Console.WriteLine("======= Menu Automoveis =======");
                        Console.Write("\nDigite\n [1] - Inserir Novo Automovel\n [2] - Ver Todos os Automoveis\n [3] - Mostrar Dados de um Automovel (por ID)\n [0] - Voltar ao Menu Principal \nOpção: ");
                        do
                        {
                            while (!int.TryParse(Console.ReadLine(), out opcao))
                            {
                                Console.WriteLine("Digite apneas números inteiros");
                            }
                            if (opcao > 3 || opcao < 0)
                            {
                                Console.WriteLine("Digite apenas números entre [0-3]");
                            }
                        } while (opcao > 3 || opcao < 0);
                        break;

                    case 3:

                        Console.WriteLine("======= Pesquisas =======");
                        Console.Write("\nDigite \n [1] - Listar Automovel de um Cliente\n [0] - Voltar ao Menu Principal \nOpção:");
                        do
                        {
                            while (!int.TryParse(Console.ReadLine(), out opcao))
                            {
                                Console.WriteLine("Digite apneas números inteiros");
                            }
                            if (opcao > 1 || opcao < 0)
                            {
                                Console.WriteLine("Digite apenas números entre [0-1]111");
                            }
                        } while (opcao > 1 || opcao < 0);

                        break;
                }
            } while (Pescolha != 0);
        }
    }
}
