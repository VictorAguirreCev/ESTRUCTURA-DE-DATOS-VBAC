using System;
using System.Collections.Generic;

class Traductor
{
    // Diccionario base con algunas palabras iniciales
    static Dictionary<string, string> diccionario = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
    {
        { "Time", "tiempo" },
        { "Person", "persona" },
        { "Year", "año" },
        { "Way", "camino" },
        { "Day", "día" },
        { "Thing", "cosa" },
        { "Man", "hombre" },
        { "World", "mundo" },
        { "Life", "vida" },
        { "Hand", "mano" },
        { "Part", "parte" },
        { "Child", "niño" },
        { "Eye", "ojo" },
        { "Woman", "mujer" },
        { "Place", "lugar" },
        { "Work", "trabajo" },
        { "Week", "semana" },
        { "Case", "caso" },
        { "Point", "punto" },
        { "Government", "gobierno" },
        { "Company", "empresa" }
    };

    static void Main(string[] args)
    {
        bool continuar = true;

        while (continuar)
        {
            MostrarMenu();
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    TraducirFrase();
                    break;

                case "2":
                    AgregarPalabra();
                    break;

                case "0":
                    continuar = false;
                    break;

                default:
                    Console.WriteLine("Opción no válida, intente nuevamente.");
                    break;
            }
        }
    }

    static void MostrarMenu()
    {
        Console.Clear();
        Console.WriteLine("==================== MENÚ ====================");
        Console.WriteLine("1. Traducir una frase");
        Console.WriteLine("2. Agregar palabras al diccionario");
        Console.WriteLine("0. Salir");
        Console.Write("Seleccione una opción: ");
    }

    static void TraducirFrase()
    {
        Console.WriteLine("\nIngrese la frase en inglés:");
        string frase = Console.ReadLine();
        string[] palabras = frase.Split(' ');
        List<string> traduccion = new List<string>();

        foreach (string palabra in palabras)
        {
            // Si la palabra está en el diccionario, la traducimos
            if (diccionario.ContainsKey(palabra))
            {
                traduccion.Add(diccionario[palabra]);
            }
            else
            {
                // Si no está en el diccionario, dejamos la palabra tal como está
                traduccion.Add(palabra);
            }
        }

        Console.WriteLine("\nTraducción:");
        Console.WriteLine(string.Join(" ", traduccion));
        Console.WriteLine("\nPresione cualquier tecla para volver al menú...");
        Console.ReadKey();
    }

    static void AgregarPalabra()
    {
        Console.WriteLine("\nIngrese la palabra en inglés:");
        string palabraIngles = Console.ReadLine();

        // Verificar si la palabra ya existe en el diccionario
        if (diccionario.ContainsKey(palabraIngles))
        {
            Console.WriteLine("La palabra ya está en el diccionario.");
        }
        else
        {
            Console.WriteLine("Ingrese la traducción en español:");
            string traduccion = Console.ReadLine();
            diccionario.Add(palabraIngles, traduccion);
            Console.WriteLine("Palabra agregada al diccionario.");
        }

        Console.WriteLine("\nPresione cualquier tecla para volver al menú...");
        Console.ReadKey();
    }
}
