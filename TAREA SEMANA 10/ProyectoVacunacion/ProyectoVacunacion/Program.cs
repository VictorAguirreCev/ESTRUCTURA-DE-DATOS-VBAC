using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;

public static class VacunacionCovid
{
    // ======== MODELO ========
    public class Ciudadano
    {
        public int Id { get; }
        public string Nombre { get; }
        public Ciudadano(int id)
        {
            Id = id;
            Nombre = $"Ciudadano {id}";
        }
    }

    // ======== GENERACIÓN DE DATOS ========
    public static List<Ciudadano> GenerarUniverso(int n)
        => Enumerable.Range(1, n).Select(i => new Ciudadano(i)).ToList();

    /// <summary>
    /// Devuelve dos conjuntos con índices de ciudadanos:
    /// P: vacunados con Pfizer (|P| = cantidadPfizer)
    /// A: vacunados con AstraZeneca (|A| = cantidadAstra)
    /// El solapamiento P∩A es posible (representa "ambas dosis" para este ejercicio).
    /// </summary>
    public static (HashSet<int> P, HashSet<int> A) AsignarVacunas(
        int universoTam, int cantidadPfizer, int cantidadAstra, int? seed = null)
    {
        var rnd = seed.HasValue ? new Random(seed.Value) : new Random();
        var P = new HashSet<int>();
        var A = new HashSet<int>();

        // Elegimos índices de 1..universoTam
        while (P.Count < cantidadPfizer) P.Add(rnd.Next(1, universoTam + 1));
        while (A.Count < cantidadAstra) A.Add(rnd.Next(1, universoTam + 1));

        return (P, A);
    }

    // ======== TEORÍA DE CONJUNTOS ========
    // U = {1..N}
    // P = vacunados con Pfizer
    // A = vacunados con AstraZeneca
    // No vacunados = U \ (P ∪ A)
    // Ambas dosis = P ∩ A
    // Solo Pfizer = P \ A
    // Solo AstraZeneca = A \ P
    public static List<Ciudadano> Mapear(List<Ciudadano> universo, IEnumerable<int> indices)
        => indices.Select(i => universo[i - 1]).ToList();

    // ======== REPORTE PDF ========
    public static void GenerarReportePDF(
        List<Ciudadano> noVacunados,
        List<Ciudadano> ambas,
        List<Ciudadano> soloPfizer,
        List<Ciudadano> soloAstra,
        string ruta = "ReporteVacunacion.pdf")
    {
        using var fs = new FileStream(ruta, FileMode.Create, FileAccess.Write, FileShare.None);
        using var doc = new Document(PageSize.A4, 36, 36, 36, 36);
        PdfWriter.GetInstance(doc, fs);
        doc.Open();

        var titulo = new Paragraph("Reporte de Vacunación contra COVID-19", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16));
        titulo.Alignment = Element.ALIGN_CENTER;
        doc.Add(titulo);
        doc.Add(new Paragraph($"Generado: {DateTime.Now:yyyy-MM-dd HH:mm}", FontFactory.GetFont(FontFactory.HELVETICA, 9)));
        doc.Add(Chunk.NEWLINE);

        void Seccion(string encabezado, List<Ciudadano> lista)
        {
            doc.Add(new Paragraph($"{encabezado} ({lista.Count})", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12)));
            doc.Add(new Paragraph(" "));

            // Tabla de 3 columnas para compactar
            var tabla = new PdfPTable(3) { WidthPercentage = 100 };
            foreach (var (c, idx) in lista.Select((c, i) => (c, i)))
            {
                var cell = new PdfPCell(new Phrase(c.Nombre, FontFactory.GetFont(FontFactory.HELVETICA, 10)))
                {
                    Border = Rectangle.NO_BORDER,
                    Padding = 3f
                };
                tabla.AddCell(cell);
            }
            // Asegura completar la fila final
            while (tabla.Rows.Count > 0 && (tabla.Rows.Last().GetCells().Length % 3 != 0))
            {
                tabla.AddCell(new PdfPCell(new Phrase(" ")) { Border = Rectangle.NO_BORDER });
            }

            doc.Add(tabla);
            doc.Add(Chunk.NEWLINE);
        }

        Seccion("Ciudadanos no vacunados", noVacunados);
        Seccion("Ciudadanos vacunados con ambas dosis", ambas);
        Seccion("Ciudadanos vacunados solo con Pfizer", soloPfizer);
        Seccion("Ciudadanos vacunados solo con AstraZeneca", soloAstra);

        doc.Close();
    }

    // ======== PROGRAMA PRINCIPAL ========
    public static void Main()
    {
        const int N = 500;
        const int PFIZER = 75;
        const int ASTRA = 75;
        const int SEED = 2025; // cambia o quítalo para resultados diferentes

        // 1) Universo U
        var U = GenerarUniverso(N);

        // 2) Conjuntos P y A
        var (P, A) = AsignarVacunas(N, PFIZER, ASTRA, SEED);

        // 3) Operaciones de conjuntos
        var unionPA = new HashSet<int>(P);
        unionPA.UnionWith(A);

        var noVacIdx = Enumerable.Range(1, N).Except(unionPA).ToList();
        var ambasIdx = P.Intersect(A).ToList();
        var soloPfizerIdx = P.Except(A).ToList();
        var soloAstraIdx = A.Except(P).ToList();

        // 4) Mapear índices -> objetos Ciudadano
        var noVacunados = Mapear(U, noVacIdx);
        var vacunadosAmbas = Mapear(U, ambasIdx);
        var vacunadosSoloPfizer = Mapear(U, soloPfizerIdx);
        var vacunadosSoloAstra = Mapear(U, soloAstraIdx);

        // 5) Salida en consola
        Console.WriteLine($"Total ciudadanos: {N}");
        Console.WriteLine($"Vacunados con Pfizer (P): {P.Count}");
        Console.WriteLine($"Vacunados con AstraZeneca (A): {A.Count}");
        Console.WriteLine($"No vacunados |U \\ (P ∪ A)|: {noVacunados.Count}");
        Console.WriteLine($"Ambas dosis |P ∩ A|: {vacunadosAmbas.Count}");
        Console.WriteLine($"Solo Pfizer |P \\ A|: {vacunadosSoloPfizer.Count}");
        Console.WriteLine($"Solo AstraZeneca |A \\ P|: {vacunadosSoloAstra.Count}");

        // 6) PDF (opcional, pero aquí lo generamos)
        GenerarReportePDF(noVacunados, vacunadosAmbas, vacunadosSoloPfizer, vacunadosSoloAstra);
        Console.WriteLine("Reporte PDF generado: ReporteVacunacion.pdf");
    }
}
