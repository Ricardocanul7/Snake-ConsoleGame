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

            // 
            MenuPrincipal menu = new MenuPrincipal(0, 60, 0, 20);
            menu.Pintar();

            // Objeto para almacenar la tecla que se presione del teclado en cada momento
            ConsoleKeyInfo tecla;

            do
            {
                // Movimiento del cursor para seleccionar opciones
                do
                {
                    tecla = Console.ReadKey();
                    if (tecla.Key == ConsoleKey.UpArrow)
                    {
                        menu.CursorArriba();
                    }
                    else
                    {
                        if (tecla.Key == ConsoleKey.DownArrow)
                        {
                            menu.CursorAbajo();
                        }
                    }
                    menu.Actualizar();
                } while (tecla.Key != ConsoleKey.Enter);

                // Ejecutar opcion seleccionada
                switch (menu.GetOpcion())
                {
                    case 1: // JUEGO NUEVO

                        break;
                    case 2: // PUNTUACIONES

                        break;
                    case 3: // SALIR
                        Console.SetCursorPosition(0, 23);
                        Console.Write("Presiona cualquier tecla para salir...");
                        break;
                    default:
                        Console.WriteLine("ERROR! OPCION INCORRECTA!");
                        break;
                }
            } while (menu.GetOpcion() != 3); // Si opcion es 3 entonces se ha seleccionado salir del programa
            // FIN



            Console.ReadKey();
        }
    }
}
