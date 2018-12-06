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
            // Ricardo Antoni Canul Flota


            // Esto es una prueba
            Marco marco = new Marco(60, 23);
            marco.Pintar();


            Console.ReadKey();
        }
    }
}
