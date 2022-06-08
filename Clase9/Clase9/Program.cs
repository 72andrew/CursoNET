Console.WriteLine("Hola! Ingrese el largo del vector");
var dato = Console.ReadLine();
int[] vector = new int[int.Parse(dato)];
Random random = new Random();

for (int i = 0; i < vector.Length; i++)
{
    vector[i] = random.Next(100);
}

foreach (int i in vector)
{
    Console.Write($"{i} ");
}

int aux;
for (int i = 0; i < (vector.Length/2); i++)
{
    aux = vector[i];
    vector[i] = vector[vector.Length-1-i];
    vector[vector.Length-1-i] = aux;
}

Console.WriteLine("\n\nVector invertido:");
foreach (int i in vector)
{
    Console.Write($"{i} ");
}
Console.ReadKey();