using System;

namespace RegistroEstudiantes
{
    // Definición de la clase Estudiante
    public class Estudiante
    {
        // Propiedades
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string[] Telefonos { get; set; }

        // Constructor
        public Estudiante(int id, string nombres, string apellidos, string direccion, string[] telefonos)
        {
            Id = id;
            Nombres = nombres;
            Apellidos = apellidos;
            Direccion = direccion;

            // Validar que el array tenga exactamente 3 teléfonos
            if (telefonos.Length == 3)
            {
                Telefonos = telefonos;
            }
            else
            {
                throw new ArgumentException("Debe ingresar exactamente 3 teléfonos.");
            }
        }

        // Método para mostrar información del estudiante
        public void MostrarInformacion()
        {
            Console.WriteLine("----- Información del Estudiante -----");
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Nombre: {Nombres} {Apellidos}");
            Console.WriteLine($"Dirección: {Direccion}");
            Console.WriteLine("Teléfonos:");
            for (int i = 0; i < Telefonos.Length; i++)
            {
                Console.WriteLine($"\tTeléfono {i + 1}: {Telefonos[i]}");
            }
        }
    }

    // Clase principal del programa
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Array con tres teléfonos
                string[] telefonos = { "0991234567", "0987654321", "0971122334" };

                // Crear instancia del estudiante
                Estudiante estudiante1 = new Estudiante(
                    id: 1,
                    nombres: "Juan Carlos",
                    apellidos: "Martínez Rivera",
                    direccion: "Av. América N45-32 y Av. Universitaria",
                    telefonos: telefonos
                );

                // Mostrar información del estudiante
                estudiante1.MostrarInformacion();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
