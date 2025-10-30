using System.Diagnostics;

// Atividades sobre QuickSort

// Atividade 1 — Ordenação simples

// Crie uma função QuickSort que:

// Receba um array de inteiros.

// Ordene o array em ordem crescente.

// Mostre o array antes e depois.

// Exemplo de estrutura:

// Função principal do algoritmo QuickSort
// Ela divide o array em partes menores e as ordena recursivamente
static void QuickSort(int[] array, int inicio, int fim)
{
    // A condição evita chamadas desnecessárias quando o subarray tem 0 ou 1 elemento
    if (inicio < fim)
    {
        // Chama a função Particionar, que organiza os elementos
        // em torno de um pivô e devolve a posição final desse pivô
        int p = Particionar(array, inicio, fim);

        // Chama recursivamente o QuickSort para o subarray à esquerda do pivô
        QuickSort(array, inicio, p - 1);

        // Chama recursivamente o QuickSort para o subarray à direita do pivô
        QuickSort(array, p + 1, fim);
    }
}
// Função que faz a "partição" do array
// Coloca o pivô na posição correta e garante que:
// - à esquerda do pivô, ficam elementos menores ou iguais
// - à direita, ficam elementos maiores
static int Particionar(int[] array, int inicio, int fim)
{
    // Define o pivô como o último elemento do subarray
    int pivo = array[fim];

    // i é o índice do menor elemento encontrado até agora
    // começa uma posição antes do início
    int i = inicio - 1;

    // Percorre o subarray do índice 'inicio' até o elemento anterior ao pivô
    for (int j = inicio; j < fim; j++)
    {
        // Se o elemento atual é menor ou igual ao pivô
        if (array[j] <= pivo)
        {
            // Move o índice 'i' uma posição à frente
            i++;

            // Troca os elementos nas posições i e j
            // Isso garante que os elementos menores fiquem à esquerda
            (array[i], array[j]) = (array[j], array[i]);
        }
    }

    // Coloca o pivô na posição correta (logo após o último elemento menor)
    (array[i + 1], array[fim]) = (array[fim], array[i + 1]);

    // Retorna o índice final do pivô, que divide o array em duas partes
    return i + 1;
}




// Atividade 2 — Contar chamadas recursivas

// Modifique o QuickSort para contar quantas vezes a função QuickSort foi chamada recursivamente.

// Isso ajuda a entender a complexidade recursiva do algoritmo.




// Atividade 3 — Comparar desempenho

// Crie dois arrays idênticos com 10 números aleatórios.
// Ordene um com Insertion Sort e o outro com QuickSort e:

// Mostre o tempo gasto por cada algoritmo (use Stopwatch).

// Dica:


Stopwatch sw = Stopwatch.StartNew();
// executa o algoritmo
sw.Stop();
Console.WriteLine($"Tempo: {sw.ElapsedMilliseconds} ms");