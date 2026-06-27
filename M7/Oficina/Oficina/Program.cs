using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace Oficina
{
    internal class Program
    {   
        public class Clientes
        {
            public int ID { get; set; }
            public string Nome { get; set; }
            public string Email { get; set; }
            public string Telemovel { get; set; }


        }
        public static void Digite ()
        {
            Console.WriteLine("Digite Qualquer Coisa Para Avançar ...");
            Console.ReadKey();
            Console.Clear();
        }

        static void Main(string[] args)
        {

            string FichaClientes = "clientes.txt";
            string FichaAutomoveis = "automoveis.txt";
            int Pescolha, opcao, id = 0, linhas;
            List<Clientes> ListaClientes = new List<Clientes>();


            if (!File.Exists(FichaClientes))
            {
                File.Create(FichaClientes).Close();
                Console.WriteLine("O ficheiro 'clientes.txt' não existia e foi criado automaticamente!");
            }

            if (!File.Exists(FichaAutomoveis))
            {
                File.Create(FichaAutomoveis).Close();
                Console.WriteLine("O ficheiro 'Automoveis.txt não existia e foi criado automaticamente!");
            }

            if (File.Exists(FichaClientes))
            {
                using (StreamReader sr = new StreamReader(FichaClientes))
                {
                    while (!sr.EndOfStream)
                    {
                        string linha = sr.ReadLine();
                        if (!string.IsNullOrWhiteSpace(linha))
                        {
                            id++;
                        }
                    }
                }
            }


            do
                {
                    //MENU PRINCIPAL
                    Console.Clear();
                    Console.WriteLine("======= Oficina =======");
                    Console.Write("\nDigite\n [1] - Menu clientes\n [2] - Menu automoveis\n [3] - Pesquisas \n [0] - Sair \nOpção: ");
                    do
                    {
                        while (!int.TryParse(Console.ReadLine(), out Pescolha))
                        {
                            Console.WriteLine("Digite apneas números inteiros");
                        }
                        if (Pescolha > 3 || Pescolha < 0)
                        {
                            Console.WriteLine("Digite apenas números entre [0-3]");
                        }
                    } while (Pescolha > 3 || Pescolha < 0);
                    Console.Clear();


                    switch (Pescolha)
                    {
                        //CASO 1 
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
                            Console.Clear();
                            switch (opcao)
                            {
                                //CASO 1 DENTRO DO CASO 1
                                case 1:
                                    Clientes NovoCliente = new Clientes();
                                    string telemovel;
                                    id++;

                                    NovoCliente.ID = id;
                                    Console.WriteLine("======= Novo Cliente =======");
                                    Console.Write("\nDigite o Nome: ");
                                    NovoCliente.Nome = Console.ReadLine();
                                    Console.Write("\nDigite o Email: ");
                                    NovoCliente.Email = Console.ReadLine();
                                    Console.Write("\nDigite o Telemovel: ");
                                    telemovel = Console.ReadLine();

                                    while (true)
                                    {
                                        if (telemovel.Length == 9 && long.TryParse(telemovel, out _))
                                        {
                                            NovoCliente.Telemovel = telemovel;
                                            break;
                                        }
                                        Console.WriteLine("O número de telemovel deve de ter 9 digitos (todos numeros)");
                                        Console.Write("\nDigite novamente o número de telemovel: ");
                                        telemovel = Console.ReadLine();
                                    }
                                    using (StreamWriter sw = new StreamWriter(FichaClientes, true))
                                    {
                                        sw.WriteLine($"{NovoCliente.ID}   {NovoCliente.Nome}   {NovoCliente.Email}   {NovoCliente.Telemovel}");
                                    }
                                    Console.Clear();

                                    Console.WriteLine("======= Dados do Cliente =======");
                                    Console.WriteLine($"ID: {NovoCliente.ID}\nNome: {NovoCliente.Nome}\nEmail: {NovoCliente.Email}\nTelemóvel: {NovoCliente.Telemovel}");
                                    Digite();
                                    break;

                                //CASO 2 DENTRO DO CASO 1    
                                case 2:

                                if (id != 0)
                                {
                                    using (StreamReader sr = new StreamReader(FichaClientes))
                                    {
                                        while (!sr.EndOfStream)
                                        {
                                            string linha = sr.ReadLine();
                                            Console.WriteLine("Lido do ficheiro: " + linha);
                                        }

                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Não existe nenhum cliente ainda");
                                }

                                Digite();
                                    break;

                            //CASO 3 DENTRO DO CASO 1
                            case 3:
                                Console.WriteLine("======= Mostrar Dados de um Cliente (Por ID) =======");
                                Console.Write("Digite o ID do cliente que procura: ");
                                int idProcurado;

                                while (!int.TryParse(Console.ReadLine(), out idProcurado))
                                {
                                    Console.Write("Por favor, digite um ID válido (número inteiro): ");
                                }

                                bool clienteEncontrado = false;

                                using (StreamReader sr = new StreamReader(FichaClientes))
                                {
                                    while (!sr.EndOfStream)
                                    {
                                        string linha = sr.ReadLine();

                                        if (!string.IsNullOrWhiteSpace(linha))
                                        {

                                            string[] partes = linha.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                                            if (partes.Length >= 4 && int.TryParse(partes[0], out int idLinha))
                                            {
                                                if (idLinha == idProcurado)
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("======= Cliente Encontrado =======");
                                                    Console.WriteLine($"ID: {partes[0]}");
                                                    Console.WriteLine($"Nome: {partes[1]}");
                                                    Console.WriteLine($"Email: {partes[2]}");
                                                    Console.WriteLine($"Telemóvel: {partes[3]}");

                                                    clienteEncontrado = true;
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                }

                                if (!clienteEncontrado)
                                {
                                    Console.WriteLine($"\nNão foi encontrado nenhum cliente com o ID {idProcurado}.");
                                }

                                Digite();
                                break;

                        }
                            break;
                        //CASO 2
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

                        //CASO 3
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
                                    Console.WriteLine("Digite apenas números entre [0-1]");
                                }
                            } while (opcao > 1 || opcao < 0);

                            break;
                    }
                } while (Pescolha != 0);
        }
    }
}
