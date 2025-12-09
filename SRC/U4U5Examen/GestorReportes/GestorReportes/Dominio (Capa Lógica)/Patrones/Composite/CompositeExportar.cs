using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorReportes.GestorReportes.Dominio__Capa_Lógica_.Patrones.Composite
{
    public abstract class ComponenteExportar
    {
        public string Nombre { get; set; }
        public ComponenteExportar(string nombre) { Nombre = nombre; }
        public abstract void MostrarJerarquia(int nivel);
    }

    public class FormatoExportar : ComponenteExportar
    {
        public FormatoExportar(string nombre) : base(nombre) { }

        public override void MostrarJerarquia(int nivel)
        {
            Console.WriteLine(new string('-', nivel) + " " + Nombre);
        }
    }

    public class CategoriaExportar : ComponenteExportar
    {
        private List<ComponenteExportar> _hijos = new List<ComponenteExportar>();

        public CategoriaExportar(string nombre) : base(nombre) { }

        public void Agregar(ComponenteExportar componente)
        {
            _hijos.Add(componente);
        }

        public override void MostrarJerarquia(int nivel)
        {
            Console.WriteLine(new string('+', nivel) + " " + Nombre);
            foreach (var hijo in _hijos)
            {
                hijo.MostrarJerarquia(nivel + 2);
            }
        }
    }
}
