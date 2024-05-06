﻿
using Reflection;

string path = AppDomain.CurrentDomain.BaseDirectory + "Assemblies";

Console.WriteLine();
Console.WriteLine();
Console.WriteLine();
var numbers = new List<int>()
            {
                5,9,3,1
            };

var loadAssembly = new LoadAssembly<ISort>(path);

WithMessages();

void NoMessages()
{
    bool getImplementations = true;

    while (getImplementations)
    {
        PrintMessageYellow("Las implementaciones disponibles son: ", true);
        var implementations = loadAssembly.GetImplementations();

        for (int i = 0; i < implementations.Count(); i++)
        {
            var implementation = implementations.ElementAt(i);
            Console.WriteLine($"{i + 1}->{implementation}");
        }

        Console.Write("Seleccione una: ");
        int.TryParse(Console.ReadLine(), out int indexImplementation);


        ISort implementationSelected = loadAssembly.GetImplementation(indexImplementation - 1);
        implementationSelected.Sort(ref numbers);

        Console.WriteLine(String.Join(",", numbers.ToArray()));
        Console.WriteLine();

        Console.ReadLine();
    }

    PrintMessageYellow("Hasta la proxima forastero");

    Console.ReadLine();
}

void WithMessages()
{
    bool getImplementations = true;

    PrintMessageYellow("Bienvenido forastero: que desea realizar?", true);

    while (getImplementations)
    {
        Console.Write("1- Ver implementaciones \n2- Salir\nSeleccione una: ");
        int.TryParse(Console.ReadLine(), out int option);
        PrintMessageYellow("Has seleccionado la opcion: ");

        PrintMessageYellow(String.Format("{0}- {1}", option, option == 1 ? "Ver implementaciones" : "Salir"), true);
        System.Console.WriteLine();

        switch (option)
        {
            case 1:
                PrintMessageYellow("Las implementaciones disponibles son: ", true);
                var implementations = loadAssembly.GetImplementations();

                for (int i = 0; i < implementations.Count(); i++)
                {
                    var implementation = implementations.ElementAt(i);
                    Console.WriteLine($"{i + 1}->{implementation}");
                }

                Console.Write("Seleccione una: ");
                int.TryParse(Console.ReadLine(), out int indexImplementation);


                PrintMessageYellow(String.Format("Has seleccionado la implementacion {0}->{1}", indexImplementation, implementations.ElementAt(indexImplementation - 1)), true);
                Console.WriteLine();

                ISort implementationSelected = loadAssembly.GetImplementation(indexImplementation - 1);
                implementationSelected.Sort(ref numbers);

                PrintMessageGreen("Felicitacions, ganaste la batalla contra el señor oscuro, tu recompenza es: ", true);
                Console.WriteLine(String.Join(",", numbers.ToArray()));
                Console.WriteLine();


                PrintMessageYellow("Que desea hacer:", true);
                Console.Write("1- Reiniciar\n2- Salir\nSeleccione una:");

                int.TryParse(Console.ReadLine(), out int restartOption);
                Console.WriteLine();
                getImplementations = restartOption == 1;
                break;
            case 2:
                getImplementations = false;
                break;
            default:
                getImplementations = false;
                break;
        }
    }

    PrintMessageYellow("Hasta la proxima forastero");

    Console.ReadLine();
}

void PrintMessageYellow(string message, bool space = false)
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write(message);
    if (space)
    {
        Console.WriteLine();
    }
    Console.ResetColor();
}

void PrintMessageGreen(string message, bool space = false)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write(message);
    if (space)
    {
        Console.WriteLine();
    }
    Console.ResetColor();
}