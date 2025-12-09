using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorReportes.GestorReportes.Dominio__Capa_Lógica_.Modelo
{
    public class ReporteBase : IReporte
    {
        public string Generar()
        {
            return "--- REPORTE BASE ---";
        }
    }
}
