using System;
using System.Collections;

class Program
{
static void Main()
{
// --------------------------------------------------------
// Criação da Hashtable
// --------------------------------------------------------
// A Hashtable armazena pares chave-valor, porém SEM tipagem forte.
// Tanto a chave quanto o valor são armazenados como "object".
// Por isso ela é mais antiga e menos recomendada que Dictionary.
Hashtable phoneBook = new Hashtable()
{
{ "Maria", "1111-1111" },
{ "João", "2222-2222" },
{ "Pedro", "3333-3333" }
};

    bool continuar = true;

    // --------------------------------------------------------
    // Loop para consultar a agenda
    // --------------------------------------------------------
    while (continuar)
    {
        Console.Write("Digite o nome para buscar o telefone (ou 'sair'): ");
        string nomeDigitado = Console.ReadLine();

        // Se o usuário digitar "sair", terminamos o programa
        if (nomeDigitado.ToLower() == "sair")
        {
            continuar = false;
            continue;
        }

        // --------------------------------------------------------
        // Verifica se existe uma entrada com essa chave
        // --------------------------------------------------------
        if (phoneBook.ContainsKey(nomeDigitado))
        {
            // Como Hashtable não usa tipagem forte,
            // precisamos pegar o valor como object
            string telefone = phoneBook[nomeDigitado].ToString();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Telefone de {nomeDigitado}: {telefone}");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        else
        {
            Console.WriteLine("Nome não encontrado na agenda.");
        }

        Console.WriteLine();
    }

    Console.WriteLine("Programa encerrado.");
}

}