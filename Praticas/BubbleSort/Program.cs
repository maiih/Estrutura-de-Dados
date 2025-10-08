public class AlgoritmosDeOrdenacao
{
    // Função Bubble Sort (pode ser crescente ou decrescente dependendo da condição do if)
    public static void BubbleSort(int[] array, bool crescente = true)
    {
        int n = array.Length;
        int comparacoes = 0;
        int trocas = 0;

        for (int i = 0; i < n - 1; i++)
        {
            bool trocaRealizada = false; // Flag para otimização

            for (int j = 0; j < n - i - 1; j++)
            {
                comparacoes++;

                // Crescente: array[j] > array[j+1]
                // Decrescente: array[j] < array[j+1]
                if ((crescente && array[j] > array[j + 1]) ||
                    (!crescente && array[j] < array[j + 1]))
                {
                    // Realiza troca
                    int temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;

                    trocas++;
                    trocaRealizada = true;
                }
            }

            // Se não houve troca, o array já está ordenado → encerra
            if (!trocaRealizada)
                break;
        }

        // Exibe estatísticas
        Console.WriteLine($"\nTotal de Comparações: {comparacoes}");
        Console.WriteLine($"Total de Trocas: {trocas}");
    }

    // Função auxiliar para exibir o array
    public static void ImprimirArray(int[] array)
    {
        Console.WriteLine(string.Join(", ", array));
    }

    public static void Main(string[] args)
    {
        // --- Teste 1: Ordem Crescente ---
        int[] lista1 = { 5, 1, 4, 2, 8 };
        Console.WriteLine("Lista Original 1: ");
        ImprimirArray(lista1);

        BubbleSort(lista1, true); // true = crescente

        Console.WriteLine("\nLista Ordenada 1 (Crescente): ");
        ImprimirArray(lista1);

        Console.WriteLine("------------------------------");

        // --- Teste 2: Ordem Decrescente ---
        int[] lista2 = { 77, 4, 1, 15, 4, 9, 23 };
        Console.WriteLine("Lista Original 2: ");
        ImprimirArray(lista2);

        BubbleSort(lista2, false); // false = decrescente

        Console.WriteLine("\nLista Ordenada 2 (Decrescente): ");
        ImprimirArray(lista2);
    }
}