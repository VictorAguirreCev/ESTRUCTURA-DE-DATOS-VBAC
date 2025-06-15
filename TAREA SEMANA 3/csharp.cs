using System;

namespace RegistroEstudiantes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Array con tres teléfonos
            string[] telefonos = { "0991234567", "0987654321", "0971122334" };

            // Crear instancia de Estudiante
            Estudiante estudiante1 = new Estudiante(
                id: 1,
                nombres: "Juan Carlos",
                apellidos: "Martínez Rivera",
                direccion: "Av. América N45-32 y Av. Universitaria",
                telefonos: telefonos
            );

            // Mostrar información
            estudiante1.MostrarInformacion();
        }
    }
}
