using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace RevistaSearch
{
    internal static class Program
    {
        // 📚 Catálogo de revistas traducidas al español
        private static readonly List<string> CatalogoOriginal = new()
        {
            "Computadoras y Educación",
            "Revista de Investigación en Computación Educativa",
            "Transacciones IEEE sobre Tecnologías del Aprendizaje",
            "Revista Británica de Tecnología Educativa",
            "Educación y Tecnologías de la Información",
            "Transacciones ACM sobre Educación en Computación",
            "Revista Internacional de Tecnología Educativa en Educación Superior",
            "Revista Australiana de Tecnología Educativa",
            "Revista de Aprendizaje Asistido por Computadora",
            "Informática en la Educación",
            "Entornos de Aprendizaje Interactivos",
            "Revista de Educación en Tecnología de la Información"
        };

        // 📌 Lista que va a almacenar el catálogo ordenado (clave normalizada, título original)
        private static List<(string key, string original)> _catalogoOrdenado = new();

        private static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8; // Permite mostrar tildes y caracteres especiales
            PrepararCatalogo(); // Ordena y prepara la lista para las búsquedas

            while (true) // 🔄 Bucle infinito hasta que el usuario decida salir
            {
                MostrarMenu(); // Muestra el menú en pantalla
                Console.Write("Elige una opción: ");
                var opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        BuscarTituloInteractivo(); // Permite buscar un título
                        break;
                    case "2":
                        MostrarCatalogo(); // Muestra todas las revistas
                        break;
                    case "0":
                        Console.WriteLine("Saliendo... ¡Hasta luego!");
                        return; // 🚪 Sale del programa
                    default:
                        Console.WriteLine("Opción no válida. Intenta de nuevo.");
                        break;
                }

                Console.WriteLine();
            }
        }

        // 🔧 Normaliza un texto: pasa a minúsculas y quita acentos para comparar de forma justa
        private static string Normalizar(string input)
        {
            if (input is null) return string.Empty;

            var lower = input.ToLowerInvariant().Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder(lower.Length);

            foreach (var ch in lower)
            {
                var uc = CharUnicodeInfo.GetUnicodeCategory(ch);
                if (uc != UnicodeCategory.NonSpacingMark) // Quita tildes
                {
                    sb.Append(ch);
                }
            }

            return sb.ToString().Normalize(NormalizationForm.FormC).Trim();
        }

        // 🗂️ Prepara el catálogo ordenado para que la búsqueda binaria funcione correctamente
        private static void PrepararCatalogo()
        {
            _catalogoOrdenado = CatalogoOriginal
                .Select(t => (key: Normalizar(t), original: t)) // Genera tuplas (clave, original)
                .OrderBy(t => t.key, StringComparer.Ordinal)   // Ordena alfabéticamente
                .ToList();
        }

        // 📋 Muestra el menú principal
        private static void MostrarMenu()
        {
            Console.WriteLine("===============================================");
            Console.WriteLine("   Catálogo de Revistas - Búsqueda (C# .NET)");
            Console.WriteLine("===============================================");
            Console.WriteLine("1) Buscar un título");
            Console.WriteLine("2) Mostrar catálogo");
            Console.WriteLine("0) Salir");
            Console.WriteLine("===============================================");
        }

        // 📖 Muestra el catálogo completo con títulos originales
        private static void MostrarCatalogo()
        {
            Console.WriteLine("Catálogo de revistas (orden alfabético):");
            for (int i = 0; i < _catalogoOrdenado.Count; i++)
            {
                Console.WriteLine($" {i + 1,2}. {_catalogoOrdenado[i].original}");
            }
        }

        // 🔍 Permite al usuario buscar un título
        private static void BuscarTituloInteractivo()
        {
            Console.Write("Ingresa el título a buscar: ");
            var entrada = Console.ReadLine() ?? string.Empty;
            var clave = Normalizar(entrada); // Normalizamos lo que escribe el usuario

            // Ejecutamos búsqueda binaria
            int index = BusquedaBinariaRecursiva(_catalogoOrdenado, clave, 0, _catalogoOrdenado.Count - 1);

            if (index >= 0)
            {
                Console.WriteLine("✅ Encontrado");
                Console.WriteLine($"➡ Coincidencia: {_catalogoOrdenado[index].original}");
            }
            else
            {
                Console.WriteLine("❌ No encontrado");
            }
        }

        // ⚡ Algoritmo de Búsqueda Binaria (versión recursiva)
        private static int BusquedaBinariaRecursiva(
            List<(string key, string original)> datos,
            string clave,
            int izquierda,
            int derecha)
        {
            if (izquierda > derecha)
                return -1; // Caso base: no encontrado

            int medio = izquierda + (derecha - izquierda) / 2; // Calcula el punto medio
            int cmp = string.Compare(datos[medio].key, clave, StringComparison.Ordinal);

            if (cmp == 0)
                return medio; // 🔑 Encontrado
            if (cmp > 0)
                return BusquedaBinariaRecursiva(datos, clave, izquierda, medio - 1); // Buscar a la izquierda

            return BusquedaBinariaRecursiva(datos, clave, medio + 1, derecha); // Buscar a la derecha
        }
    }
}
