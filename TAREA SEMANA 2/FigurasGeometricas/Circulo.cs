using System;

// Clase Circulo que encapsula el radio y permite calcular área y perímetro
public class Circulo
{
    private double radio;

    // Constructor que recibe el radio del círculo
    public Circulo(double radio)
    {
        this.radio = radio;
    }

    // Calcula y devuelve el área del círculo
    public double CalcularArea()
    {
        return Math.PI * radio * radio;
    }

    // Calcula y devuelve el perímetro (circunferencia) del círculo
    public double CalcularPerimetro()
    {
        return 2 * Math.PI * radio;
    }
}
