int[,] numeros;
double[] promedios;
double acumProm;

Console.WriteLine("Ingrese las filas");
int filas = int.Parse(Console.ReadLine());

Console.WriteLine("Ingrese las columnas");
int columnas = int.Parse(Console.ReadLine());

numeros = new int[filas, columnas];
promedios = new double[columnas];

//Console.WriteLine(numeros.GetUpperBound(0));
//Console.WriteLine(numeros.GetUpperBound(1));

for (int i = 0; i < numeros.GetUpperBound(0)+1; i++)
{
    for (int j = 0; j < numeros.GetUpperBound(1)+1; j++)
    {
        Console.WriteLine($"Ingrese la fila {i+1}, columna {j+1}");
        numeros[i, j] = int.Parse(Console.ReadLine());  
    }
}

for (int i = 0; i < numeros.GetUpperBound(1) + 1; i++)
{
    acumProm = 0;
    for (int j = 0; j < numeros.GetUpperBound(0) + 1; j++)
    {
        acumProm = acumProm + (double)numeros[j, i];

    }
    promedios[i] = acumProm/(numeros.GetUpperBound(0)+1);
}

Console.WriteLine("");
Console.WriteLine("");

for (int i = 0; i < numeros.GetUpperBound(0)+1; i++)
{
    Console.Write(" |");
    for (int j = 0; j < numeros.GetUpperBound(1) + 1; j++)
    {
        Console.Write(String.Format("{0,5} |", numeros[i,j]));
    }
    Console.WriteLine("");
}

Console.WriteLine("");
Console.Write(" |");
foreach (double item in promedios)
{
    Console.Write(String.Format("{0,5} |", Math.Round(item, 2)));

}

Console.WriteLine("");
Console.ReadKey();

