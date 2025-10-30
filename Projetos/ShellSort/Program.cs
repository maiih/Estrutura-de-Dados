using System;

public class ShellSort
{
    public static void Sort(int[] arr)
    {
        int l = arr.Length;

        // Começa com um gap grande e vai diminuindo
        for (int gap = l / 2; gap > 0; gap /= 2)
        {
            // Aplica o Insertion Sort para o gap atual
            for (int i = gap; i < l; i++)
            {
                int atual = arr[i];
                int j;

                // Move os elementos que são maiores que atual
                for (j = i; j >= gap && arr[j - gap] > atual; j -= gap)
                {
                    arr[j] = arr[j - gap];
                }

                arr[j] = atual;
            }
        }
    }

    
    public static void Main()
    {
        int[] arr = { 64, 34, 25, 12, 22, 11, 90 };

        Console.WriteLine("\n\n================================");
        Console.WriteLine("     Exemplo de Shell Sort");
        Console.WriteLine("\n\nVetor original");
        Console.WriteLine(string.Join(", ", arr));
        Sort(arr);
        Console.WriteLine("\n\nVetor ordenado com Shell Sort");
        Console.WriteLine(string.Join(", ", arr));
        Console.WriteLine("================================");
        Console.WriteLine("\n\n===================================================");
        Console.WriteLine("     Escolha 5 números para ordenar!");
        int[] userArr = new int[5];
        for (int i = 0; i < userArr.Length; i++)
        {
            Console.Write($"Digite o {i + 1}º número: ");
            while (!int.TryParse(Console.ReadLine(), out userArr[i]))
            {
                Console.Write("Valor inválido! Digite um número inteiro: ");
            }
        }
        Console.WriteLine("\n\nSeu vetor:");
        Console.WriteLine(string.Join(", ", userArr));
        Sort(userArr);
        Console.WriteLine("\n\nVetor ordenado:");
        Console.WriteLine(string.Join(", ", userArr));
        Console.WriteLine("\n\n===================================================");


    }
}
