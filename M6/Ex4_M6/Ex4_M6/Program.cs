using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ex4_M6
{
    internal class Program
    {
        static public void Digite ()
        {
            Console.WriteLine("Digite algo para continuar...");
            Console.ReadKey();
            Console.Clear();
        }


        static void Main(string[] args)
        {
            int Pescolha;
            List<string> carrugaem = new List<string>();
            string objeto;

            do
            {
                Console.WriteLine("======= Carruagens do comboio =======");
                Console.Write("\nDigite\n [1] Para inserir carruagem\n [2] Para remover carruagem\n [3] Listar carruagens\n [0] Para sair\nOpção: ");

                do
                {
                    while (!int.TryParse(Console.ReadLine(), out Pescolha))
                    {
                        Console.Write("\nDigite apenas numeros inteiros: ");
                    }
                    if (Pescolha > 3 || Pescolha < 0)
                    {
                        Console.WriteLine("Digite apenas numeros entre [0-3]");
                    }
                } while (Pescolha > 3 || Pescolha < 0);
                Console.Clear();

                switch (Pescolha)
                {
                    case 1:

                        Console.WriteLine("======= Adicionar carruagem =======");
                        Console.Write("\nDigite o objeto que deseja ter na carrugem: ");
                        objeto = Console.ReadLine();
                        carrugaem.Add(objeto);
                        Console.WriteLine($"A carruagem com {objeto} foi adiconada ao comboio...");
                        Digite();

                        break;
                    case 2:

                        Console.WriteLine("======= Remover Carruagem =======");
                        Console.Write("\nDigite o objeto que deseja remover na carrugem: ");
                        objeto = Console.ReadLine();
                        foreach (string item in carrugaem)
                        {
                            if (objeto == item)
                            {
                                carrugaem.Remove(objeto);
                                Console.WriteLine($"O objeto: {objeto} foi removido do comboio");
                                break;
                            }
                        }
                        Digite();
                        break;

                    case 3:

                        Console.WriteLine("======= Listar Comboio =======");
                        foreach (string item in carrugaem)
                        {
                            Console.WriteLine($"{item}");
                        }
                        Digite();
                        break;
                }

            } while (Pescolha != 0);
            Console.WriteLine("Obrigado por utilizar o nosso programa");

        }
    }
}
