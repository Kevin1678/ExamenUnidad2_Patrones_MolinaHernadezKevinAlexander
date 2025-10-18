using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenUnidad2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Singleton: solo una instancia
            CoordinadorInventario coordinador1 = CoordinadorInventario.ObtenerInstancia();
            CoordinadorInventario coordinador2 = CoordinadorInventario.ObtenerInstancia();

            Console.WriteLine("\nComprobación del Singleton:");
            Console.WriteLine(ReferenceEquals(coordinador1, coordinador2));

            //El coordinador agrega materiales al inventario
            Console.WriteLine();
            coordinador1.AgregarEquipo("Protoboard");
            coordinador1.AgregarEquipo("Multímetro");
            coordinador1.AgregarEquipo("Fuente de poder");

            //Mostrar inventario
            coordinador1.MostrarInventario();

            //Préstamo
            Console.WriteLine("\nUn alumno solicita un equipo:");
            var inventario = coordinador1.ObtenerInventario();
            Equipo equipoPrestado = inventario.ObtenerEquipo();
            Console.WriteLine($"Equipo prestado: {equipoPrestado.Nombre}");

            coordinador1.MostrarInventario();

            //Devolución
            Console.WriteLine("\nEl alumno devuelve el equipo:");
            coordinador1.DevolverEquipo(equipoPrestado);
            coordinador1.MostrarInventario();
            Console.ReadKey();
        }
    }
}
