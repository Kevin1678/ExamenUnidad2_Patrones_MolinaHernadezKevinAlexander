using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenUnidad2
{
    class Equipo
    {
        public string Nombre { get; set; }
        public bool Ocupado { get; set; }

        public Equipo(string nombre)
        {
            Nombre = nombre;
            Ocupado = false;
        }

        public void MostrarEstado()
        {

            if (Ocupado)
            Console.ForegroundColor = ConsoleColor.Red;   // Rojo es de color ocupado
            else
            Console.ForegroundColor = ConsoleColor.Green; // Verde es de color libre

            Console.WriteLine($"{Nombre} - Estado: {(Ocupado ? "Ocupado" : "Libre")}");
            Console.ResetColor();
        }
    }
}
