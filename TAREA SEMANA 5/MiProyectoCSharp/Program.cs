using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Ejecutar Ejercicio 1
        Ejercicio1();

        // Ejecutar Ejercicio 2
        Ejercicio2();

        // Ejecutar Ejercicio 3
        Ejercicio3();

        // Ejecutar Ejercicio 4
        Ejercicio4();

        // Ejecutar Ejercicio 5
        Ejercicio5();

        // Ejecutar Ejercicio 6
        Ejercicio6();
    }

    // Ejercicio 1: Mostrar asignaturas de un curso en una lista
    static void Ejercicio1()
    {
        List<string> asignaturas = new List<string> { "Matemáticas", "Física", "Química", "Historia", "Lengua" };
        foreach (var asignatura in asignaturas)
        {
            Console.WriteLine(asignatura);
        }
    }

    // Ejercicio 2: Mostrar mensaje con asignaturas
    static void Ejercicio2()
    {
        List<string> asignaturas = new List<string> { "Matemáticas", "Física", "Química", "Historia", "Lengua" };
        foreach (var asignatura in asignaturas)
        {
            Console.WriteLine($"Yo estudio {asignatura}");
        }
    }

    // Ejercicio 3: Mostrar asignaturas con notas
    static void Ejercicio3()
    {
        List<string> asignaturas = new List<string> { "Matemáticas", "Física", "Química", "Historia", "Lengua" };
        Dictionary<string, double> notas = new Dictionary<string, double>();

        foreach (var asignatura in asignaturas)
        {
            Console.Write($"¿Qué nota has sacado en {asignatura}? ");
            double nota = Convert.ToDouble(Console.ReadLine());
            notas[asignatura] = nota;
        }

        foreach (var asignatura in asignaturas)
        {
            Console.WriteLine($"En {asignatura} has sacado {notas[asignatura]}");
        }
    }

    // Ejercicio 4: Ordenar números ganadores de la lotería
    static void Ejercicio4()
    {
        List<int> numeros = new List<int>();

        Console.WriteLine("Introduce los números ganadores de la lotería (separados por espacio): ");
        string[] input = Console.ReadLine().Split();

        foreach (var num in input)
        {
            numeros.Add(Convert.ToInt32(num));
        }

        numeros.Sort();
        Console.WriteLine("Números ordenados: ");
        foreach (var num in numeros)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();
    }

    // Ejercicio 5: Mostrar números del 1 al 10 en orden inverso
    static void Ejercicio5()
    {
        List<int> numeros = new List<int>();

        for (int i = 1; i <= 10; i++)
        {
            numeros.Add(i);
        }

        numeros.Reverse();

        Console.WriteLine(string.Join(", ", numeros));
        Console.WriteLine();
    }

    // Ejercicio 6: Eliminar asignaturas aprobadas de la lista
    static void Ejercicio6()
    {
        List<string> asignaturas = new List<string> { "Matemáticas", "Física", "Química", "Historia", "Lengua" };
        List<string> asignaturasRepetir = new List<string>();

        foreach (var asignatura in asignaturas)
        {
            Console.Write($"¿Has aprobado {asignatura}? (sí/no): ");
            string respuesta = Console.ReadLine().ToLower();

            if (respuesta == "no")
            {
                asignaturasRepetir.Add(asignatura);
            }
        }

        Console.WriteLine("Asignaturas que tienes que repetir:");
        foreach (var asignatura in asignaturasRepetir)
        {
            Console.WriteLine(asignatura);
        }
        Console.WriteLine();
    }
}
