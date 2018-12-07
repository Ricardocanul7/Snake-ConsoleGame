using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snake_ConsoleGame.Graficos;

namespace Snake_ConsoleGame
{
    class Program
    {
        static void Main(string[] args)
        {
            // Colaboradores
            // Alan Alexis Moreno Martinez
            // Ricardo Antonio Canul Flota

            int CoordX, CoordY;
            // Esto es una prueba
            Marco marco = new Marco(60, 23);
            marco.Pintar();
            Puntuacion puntuacion = new Puntuacion(50, 1);
            puntuacion.Pintar();
            Alimento alimento = new Alimento();
            alimento.PintarComida();

            Console.ReadKey();
        }
    }
}
