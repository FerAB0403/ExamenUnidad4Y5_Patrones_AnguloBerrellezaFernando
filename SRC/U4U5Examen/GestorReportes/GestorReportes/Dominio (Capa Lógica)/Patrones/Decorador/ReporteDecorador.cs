using GestorReportes.GestorReportes.Dominio__Capa_Lógica_.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorReportes.GestorReportes.Dominio__Capa_Lógica_.Patrones.Decorador
{
    public abstract class ReporteDecorador : IReporte
    {
        protected IReporte _reporteEnvuelto;

        public ReporteDecorador(IReporte reporte)
        {
            _reporteEnvuelto = reporte;
        }

        public virtual string Generar()
        {
            return _reporteEnvuelto.Generar();
        }
    }
}
