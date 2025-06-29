using System;
using System.Collections.Generic;

namespace POO_CursoAsignaturas
{
    // Clase que representa una Asignatura con su nombre y nota
    class Asignatura
    {
        public string Nombre { get; set; }
        public double Nota { get; set; }

        public Asignatura(string nombre)
        {
            Nombre = nombre;
            Nota = 0.0; // Inicialmente la nota es 0
        }

        public void PedirNota()
        {
            Console.Write($"¿Qué nota has sacado en {Nombre}? ");
            Nota = Convert.ToDouble(Console.ReadLine());
        }

        public void MostrarAsignatura()
        {
            Console.WriteLine($"{Nombre}: {Nota}");
        }
    }

    // Clase que representa un Curso con una lista de Asignaturas
    class Curso
    {
        public string Nombre { get; set; }
        public List<Asignatura> Asignaturas { get; set; }

        public Curso(string nombre)
        {
            Nombre = nombre;
            Asignaturas = new List<Asignatura>
            {
                new Asignatura("Matemáticas"),
                new Asignatura("Física"),
                new Asignatura("Química"),
                new Asignatura("Historia"),
                new Asignatura("Lengua")
            };
        }

        public void MostrarAsignaturas()
        {
            Console.WriteLine($"Asignaturas del curso {Nombre}:");
            foreach (var asignatura in Asignaturas)
            {
                asignatura.MostrarAsignatura();
            }
        }

        public void PedirNotas()
        {
            foreach (var asignatura in Asignaturas)
            {
                asignatura.PedirNota();
            }
        }

        public void EliminarAsignaturasAprobadas()
        {
            List<Asignatura> asignaturasRepetir = new List<Asignatura>();
            foreach (var asignatura in Asignaturas)
            {
                Console.Write($"¿Has aprobado {asignatura.Nombre}? (sí/no): ");
                string respuesta = Console.ReadLine().ToLower();
                if (respuesta == "no")
                {
                    asignaturasRepetir.Add(asignatura);
                }
            }

            Console.WriteLine("Asignaturas que tienes que repetir:");
            foreach (var asignatura in asignaturasRepetir)
            {
                Console.WriteLine(asignatura.Nombre);
            }
        }

        // Ejercicio 1: Mostrar las asignaturas de este curso
        public void Ejercicio1()
        {
            foreach (var asignatura in Asignaturas)
            {
                Console.WriteLine(asignatura.Nombre);
            }
        }

        // Ejercicio 2: Mostrar mensaje con asignaturas
        public void Ejercicio2()
        {
            foreach (var asignatura in Asignaturas)
            {
                Console.WriteLine($"Yo estudio {asignatura.Nombre}");
            }
        }

        // Ejercicio 3: Mostrar asignaturas con notas
        public void Ejercicio3()
        {
            foreach (var asignatura in Asignaturas)
            {
                Console.WriteLine($"En {asignatura.Nombre} has sacado {asignatura.Nota}");
            }
        }

        // Ejercicio 4: Ordenar números ganadores de la lotería
        public void Ejercicio4()
        {
            List<int> numeros = new List<int>();
            Console.WriteLine("Introduce los números ganadores de la lotería (separados por espacio): ");
            string[] input = Console.ReadLine().Split();
            foreach (var num in input)
            {
                numeros.Add(Convert.ToInt32(num));
            }

            numeros.Sort();
            Console.WriteLine("Números ordenados: ");
            foreach (var num in numeros)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }

        // Ejercicio 5: Mostrar números del 1 al 10 en orden inverso
        public void Ejercicio5()
        {
            List<int> numeros = new List<int>();
            for (int i = 1; i <= 10; i++)
            {
                numeros.Add(i);
            }

            numeros.Reverse();
            Console.WriteLine("Números del 1 al 10 en orden inverso:");
            Console.WriteLine(string.Join(", ", numeros));
        }
    }

    // Clase que representa un Estudiante con un nombre y una lista de Cursos
    class Estudiante
    {
        public string Nombre { get; set; }
        public List<Curso> Cursos { get; set; }

        public Estudiante(string nombre)
        {
            Nombre = nombre;
            Cursos = new List<Curso>();
        }

        public void AñadirCurso(Curso curso)
        {
            Cursos.Add(curso);
        }

        public void MostrarCursos()
        {
            Console.WriteLine($"Cursos de {Nombre}:");
            foreach (var curso in Cursos)
            {
                curso.MostrarAsignaturas();
            }
        }

        public void PedirNotas()
        {
            foreach (var curso in Cursos)
            {
                curso.PedirNotas();
            }
        }

        public void EliminarAsignaturasAprobadas()
        {
            foreach (var curso in Cursos)
            {
                curso.EliminarAsignaturasAprobadas();
            }
        }

        // Ejercicios para el Estudiante
        public void RealizarEjercicios()
        {
            foreach (var curso in Cursos)
            {
                // Ejecución de los ejercicios
                curso.Ejercicio1();
                curso.Ejercicio2();
                curso.Ejercicio3();
                curso.Ejercicio4();
                curso.Ejercicio5();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Crear un estudiante
            Estudiante estudiante = new Estudiante("Juan Pérez");

            // Crear un curso e ir añadiéndolo al estudiante
            Curso cursoMatematicas = new Curso("Matemáticas y Ciencias");
            estudiante.AñadirCurso(cursoMatematicas);

            // Pedir las notas de las asignaturas del curso
            estudiante.PedirNotas();

            // Mostrar las asignaturas y sus notas
            estudiante.MostrarCursos();

            // Realizar los ejercicios
            estudiante.RealizarEjercicios();

            // Eliminar asignaturas aprobadas (si las hay)
            estudiante.EliminarAsignaturasAprobadas();

            // Esperar entrada para cerrar
            Console.WriteLine("\nPresiona cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}
