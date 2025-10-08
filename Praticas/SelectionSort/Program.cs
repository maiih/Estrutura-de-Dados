/* Atividade Prática de Selection Sort em C#
Implementar o algoritmo Selection Sort em C#, concentrando-se na manipulação de arrays e na lógica dos loops aninhados.

O Desafio: Implementar e Analisar o Selection Sort
1. Objetivo
Criar um programa em C# que implemente a função de ordenação Selection Sort para ordenar um array de inteiros. Além da implementação, o aluno deve registrar o número de trocas realizadas.

2. Código Base (Ponto de Partida)
Deverá ser preenchida a lógica dentro do método SelectionSort:

C# */

using System;

public class SelectionSortAtividade
{
    public static void Main(string[] args)
    {
        int[] meuArray = { 64, 25, 12, 22, 11 };
        int trocas = 0;

        Console.WriteLine("Array Original: " + string.Join(", ", meuArray));

        // CHAME A FUNÇÃO AQUI e capture o número de trocas
        meuArray = SelectionSort(meuArray, out trocas); 

        Console.WriteLine("Array Ordenado: " + string.Join(", ", meuArray));
        Console.WriteLine($"Total de Trocas Realizadas: {trocas}");
    }

    /// <summary>
    /// Ordena um array de inteiros usando o algoritmo Selection Sort.
    /// </summary>
    /// <param name="arr">O array a ser ordenado.</param>
    /// <param name="trocas">Variável para retornar o número total de trocas.</param>
    /// <returns>O array ordenado.</returns>
    public static int[] SelectionSort(int[] arr, out int trocas)
    {
        int n = arr.Length;
        trocas = 0;

        // Loop Externo: Percorre o array para posicionar o próximo elemento
        for (int i = 0; i < n - 1; i++)
        {
            // 1. Encontre a posição do menor elemento no subarray (i até n-1)
            int min_idx = i;
            
            // Loop Interno: Procura o menor elemento no restante do array
            // PREENCHA A LÓGICA DESTE LOOP AQUI
            
            
            // 2. Realize a troca
            // Se o menor elemento NÃO for o elemento na posição i, faça a troca.
            // PREENCHA A LÓGICA DA TROCA AQUI E INCREMENTE 'trocas'
            
        }

        return arr;
    }
}

/* 3. Complete a lógica dentro do método SelectionSort:

A. Implementação do Loop Interno
O loop interno (iniciando em j=i+1) deve varrer o restante do array para encontrar o índice do menor elemento (min_idx).

Dica: A cada iteração, compare o elemento atual (arr[j]) com o elemento na posição do menor índice encontrado até agora (arr[min_idx]).

B. Implementação da Troca
Após o loop interno terminar, o índice min_idx deve conter a posição do menor elemento no subarray.

Verifique se min_idx é diferente de i. Se for, significa que uma troca é necessária.

Use uma variável temporária para trocar o elemento na posição i com o elemento na posição min_idx.

Importante: Incremente a variável trocas dentro deste bloco condicional (if).

C. Análise
Após rodar o programa com o array de teste { 64, 25, 12, 22, 11 }, responda:

Qual é o resultado final do Array Ordenado?

Qual é o Total de Trocas Realizadas?

Se o array inicial fosse { 1, 2, 3, 4, 5 } (já ordenado), quantas trocas o seu programa faria? Por quê? */
