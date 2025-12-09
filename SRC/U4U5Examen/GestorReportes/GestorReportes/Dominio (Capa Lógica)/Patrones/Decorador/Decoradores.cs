using GestorReportes.GestorReportes.Dominio__Capa_Lógica_.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorReportes.GestorReportes.Dominio__Capa_Lógica_.Patrones.Decorador
{
    public class GraficoBarrasDecorador : ReporteDecorador
    {
        public GraficoBarrasDecorador(IReporte reporte) : base(reporte) { }

        public override string Generar()
        {
            return base.Generar() + "\n + [Gráfico de Barras] añadido";
        }
    }

    public class GraficoPastelDecorador : ReporteDecorador
    {
        public GraficoPastelDecorador(IReporte reporte) : base(reporte) { }

        public override string Generar()
        {
            return base.Generar() + "\n + [Gráfico de Pastel] añadido";
        }
    }

    public class FormatoTextoDecorador : ReporteDecorador
    {
        private string _fuente;
        private string _color;

        public FormatoTextoDecorador(IReporte reporte, string fuente, string color) : base(reporte)
        {
            _fuente = fuente;
            _color = color;
        }

        public override string Generar()
        {
            return base.Generar() + $"\n + [Formato: Fuente={_fuente}, Color={_color}] aplicado";
        }
    }
}
