using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace base_de_dados
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string caminho = "dados.txt", input;
            int Pescolha;
            do
            {
                Console.WriteLine("======= Menu =======");
                Console.Write("\nDigite\n [1] Para adicionar\n [2] Para apagar\n [3] Para ver todos\n [0] Para sair\nOpção: ");
                do
                {
                    while (!int.TryParse(Console.ReadLine(), out Pescolha))
                    {
                        Console.Write("\nDigite apenas numeros");
                    }
                    if (Pescolha < 0 || Pescolha > 3)
                    {
                        Console.Write("\nDigite algo entrre [0-3]: ");
                    }
                } while (Pescolha < 0 || Pescolha > 3);

                switch (Pescolha)
                {
                    case 1:

                        using (StreamWriter sw = new StreamWriter(caminho, true))
                        {
                            Console.Write("Digite o que deseja adicionar");
                            input = Console.ReadLine();
                            sw.WriteLine(input);
                        }

                        break;

                    case 3:

                        using (StreamReader sr = new StreamReader(caminho))
                        {
                            while (!sr.EndOfStream)
                            {
                                string linha = sr.ReadLine();
                                Console.WriteLine("Lido do ficheiro: " + linha);
                            }
                        }

                        break;
                }

            } while (Pescolha != 0);
        }
    }
}
