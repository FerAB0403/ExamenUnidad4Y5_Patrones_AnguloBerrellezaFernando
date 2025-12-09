using GestorReportes.GestorReportes.Dominio__Capa_Lógica_.Modelo;
using GestorReportes.GestorReportes.Dominio__Capa_Lógica_.Patrones.Composite;
using GestorReportes.GestorReportes.Dominio__Capa_Lógica_.Patrones.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorReportes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<IReporte> historial = new Stack<IReporte>();

            IReporte miReporte = new ReporteBase();

            bool editando = true;

            while (editando)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n VISTRA PREVIA ACTUAL");
                Console.WriteLine(miReporte.Generar());
                Console.ResetColor();

                Console.WriteLine("\nOpciones de Edición:");
                Console.WriteLine("1. Agregar Gráfico de Barras");
                Console.WriteLine("2. Agregar Gráfico de Pastel");
                Console.WriteLine("3. Aplicar Formato de Texto");
                Console.WriteLine("4. DESHACER último cambio (Memento)");
                Console.WriteLine("0. Terminar edición y Exportar");
                Console.Write("Seleccione: ");
                string op = Console.ReadLine();

                if (op == "1" || op=="2" || op== "3")
                {
                    historial.Push(miReporte);
                }

                switch (op)
                {
                    case "1":
                        Console.Clear();
                        miReporte = FabricaDecoradores.CrearDecoracion("barras", miReporte);
                        break;

                    case "2":
                        Console.Clear();
                        miReporte = FabricaDecoradores.CrearDecoracion("pastel", miReporte);
                        break;

                    case "3":
                        Console.Clear();
                        Console.Write("Fuente: "); string f = Console.ReadLine();
                        Console.Write("Color: "); string c = Console.ReadLine();
                        miReporte = FabricaDecoradores.CrearDecoracion("texto", miReporte, f, c);
                        break;

                    case "4":
                        Console.Clear();
                        if (historial.Count > 0)
                        {
                            miReporte = historial.Pop();
                            Console.WriteLine("-> Cambio deshecho exitosamente.");
                        }
                        else
                        {
                            Console.WriteLine("-> No hay acciones para deshacer.");
                        }
                        break;

                    case "0":
                        Console.Clear();
                        editando = false;
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Opción no válida");
                        break;
                }
            }

            Console.WriteLine("\n\n\tEXPORTACIÓN DEL REPORTE");
            var raiz = new CategoriaExportar("Formatos");
            var docs = new CategoriaExportar("Documentos");
            var imgs = new CategoriaExportar("Imágenes");

            raiz.Agregar(docs);
            raiz.Agregar(imgs);

            docs.Agregar(new FormatoExportar("PDF"));
            docs.Agregar(new FormatoExportar("Word"));
            docs.Agregar(new FormatoExportar("Excel"));

            imgs.Agregar(new FormatoExportar("JPG"));
            imgs.Agregar(new FormatoExportar("PNG"));

            raiz.MostrarJerarquia(0);

            Console.Write("Escriba el formato deseado (ej. PDF, JPG): ");
            string formatoElegido = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(formatoElegido))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n--- EXPORTANDO REPORTE A {formatoElegido.ToUpper()} ---");
                Console.WriteLine(miReporte.Generar());
                Console.WriteLine($"--- ARCHIVO GUARDADO COMO: reporte_final.{formatoElegido.ToLower()} ---");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine(">> Exportación cancelada por el usuario.");
            }

            Console.WriteLine("\nPresione Enter para salir");
            Console.ReadKey();
        }
    }
}
