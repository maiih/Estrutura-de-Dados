using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Dicionário: chave = código de rastreio | valor = código de barras
        Dictionary<string, string> encomendas = new Dictionary<string, string>();

        bool continuar = true;

        while (continuar)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n--- MENU LOGÍSTICO ---");
            Console.ResetColor();
            Console.WriteLine("1) Registrar pacote");
            Console.WriteLine("2) Buscar por código de rastreio");
            Console.WriteLine("3) Buscar por código de barras");
            Console.WriteLine("4) Sair");
            Console.Write("Escolha uma opção: ");

            string opcao = Console.ReadLine();
            Console.WriteLine();

            switch (opcao)
            {
                // -----------------------------------------------------------
                // 1) INSERIR
                // -----------------------------------------------------------
                case "1":
                    Console.Write("Digite o código de rastreio: ");
                    string rastreio = Console.ReadLine();

                    // evita rastreio duplicado
                    if (encomendas.ContainsKey(rastreio))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("⚠ Este código de rastreio já está registrado!");
                        Console.ResetColor();
                        break;
                    }

                    Console.Write("Digite o código de barras da encomenda: ");
                    string codigoBarras = Console.ReadLine();

                    // evita valor duplicado (código de barras já usado)
                    if (encomendas.ContainsValue(codigoBarras))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("⚠ Este código de barras já foi usado em outro pacote!");
                        Console.ResetColor();
                        break;
                    }

                    encomendas.Add(rastreio, codigoBarras);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("✓ Pacote registrado com sucesso!");
                    Console.ResetColor();
                    break;

                // -----------------------------------------------------------
                // 2) BUSCAR POR RASTREIO
                // -----------------------------------------------------------
                case "2":
                    Console.Write("Digite o código de rastreio: ");
                    string buscaRastreio = Console.ReadLine();

                    if (encomendas.ContainsKey(buscaRastreio))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"📦 Código de barras: {encomendas[buscaRastreio]}");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Nenhum pacote encontrado com esse código de rastreio.");
                    }
                    Console.ResetColor();
                    break;

                // -----------------------------------------------------------
                // 3) BUSCAR POR CÓDIGO DE BARRAS
                // -----------------------------------------------------------
                case "3":
                    Console.Write("Digite o código de barras: ");
                    string buscaCodigo = Console.ReadLine();

                    bool encontrado = false;

                    foreach (var item in encomendas)
                    {
                        if (item.Value == buscaCodigo)
                        {
                            encontrado = true;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"📦 Código de rastreio correspondente: {item.Key}");
                            break;
                        }
                    }

                    if (!encontrado)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Nenhuma encomenda utiliza esse código de barras.");
                    }
                    Console.ResetColor();
                    break;

                // -----------------------------------------------------------
                // 4) SAIR
                // -----------------------------------------------------------
                case "4":
                    continuar = false;
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Opção inválida!");
                    Console.ResetColor();
                    break;
            }
        }

        Console.WriteLine("\nSistema encerrado.");
    }
}
