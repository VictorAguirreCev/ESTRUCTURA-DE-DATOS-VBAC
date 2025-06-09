using System;

class Program
{
    static void Main(string[] args)
    {
        // Crear un objeto Circulo con radio 5
        Circulo miCirculo = new Circulo(5);
        Console.WriteLine("=== Círculo ===");
        Console.WriteLine("Área del círculo: " + miCirculo.CalcularArea());
        Console.WriteLine("Perímetro del círculo: " + miCirculo.CalcularPerimetro());

        // Crear un objeto Rectángulo con largo 10 y ancho 4
        Rectangulo miRectangulo = new Rectangulo(10, 4);
        Console.WriteLine("\n=== Rectángulo ===");
        Console.WriteLine("Área del rectángulo: " + miRectangulo.CalcularArea());
        Console.WriteLine("Perímetro del rectángulo: " + miRectangulo.CalcularPerimetro());
    }
}
