// public static class InsertionSort
// {
//     public static void Sort<T>(T[] array) where T : IComparable
//     {
//         for (int i = 1; i < array.Length; i++)
//         {
//             int j = i;
//             while (j > 0 && array[j].CompareTo(array[j - 1]) < 0)
//             {
//                 Swap(array, j, j - 1);
//                 j--;
//             }
//         }
//     }

// }
    
// Atividades sobre Insertion Sort

// Atividade 1 — Ordenação básica

// Implemente um programa que:

// Peça ao usuário para digitar 5 números inteiros.

// Armazene esses números em um array.

// Use o Insertion Sort para ordená-los em ordem crescente.

// Mostre o array antes e depois da ordenação.

// Dica de estrutura:

// Função que implementa o algoritmo Insertion Sort
static void InsertionSort(int[] array)
{
    // Começamos do segundo elemento (índice 1), 
    // pois o primeiro (índice 0) já é considerado "ordenado"
    for (int i = 1; i < array.Length; i++)
    {
        // Guardamos o valor atual que será inserido na parte ordenada do array
        int atual = array[i];

        // j começa no elemento anterior a i
        int j = i - 1;

        // Enquanto j for maior ou igual a 0 
        // e o valor na posição j for maior que o "atual",
        // deslocamos o elemento para a direita
        while (j >= 0 && array[j] > atual)
        {
            // Move o elemento uma posição para frente
            array[j + 1] = array[j];

            // Anda uma posição para trás no array
            j--;
        }

        // Quando o local correto é encontrado, insere o valor "atual"
        // (j + 1) é a posição onde o valor deve ser colocado
        array[j + 1] = atual;
    }
}


static void Main()
{
    // Solicita ao usuário que insira 5 números inteiros
    int[] numeros = new int[5];
    Console.WriteLine("Digite 5 números inteiros:");

    for (int i = 0; i < numeros.Length; i++)
    {
        Console.Write($"Número {i + 1}: ");
        numeros[i] = int.Parse(Console.ReadLine());
    }

    // Mostra o array antes da ordenação
    Console.WriteLine("Array antes da ordenação: " + string.Join(", ", numeros));

    // Ordena o array usando Insertion Sort
    InsertionSort(numeros);

    // Mostra o array depois da ordenação
    Console.WriteLine("Array depois da ordenação: " + string.Join(", ", numeros));
}


// Atividade 2 — Contar o número de trocas

// Adapte o algoritmo do Insertion Sort para:

// Contar quantas trocas foram realizadas durante a ordenação.

// Exibir esse total ao final da execução.

// Desafio extra: Mostre também o número de comparações feitas.





// Atividade 3 — Ordenar nomes

// Em vez de números, use um array de strings com nomes de pessoas (ex: "Maria", "João", "Ana").

// Ordene-os alfabeticamente com Insertion Sort.

// Mostre o resultado.

