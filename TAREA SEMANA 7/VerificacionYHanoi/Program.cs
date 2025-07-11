using System;
using System.Collections.Generic;

class Program
{
    /// <summary>
    /// Método principal del programa. Ejecuta:
    /// 1. Verificación de expresión matemática balanceada.
    /// 2. Resolución del problema de Torres de Hanoi usando pilas.
    /// </summary>
    static void Main()
    {
        Console.WriteLine("=== VERIFICADOR DE EXPRESIONES BALANCEADAS ===");
        Console.Write("Ingrese una expresión matemática: ");
        string? expresion = Console.ReadLine();

        // Validación de entrada nula o vacía
        if (string.IsNullOrWhiteSpace(expresion))
        {
            Console.WriteLine("❌ No se ingresó ninguna expresión.");
            return;
        }

        // Verificación de balance de paréntesis, llaves y corchetes
        if (EsBalanceada(expresion))
            Console.WriteLine("✅ Fórmula balanceada.");
        else
            Console.WriteLine("❌ Fórmula no balanceada.");

        Console.WriteLine("\n=== TORRES DE HANOI CON PILAS ===");
        Console.Write("Ingrese el número de discos: ");
        string? entrada = Console.ReadLine();

        // Validación de número de discos válido
        if (!int.TryParse(entrada, out int n) || n <= 0)
        {
            Console.WriteLine("❌ Debes ingresar un número entero mayor que 0.");
            return;
        }

        // Resolución del problema de las Torres de Hanoi
        TorreDeHanoiConPilas(n);
    }

    /// <summary>
    /// Verifica si una expresión tiene paréntesis, llaves y corchetes correctamente balanceados.
    /// Utiliza una pila para emparejar los símbolos de apertura y cierre.
    /// </summary>
    /// <param name="expresion">Cadena de texto a evaluar</param>
    /// <returns>True si está balanceada, False si no lo está</returns>
    static bool EsBalanceada(string expresion)
    {
        Stack<char> pila = new Stack<char>();

        foreach (char c in expresion)
        {
            if (c == '(' || c == '[' || c == '{')
            {
                pila.Push(c); // Agrega símbolo de apertura
            }
            else if (c == ')' || c == ']' || c == '}')
            {
                if (pila.Count == 0) return false;

                char tope = pila.Pop(); // Verifica el emparejamiento
                if ((c == ')' && tope != '(') ||
                    (c == ']' && tope != '[') ||
                    (c == '}' && tope != '{'))
                {
                    return false;
                }
            }
        }

        return pila.Count == 0; // Debe quedar vacía si está balanceada
    }

    /// <summary>
    /// Inicializa las torres con discos y llama a la función recursiva para resolver el problema.
    /// </summary>
    /// <param name="discos">Número total de discos</param>
    static void TorreDeHanoiConPilas(int discos)
    {
        Stack<int> origen = new Stack<int>();
        Stack<int> destino = new Stack<int>();
        Stack<int> auxiliar = new Stack<int>();

        // Carga inicial de la torre de origen (de mayor a menor disco)
        for (int i = discos; i >= 1; i--)
        {
            origen.Push(i);
        }

        // Llamada recursiva para resolver la torre
        Hanoi(discos, origen, destino, auxiliar, "Origen", "Destino", "Auxiliar");
    }

    /// <summary>
    /// Algoritmo recursivo para resolver el problema de las Torres de Hanoi usando pilas.
    /// Muestra paso a paso los movimientos realizados.
    /// </summary>
    /// <param name="n">Número de discos a mover</param>
    /// <param name="origen">Torre origen</param>
    /// <param name="destino">Torre destino</param>
    /// <param name="auxiliar">Torre auxiliar</param>
    /// <param name="nombreOrigen">Nombre lógico de la torre origen</param>
    /// <param name="nombreDestino">Nombre lógico de la torre destino</param>
    /// <param name="nombreAuxiliar">Nombre lógico de la torre auxiliar</param>
    static void Hanoi(int n, Stack<int> origen, Stack<int> destino, Stack<int> auxiliar, string nombreOrigen, string nombreDestino, string nombreAuxiliar)
    {
        if (n == 1)
        {
            int disco = origen.Pop();
            destino.Push(disco);
            Console.WriteLine($"Mover disco {disco} de {nombreOrigen} a {nombreDestino}");
        }
        else
        {
            // Mueve n-1 discos a la torre auxiliar
            Hanoi(n - 1, origen, auxiliar, destino, nombreOrigen, nombreAuxiliar, nombreDestino);

            // Mueve el disco más grande al destino
            int disco = origen.Pop();
            destino.Push(disco);
            Console.WriteLine($"Mover disco {disco} de {nombreOrigen} a {nombreDestino}");

            // Mueve los discos desde la torre auxiliar al destino
            Hanoi(n - 1, auxiliar, destino, origen, nombreAuxiliar, nombreDestino, nombreOrigen);
        }
    }
}
