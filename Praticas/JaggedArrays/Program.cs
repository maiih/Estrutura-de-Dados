using System;

public class JaggedArrays
{
    public static void Main()
    {
        int[][]? numbers =
        {
            new int[] { 9, 5, -9 },
            new int[] { 0, -3, 12, 51, -3 },
            new int[] {  },
            new int[] { 54 }
        };

        // acessando elemento
        int number = numbers[1][2]; // Pega o valor 12
        numbers[1][3] = 50; // Altera o valor 51 para 50

        Console.WriteLine("Elemento numbers[1][2]: " + number);
        Console.WriteLine("Novo valor de numbers[1][3]: " + numbers[1][3]);
    }
}