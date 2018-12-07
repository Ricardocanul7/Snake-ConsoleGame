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
                if(menu.EstaActivo)
                {
                    // Movimiento del cursor para seleccionar opciones
                    do
                    {
                        tecla = Console.ReadKey();

                        if (tecla.Key == ConsoleKey.UpArrow)
                        {
                            menu.CursorArriba();
                        }

                        if (tecla.Key == ConsoleKey.DownArrow)
                        {
                            menu.CursorAbajo();
                        }

                        menu.Actualizar();
                    } while (tecla.Key != ConsoleKey.Enter);
                    // Al presionar Enter en el menu y seleccionar una opcion, el menú se pasa a inactivo
                    menu.EstaActivo = false;
                }


                // Ejecutar opcion seleccionada
                switch (menu.GetOpcion())
                {
                    case 1: // JUEGO NUEVO
                        Console.Clear(); // Se limpia la consola para mostrar la partida nueva del juego
                        // Base = 75, Altura = 23
                        Marco marco = new Marco(75, 23);
                        marco.Pintar();
                        Puntuacion puntos = new Puntuacion(2, 1);
                        puntos.Pintar();
                        Alimento alimento = new Alimento(marco);
                        alimento.Pintar();


                        tecla = Console.ReadKey();
                        // Si se presiona ESQ en el teclado, se regresa al menu principal
                        if (tecla.Key == ConsoleKey.Escape)
                        {
                            // Se limpia la pantalla del juego
                            Console.Clear();
                            // Se imprime nuevamente el menú en pantalla
                            menu.EstaActivo = true;
                            menu.Pintar();
                        }

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
