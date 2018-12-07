using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_ConsoleGame.Graficos
{
    class Alimento
    {
        public Alimento()
        {
        }

        //Método para imprimir en la coordenada indicada la comida de la serpiente
        public void PintarComida()//Limites(60,23)
        {
            Console.SetCursorPosition(50, 5);
            Console.Write("+");
            Console.SetCursorPosition(6, 9);
            Console.Write("+");
            Console.SetCursorPosition(20, 11);
            Console.Write("+");
            Console.SetCursorPosition(30, 20);
            Console.Write("+");
            Console.SetCursorPosition(45, 22);
            Console.Write("+");
            Console.SetCursorPosition(2, 15);
            Console.Write("+");
        }
    }
}
