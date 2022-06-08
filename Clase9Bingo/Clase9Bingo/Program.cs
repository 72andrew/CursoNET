int[,] cartonBingo = new int[3, 9];
bool[,] espacioOcupadoCarton = new bool[3, 9];

int[,] fila = new int[3, 5];
Random random = new Random();
int contador = 0;
int pos;
bool posDisponible;

Console.WriteLine("Tablero de BingO");
Console.WriteLine("");

//relleno las dos primeras filas
for (int i = 0; i < espacioOcupadoCarton.GetUpperBound(0); i++)
{

    //Acá relleno una matriz de 3x5 con las posiciones donde voy a poner los numeros

    contador = 0;
    while (contador < 5)
    {
        posDisponible = true;
        pos = random.Next(1, 10);


        for (int j = 0; j < fila.GetUpperBound(1) + 1; j++)
        {
            //compruebo que el valor Random no este repetido
            if (fila[i, j] == pos)
            {
                posDisponible = false;
            }

            //contemplo el caso donde las 2 primeras fila esten repetidas
            if (i == 1 && j == 4)
            {
                int contador2 = 0;
                for (int k = 0; k < fila.GetUpperBound(1) + 1; k++)
                {
                    if (fila[0, k] == fila[1, k])
                    {
                        contador2++;
                    }
                }
                if (contador2 == 5)
                {
                    posDisponible = false;
                }
            }


        }



        if (posDisponible)
        {
            fila[i, contador] = pos;
            contador++;
        }

    }



    //Aca completo paso las posiciones a una matriz booleana  

    for (int j = 0; j < fila.GetUpperBound(1) + 1; j++)
    {
        espacioOcupadoCarton[i, (fila[i, j] - 1)] = true;
    }

    /*for (int j = 0; j < espacioOcupadoCarton.GetUpperBound(1) + 1; j++)
    {
        for (int k = 0; k < fila.GetUpperBound(1) + 1; k++)
        {
            if (fila[i, k] - 1 == j)
            {
                espacioOcupadoCarton[i, j] = true;
            }
        }
    }*/

}

//Ahora tengo que llenar la fila 3; donde primero voy a llenar las las casillas con filas sin valores
contador = 0;
for (int i = 0; i < espacioOcupadoCarton.GetUpperBound(1) + 1; i++)
{
    if (!espacioOcupadoCarton[0, i] && !espacioOcupadoCarton[1, i])
    {
        espacioOcupadoCarton[2, i] = true;
        fila[2, contador] = i + 1;
        contador++;
    }
}


//relleno lo que falta de la fila 3

while (contador < 5)
{
    posDisponible = true;
    pos = random.Next(1, 10);


    for (int j = 0; j < fila.GetUpperBound(1) + 1; j++)
    {
        //compruebo que el valor Random no este repetido
        if (fila[2, j] == pos)
        {
            posDisponible = false;
        }

        //contemplo el caso donde las 2 primeras fila ya esten ocupadas

        if (espacioOcupadoCarton[0, pos - 1] && espacioOcupadoCarton[1, pos - 1])
        {
            posDisponible = false;
        }



    }


    if (posDisponible)
    {
        fila[2, contador] = pos;
        contador++;

    }

}


//Aca completo paso las posiciones booleanas de la tercer fila  


for (int i = 0; i < fila.GetUpperBound(1) + 1; i++)
{
    espacioOcupadoCarton[2, (fila[2, i] - 1)] = true;
}


int[] numerito = new int[2];
int auxi;
for (int i = 0; i < 9; i++)
{
    contador = 0;
    for (int j = 0; j < 3; j++)
    {
        if (espacioOcupadoCarton[j, i])
        {
            contador++;
        }
    }

    switch (contador)
    {
        case 1:
            for (int j = 0; j < 3; j++)
            {
                if (espacioOcupadoCarton[j, i])
                {
                    switch (i)
                    {
                        case 0:
                            cartonBingo[j, i] = random.Next(1 + (i * 10), 10 + (i * 10));
                            break;
                        case 8:
                            cartonBingo[j, i] = random.Next((i * 10), 10 + (i * 10) + 1);
                            break;
                        default:
                            cartonBingo[j, i] = random.Next((i * 10), 10 + (i * 10));
                            break;

                    }

                }
            }
            break;
        case 2:


                switch (i)
                {
                    case 0:
                        numerito[0] = random.Next(1 + (i * 10), 10 + (i * 10));
                        break;
                    case 8:
                        numerito[0] = random.Next((i * 10), 10 + (i * 10) + 1);
                        break;
                    default:
                        numerito[0] = random.Next((i * 10), 10 + (i * 10));
                        break;
                }

                do
                {
                    switch (i)
                    {
                        case 0:
                            numerito[1] = random.Next(1 + (i * 10), 10 + (i * 10));
                            break;
                        case 8:
                            numerito[1] = random.Next((i * 10), 10 + (i * 10) + 1);
                            break;
                        default:
                            numerito[1] = random.Next((i * 10), 10 + (i * 10));
                            break;
                    }
                } while (numerito[0] == numerito[1]);

           
            if (numerito[0] > numerito[1])
            {
                auxi = numerito[1];
                numerito[1] = numerito[0];
                numerito[0] = auxi;

            }
            contador = 0;
            for (int j = 0; j < 3; j++)
            {
                if (espacioOcupadoCarton[j, i])
                {
                    cartonBingo[j, i] = numerito[contador];
                    contador++;
                }
            }


            break;
    }



}

for (int i = 0; i < 3; i++)
{
    for (int j = 0; j < 9; j++)
    {
        if (espacioOcupadoCarton[i, j])
        {
            Console.Write(String.Format("{0,3} |", cartonBingo[i, j]));
        }
        else
        {
            Console.Write(String.Format("{0,3} |", "/"));
        }

    }
    Console.WriteLine("");
    Console.WriteLine("");
}
