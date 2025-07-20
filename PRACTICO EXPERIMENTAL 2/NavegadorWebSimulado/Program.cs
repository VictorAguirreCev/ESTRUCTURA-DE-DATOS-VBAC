using System;
using System.Collections.Generic;

namespace NavegadorWebSimulado
{
    public class NavegadorWeb
    {
        private Stack<string> historial;

        public NavegadorWeb()
        {
            historial = new Stack<string>();
        }

        public void VisitarPagina(string url)
        {
            historial.Push(url);
            Console.WriteLine($"\nHas visitado: {url}");
        }

        public void Retroceder()
        {
            if (historial.Count <= 1)
            {
                Console.WriteLine("\nNo hay más páginas a las que retroceder.");
                return;
            }

            string paginaActual = historial.Pop();
            Console.WriteLine($"\nVolviste desde: {paginaActual}");

            string paginaAnterior = historial.Peek();
            Console.WriteLine($"Ahora estás en: {paginaAnterior}");
        }

        public void MostrarHistorial()
        {
            if (historial.Count == 0)
            {
                Console.WriteLine("\nNo hay historial de navegación.");
                return;
            }

            Console.WriteLine("\n=== Historial de Navegación (último al primero) ===");
            foreach (var pagina in historial)
            {
                Console.WriteLine(pagina);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            NavegadorWeb navegador = new NavegadorWeb();
            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("\n--- MENÚ DEL NAVEGADOR ---");
                Console.WriteLine("1. Visitar nueva página");
                Console.WriteLine("2. Retroceder");
                Console.WriteLine("3. Mostrar historial");
                Console.WriteLine("4. Salir");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Write("\nIngrese la URL de la nueva página: ");
                        string url = Console.ReadLine();
                        navegador.VisitarPagina(url);
                        break;
                    case "2":
                        navegador.Retroceder();
                        break;
                    case "3":
                        navegador.MostrarHistorial();
                        break;
                    case "4":
                        salir = true;
                        Console.WriteLine("\nSaliendo del navegador...");
                        break;
                    default:
                        Console.WriteLine("\nOpción inválida. Intente nuevamente.");
                        break;
                }
            }
        }
    }
}
