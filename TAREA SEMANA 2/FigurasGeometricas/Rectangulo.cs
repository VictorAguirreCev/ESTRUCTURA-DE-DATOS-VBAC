using System;

// Clase Rectangulo que encapsula el largo y ancho y permite calcular área y perímetro
public class Rectangulo
{
    private double largo;
    private double ancho;

    // Constructor que recibe el largo y el ancho del rectángulo
    public Rectangulo(double largo, double ancho)
    {
        this.largo = largo;
        this.ancho = ancho;
    }

    // Calcula y devuelve el área del rectángulo
    public double CalcularArea()
    {
        return largo * ancho;
    }

    // Calcula y devuelve el perímetro del rectángulo
    public double CalcularPerimetro()
    {
        return 2 * (largo + ancho);
    }
}
