int[] numeros = new int[10];

for (int i = 0; i < numeros.Length; i++)
{
    Console.WriteLine($"Ingrese el numero de la posicion {i + 1}");
    numeros[i] = int.Parse(Console.ReadLine());
    Console.Clear();
}

int acumulador = 0;
int mayor = 0;
int menor = 99999;

for (int i = 0; i < numeros.Length; i++)
{
    acumulador = acumulador + numeros[i];

    if (numeros[i] > mayor)
    {
        mayor = numeros[i];
    }

    if (numeros[i] < menor)
    {
        menor = numeros[i];
    }
}

Console.WriteLine("La cadena es:");

foreach (int i in numeros)
{
    Console.Write($"{i} ");
}


Console.WriteLine($"\n\nLa suma total es {acumulador}");

Console.WriteLine($"El numero mayor es  {mayor}");

Console.WriteLine($"El numero menor es {menor}");

Console.WriteLine($"El promedio es {(double)acumulador/(double)numeros.Length}");