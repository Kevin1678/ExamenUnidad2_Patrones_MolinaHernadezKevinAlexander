using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenUnidad2
{
    class CoordinadorInventario
    {
        private static CoordinadorInventario instancia;
        private static readonly object bloqueo = new object();

        // Aquí se conecta el Singleton con el Object Pool
        private InventarioPool inventario;

        private CoordinadorInventario()
        {
            inventario = new InventarioPool();
            Console.WriteLine("Coordinador del inventario creado.");
        }

        public static CoordinadorInventario ObtenerInstancia()
        {
            lock (bloqueo)
            {
                if (instancia == null)
                    instancia = new CoordinadorInventario();
                else
                    Console.WriteLine("Ya existe un coordinador, no se puede crear otro.");
            }
            return instancia;
        }

        //Método que conectan al coordinador con el pool
        public void AgregarEquipo(string nombre)
        {
            inventario.AgregarEquipo(nombre);
        }

        public void PrestarEquipo()
        {
            Equipo equipo = inventario.ObtenerEquipo();
            if (equipo != null)
                Console.WriteLine($"El coordinador prestó: {equipo.Nombre}");
        }

        public void DevolverEquipo(Equipo equipo)
        {
            inventario.RegresarEquipo(equipo);
            Console.WriteLine($"El coordinador recibió de vuelta: {equipo.Nombre}");
        }

        public void MostrarInventario()
        {
            inventario.MostrarEstado();
        }

        //Permite acceder al inventario
        public InventarioPool ObtenerInventario()
        {
            return inventario;
        }
    }
}
