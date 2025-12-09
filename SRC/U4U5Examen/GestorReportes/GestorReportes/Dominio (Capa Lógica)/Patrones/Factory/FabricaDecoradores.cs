using GestorReportes.GestorReportes.Dominio__Capa_Lógica_.Modelo;
using GestorReportes.GestorReportes.Dominio__Capa_Lógica_.Patrones.Decorador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorReportes.GestorReportes.Dominio__Capa_Lógica_.Patrones.Factory
{
    public static class FabricaDecoradores
    {
        public static IReporte CrearDecoracion(string tipo, IReporte reporteActual, string arg1 = "", string arg2 = "")
        {
            switch (tipo.ToLower())
            {
                case "barras":
                    return new GraficoBarrasDecorador(reporteActual);
                case "pastel":
                    return new GraficoPastelDecorador(reporteActual);
                case "texto":
                    return new FormatoTextoDecorador(reporteActual, arg1, arg2);
                default:
                    Console.WriteLine("Tipo de decoración no encontrado.");
                    return reporteActual;
            }
        }
    }
}
