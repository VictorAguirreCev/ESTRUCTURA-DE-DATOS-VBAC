using System;
using System.Collections.Generic;

namespace Biblioteca
{
    public class Libro
    {
        public int Codigo { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int Anio { get; set; }

        public Libro(int codigo, string titulo, string autor, int anio)
        {
            Codigo = codigo;
            Titulo = titulo;
            Autor = autor;
            Anio = anio;
        }

        public override string ToString()
        {
            return $"Código: {Codigo}, Título: {Titulo}, Autor: {Autor}, Año: {Anio}";
        }
    }

    class Program
    {
        static HashSet<int> codigos = new HashSet<int>();
        static Dictionary<int, Libro> biblioteca = new Dictionary<int, Libro>();

        static void Main(string[] args)
        {
            bool salir = false;
            while (!salir)
            {
                Console.WriteLine("\n--- MENÚ DE BIBLIOTECA ---");
                Console.WriteLine("1. Registrar libro");
                Console.WriteLine("2. Consultar libro por código");
                Console.WriteLine("3. Listar todos los libros");
                Console.WriteLine("4. Salir");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        RegistrarLibro();
                        break;
                    case "2":
                        ConsultarLibro();
                        break;
                    case "3":
                        ListarLibros();
                        break;
                    case "4":
                        salir = true;
                        Console.WriteLine("Saliendo del sistema...");
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Intente de nuevo.");
                        break;
                }
            }
        }

        static void RegistrarLibro()
        {
            Console.Write("Ingrese código del libro: ");
            int codigo = int.Parse(Console.ReadLine());

            if (codigos.Contains(codigo))
            {
                Console.WriteLine("⚠️ El código ya existe. No se puede registrar duplicado.");
                return;
            }

            Console.Write("Ingrese título: ");
            string titulo = Console.ReadLine();
            Console.Write("Ingrese autor: ");
            string autor = Console.ReadLine();
            Console.Write("Ingrese año de publicación: ");
            int anio = int.Parse(Console.ReadLine());

            Libro nuevoLibro = new Libro(codigo, titulo, autor, anio);
            codigos.Add(codigo);
            biblioteca.Add(codigo, nuevoLibro);
            Console.WriteLine("✅ Libro registrado correctamente.");
        }

        static void ConsultarLibro()
        {
            Console.Write("Ingrese código a consultar: ");
            int codigo = int.Parse(Console.ReadLine());

            if (biblioteca.ContainsKey(codigo))
            {
                Console.WriteLine("📖 " + biblioteca[codigo]);
            }
            else
            {
                Console.WriteLine("❌ No se encontró un libro con ese código.");
            }
        }

        static void ListarLibros()
        {
            Console.WriteLine("\n--- LISTADO DE LIBROS ---");
            foreach (var libro in biblioteca.Values)
            {
                Console.WriteLine(libro);
            }
        }
    }
}
