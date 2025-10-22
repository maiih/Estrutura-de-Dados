Resumo:QuickSort

Quicksort é um algoritmo de ordenação, que tem grande eficiência por ser baseada em uma técnica de Dividir e conquistar (divide and conquer). Ele organiza de uma forma recursiva, separando em partes menores.
Funcionamento:  um elemento do vetor é escolhido como pivô, tendo tendência ser o primeiro, último ou do meio. Quando os elementos menores são movidos para esquerda e maiores para direita, é chamado Particionamento. Já a Recursão é repetido recursivamente nas duas direções como esquerda ou direita, até que esteja total ordenado.
Exemplo
1-	Vetor: [8, 3, 1, 7, 0, 10, 2]
1.	Pivô = 7
→ Menores: [3, 1, 0, 2]
→ Maiores: [8, 10]
2.	Ordena recursivamente as duas partes.
Resultado: [0, 1, 2, 3, 7, 8, 10]

2-	função quicksort (vetor, início, fim):
    se início < fim:
        pivô = particiona (vetor, início, fim)
        quicksort (vetor, início, pivô - 1)
        quicksort (vetor, pivô + 1, fim)

Vantagens: rápido na prática, usa memória de forma eficiente e fácil de implementar de forma recursiva.
Desvantagens: tem que escolher bem o posicionamento do pivô para ter mal desempenho e não é estável (ordem dos elementos iguais podem mudar).
Utilização: Ordenar listas, vetores, tabelas, bancos de dados, sistemas de buscas, sistemas operacionais, compiladores, análise de dados, estatísticas, jogos e simulações.