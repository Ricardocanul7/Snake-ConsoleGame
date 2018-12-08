using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_ConsoleGame.Modelos
{
    class Jugador
    {
        public string Nombre { get; set; }
        public int Puntuacion { get; set; }
        public DateTime Fecha { get; set; }

        public Jugador()
        {

        }

        public Jugador(string nombre, int puntuacion, DateTime fecha)
        {
            this.Nombre = nombre;
            this.Puntuacion = puntuacion;
            this.Fecha = fecha;
        }
    }
}
