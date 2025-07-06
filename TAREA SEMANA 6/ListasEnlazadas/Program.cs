using System;

public class Nodo
{
    public int valor;      // Valor del nodo
    public Nodo siguiente; // Referencia al siguiente nodo

    // Constructor para inicializar el valor del nodo
    public Nodo(int valor)
    {
        this.valor = valor;
        this.siguiente = null;
    }
}

public class ListaEnlazada
{
    private Nodo cabeza; // Apunta al primer nodo de la lista

    // Constructor de la lista enlazada, inicializa la cabeza como null
    public ListaEnlazada()
    {
        cabeza = null;
    }

    // Método para insertar un nodo al final de la lista
    public void Insertar(int valor)
    {
        Nodo nuevoNodo = new Nodo(valor); // Crear un nuevo nodo con el valor proporcionado
        if (cabeza == null)
        {
            cabeza = nuevoNodo; // Si la lista está vacía, el nuevo nodo es la cabeza
        }
        else
        {
            Nodo actual = cabeza;
            // Recorre la lista hasta el final
            while (actual.siguiente != null)
            {
                actual = actual.siguiente;
            }
            // Inserta el nuevo nodo al final de la lista
            actual.siguiente = nuevoNodo;
        }
    }

    // Método para mostrar todos los elementos de la lista
    public void Mostrar()
    {
        Nodo actual = cabeza;
        // Recorre la lista e imprime los valores de cada nodo
        while (actual != null)
        {
            Console.Write(actual.valor + " ");
            actual = actual.siguiente;
        }
        Console.WriteLine(); // Imprime una nueva línea al final
    }

    // Función 1: Calcular el número de elementos de la lista
    public int ContarElementos()
    {
        int contador = 0;
        Nodo actual = cabeza;
        // Recorre la lista contando los nodos
        while (actual != null)
        {
            contador++;
            actual = actual.siguiente;
        }
        return contador;
    }

    // Función 2: Invertir la lista
    public void Invertir()
    {
        Nodo anterior = null;
        Nodo actual = cabeza;
        Nodo siguiente = null;

        // Recorre la lista y cambia las referencias de los nodos
        while (actual != null)
        {
            siguiente = actual.siguiente;  // Guarda el siguiente nodo
            actual.siguiente = anterior;   // Invierte la referencia
            anterior = actual;             // Mueve el puntero anterior al nodo actual
            actual = siguiente;            // Avanza al siguiente nodo
        }
        cabeza = anterior;  // La nueva cabeza de la lista es el último nodo procesado
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Crear una instancia de la lista enlazada
        ListaEnlazada lista = new ListaEnlazada();

        // Insertar algunos elementos en la lista
        lista.Insertar(10);
        lista.Insertar(20);
        lista.Insertar(30);
        lista.Insertar(40);
        lista.Insertar(50);

        // Mostrar la lista original
        Console.WriteLine("Lista original:");
        lista.Mostrar();

        // Contar el número de elementos de la lista
        Console.WriteLine("Número de elementos en la lista: " + lista.ContarElementos());

        // Invertir la lista
        lista.Invertir();
        Console.WriteLine("Lista invertida:");
        lista.Mostrar();
    }
}
