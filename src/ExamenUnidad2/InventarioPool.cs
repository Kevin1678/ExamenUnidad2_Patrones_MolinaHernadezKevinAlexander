using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenUnidad2
{
    class InventarioPool
    {
        private List<Equipo> equiposDisponibles = new List<Equipo>();
        private List<Equipo> equiposOcupados = new List<Equipo>();

        public void AgregarEquipo(string nombre)
        {
            equiposDisponibles.Add(new Equipo(nombre));
            Console.WriteLine($"Equipo agregado: {nombre}");
        }

        //Asigna un equipo
        public Equipo ObtenerEquipo()
        {
            if (equiposDisponibles.Count > 0)
            {
                Equipo equipo = equiposDisponibles[0];
                equipo.Ocupado = true;
                equiposDisponibles.Remove(equipo);
                equiposOcupados.Add(equipo);
                return equipo;
            }
            else
            {
                Console.WriteLine("No hay equipos disponibles.");
                return null;
            }
        }

        //Recibe el equipo devuelto
        public void RegresarEquipo(Equipo equipo)
        {
            if (equipo != null)
            {
                equipo.Ocupado = false;
                equiposOcupados.Remove(equipo);
                equiposDisponibles.Add(equipo);
            }
        }

        //Muestra el estado general del inventario
        public void MostrarEstado()
        {
            Console.WriteLine("\n--- Equipos disponibles ---");
            foreach (var e in equiposDisponibles)
                e.MostrarEstado();

            Console.WriteLine("\n--- Equipos ocupados ---");
            foreach (var e in equiposOcupados)
                e.MostrarEstado();
        }
    }
}
