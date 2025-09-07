Console.WriteLine("Hello, World!"); // pula linha, tipo \n
// Console.Write("Hello, World!"); // não pula linha

string nome = "Maiih";
int idade = 19;

Console.WriteLine($"String (nome): {nome}, Int (idade): {idade} anos."); // interpolação

float altura = 1.54f; // precisa do f no final. 4 bytes
double peso = 46.2; // 8 bytes
decimal preco = 99999.999m; // 16 bytes, precisa do m no final

Console.WriteLine($"Float (altura): {altura}, Double (peso): {peso}, Decimal (preço): {preco}");

bool estudante = true; // ou false
char letra = 'M'; // aspas simples, 1 caractere

var imp = "Maiih Linda"; // Variável dinâmica, o tipo é definido na atribuição

// Funções

string cor = "roxo";

switch (cor)
{
    case "roxo":
        Console.WriteLine("Cor favorita é roxo");
        break;
    case "azul":
        Console.WriteLine("Cor favorita é azul");
        break;
    default:
        Console.WriteLine("Cor favorita é outra");
        break;
}

string[] frutas = { "maçã", "banana", "laranja" }; // declaraçã de vetor

foreach (string fruta in frutas)
{
    Console.WriteLine(fruta);
}