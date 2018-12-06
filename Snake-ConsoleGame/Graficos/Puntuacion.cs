using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_ConsoleGame.Graficos
{
    class Puntuacion
    {
        public int CoordX { get; }
        public int CoordY { get; }
        private int Puntos;

        public Puntuacion(int CoordX, int CoordY)
        {
            this.CoordX = CoordX;
            this.CoordY = CoordY;
            this.Puntos = 0;
        }

        public Puntuacion(int CoordX, int CoordY, int puntosIniciales)
        {
            this.CoordX = CoordX;
            this.CoordY = CoordY;
            this.Puntos = puntosIniciales;
        }

        public void AgregarPuntos()
        {
            this.Puntos++;
        }

        public int GetPuntos()
        {
            return this.Puntos;
        }

        public void Pintar()
        {
            Console.SetCursorPosition(this.CoordX, this.CoordY);
            Console.WriteLine("Puntos: " + this.Puntos);
        }
    }
}
