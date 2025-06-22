// Sistema de Agenda de Turnos para un Consultorio Médico en C# con Programación Orientada a Objetos
using System;
using System.Collections.Generic;

namespace AgendaTurnosConsultorio
{
    // Clase que representa a un paciente con su turno asignado
    public class Paciente
    {
        public string Nombre { get; set; }
        public string Identificacion { get; set; }
        public string Especialidad { get; set; }
        public string Fecha { get; set; }
        public string Hora { get; set; }

        public Paciente(string nombre, string identificacion, string especialidad, string fecha, string hora)
        {
            Nombre = nombre;
            Identificacion = identificacion;
            Especialidad = especialidad;
            Fecha = fecha;
            Hora = hora;
        }

        public void MostrarTurno()
        {
            Console.WriteLine($"Nombre: {Nombre}, ID: {Identificacion}, Especialidad: {Especialidad}, Fecha: {Fecha}, Hora: {Hora}");
        }
    }

    // Clase que representa la agenda de turnos
    public class AgendaTurnos
    {
        private List<Paciente> turnos;

        public AgendaTurnos()
        {
            turnos = new List<Paciente>();
        }

        public void AgendarTurno()
        {
            Console.Write("Ingrese nombre del paciente: ");
            string nombre = Console.ReadLine();
            Console.Write("Ingrese número de identificación: ");
            string identificacion = Console.ReadLine();
            string especialidad = SeleccionarEspecialidad();
            Console.Write("Ingrese fecha del turno (dd/mm/aaaa): ");
            string fecha = Console.ReadLine();
            Console.Write("Ingrese hora del turno (HH:MM): ");
            string hora = Console.ReadLine();

            Paciente paciente = new Paciente(nombre, identificacion, especialidad, fecha, hora);
            turnos.Add(paciente);

            Console.WriteLine("\nTurno agendado exitosamente.\n");
        }

        private string SeleccionarEspecialidad()
        {
            string[] especialidades = { "Medicina General", "Cardiología", "Pediatría", "Psicología" };
            Console.WriteLine("Seleccione especialidad:");
            for (int i = 0; i < especialidades.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {especialidades[i]}");
            }
            Console.Write("Opción: ");
            int opcion = int.Parse(Console.ReadLine());
            return (opcion >= 1 && opcion <= 4) ? especialidades[opcion - 1] : especialidades[0];
        }

        public void ConsultarPorEspecialidad()
        {
            string especialidad = SeleccionarEspecialidad();
            Console.WriteLine($"\nTurnos para {especialidad}:");
            bool encontrados = false;
            foreach (var paciente in turnos)
            {
                if (paciente.Especialidad == especialidad)
                {
                    paciente.MostrarTurno();
                    encontrados = true;
                }
            }
            if (!encontrados)
            {
                Console.WriteLine("No hay turnos registrados para esta especialidad.\n");
            }
        }

        public void MostrarTodosLosTurnos()
        {
            Console.WriteLine("\nTodos los turnos registrados:");
            if (turnos.Count == 0)
            {
                Console.WriteLine("No hay turnos registrados.\n");
            }
            else
            {
                foreach (var paciente in turnos)
                {
                    paciente.MostrarTurno();
                }
            }
        }
    }

    // Clase principal del sistema
    class Program
    {
        static void Main(string[] args)
        {
            AgendaTurnos agenda = new AgendaTurnos();
            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("\n=== MENÚ DE AGENDA DE TURNOS ===");
                Console.WriteLine("1. Agendar nuevo turno");
                Console.WriteLine("2. Consultar turnos por especialidad");
                Console.WriteLine("3. Mostrar todos los turnos");
                Console.WriteLine("4. Salir");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        agenda.AgendarTurno();
                        break;
                    case "2":
                        agenda.ConsultarPorEspecialidad();
                        break;
                    case "3":
                        agenda.MostrarTodosLosTurnos();
                        break;
                    case "4":
                        salir = true;
                        Console.WriteLine("Saliendo del sistema...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intente nuevamente.");
                        break;
                }
            }
        }
    }
}
