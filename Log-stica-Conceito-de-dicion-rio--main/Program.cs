using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Dicionário para armazenar código de rastreio (chave) e código de barras (valor)
        Dictionary<string, string> pacotes = new Dictionary<string, string>();

        Console.WriteLine("Sistema de Gerenciamento de Pacotes de Entrega");
        Console.WriteLine("==============================================");

        // Loop para inserção de pacotes
        while (true)
        {
            Console.WriteLine("\nOpções:");
            Console.WriteLine("1. Adicionar um novo pacote");
            Console.WriteLine("2. Finalizar inserções e ir para busca");
            Console.Write("Escolha uma opção (1 ou 2): ");
            string opcao = Console.ReadLine();

            if (opcao == "1")
            {
                Console.Write("Digite o código de rastreio: ");
                string rastreio = Console.ReadLine().Trim();

                if (string.IsNullOrEmpty(rastreio))
                {
                    Console.WriteLine("Código de rastreio não pode ser vazio. Tente novamente.");
                    continue;
                }

                if (pacotes.ContainsKey(rastreio))
                {
                    Console.WriteLine("Erro: Código de rastreio já existe! Não foi possível adicionar.");
                }
                else
                {
                    Console.Write("Digite o código de barras da encomenda: ");
                    string barras = Console.ReadLine().Trim();

                    if (string.IsNullOrEmpty(barras))
                    {
                        Console.WriteLine("Código de barras não pode ser vazio. Tente novamente.");
                        continue;
                    }

                    pacotes[rastreio] = barras;
                    Console.WriteLine("Pacote adicionado com sucesso!");
                }
            }
            else if (opcao == "2")
            {
                break;
            }
            else
            {
                Console.WriteLine("Opção inválida. Tente novamente.");
            }
        }

        // Verificar se há pacotes para buscar
        if (pacotes.Count == 0)
        {
            Console.WriteLine("Nenhum pacote foi adicionado. Encerrando o programa.");
            return;
        }

        // Loop para buscas
        while (true)
        {
            Console.WriteLine("\nOpções de Busca:");
            Console.WriteLine("1. Procurar por código de rastreio");
            Console.WriteLine("2. Procurar por código de barras");
            Console.WriteLine("3. Sair");
            Console.Write("Escolha uma opção (1, 2 ou 3): ");
            string opcaoBusca = Console.ReadLine();

            if (opcaoBusca == "1")
            {
                Console.Write("Digite o código de rastreio: ");
                string rastreioBusca = Console.ReadLine().Trim();

                if (pacotes.ContainsKey(rastreioBusca))
                {
                    Console.WriteLine($"Pacote encontrado! Código de rastreio: {rastreioBusca}, Código de barras: {pacotes[rastreioBusca]}");
                }
                else
                {
                    Console.WriteLine("Pacote não encontrado com esse código de rastreio.");
                }
            }
            else if (opcaoBusca == "2")
            {
                Console.Write("Digite o código de barras: ");
                string barrasBusca = Console.ReadLine().Trim();

                bool encontrado = false;
                foreach (var par in pacotes)
                {
                    if (par.Value == barrasBusca)
                    {
                        Console.WriteLine($"Pacote encontrado! Código de rastreio: {par.Key}, Código de barras: {par.Value}");
                        encontrado = true;
                        break; // Como códigos de barras podem ser únicos, paramos na primeira ocorrência
                    }
                }

                if (!encontrado)
                {
                    Console.WriteLine("Pacote não encontrado com esse código de barras.");
                }
            }
            else if (opcaoBusca == "3")
            {
                Console.WriteLine("Encerrando o programa. Até logo!");
                break;
            }
            else
            {
                Console.WriteLine("Opção inválida. Tente novamente.");
            }
        }
    }
}
