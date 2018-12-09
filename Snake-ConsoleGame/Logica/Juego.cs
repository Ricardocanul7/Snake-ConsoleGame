using Snake_ConsoleGame.Datos;
using Snake_ConsoleGame.Graficos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_ConsoleGame.Logica
{
    class Juego
    {
        Marco Marco;
        // Se pasa por referencia el menu inicial para poder reactivarlo al salir de la partida
        // o al perder del juego
        public Juego(Marco marco)
        {
            this.Marco = marco;
        }


        public void JuegoNuevo(ref MenuPrincipal menu)
        {
            // Variable para almacenar el valor de la ultima tecla presionada
            ConsoleKeyInfo tecla;
            Marco.Pintar();
            Puntuacion puntos = new Puntuacion(2, 1);
            puntos.Pintar();
            Alimento alimento = new Alimento(this.Marco);
            alimento.Pintar();

            // Leer algo del teclado
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
        }

        public void Puntuaciones(ref MenuPrincipal menu)
        {
            PantallaPuntuaciones puntuaciones = new PantallaPuntuaciones(this.Marco);
            puntuaciones.Pintar();

            ConsoleKeyInfo tecla;

            // Leer algo del teclado
            tecla = Console.ReadKey();
            // Si se presiona ESQ o Enter en el teclado, se regresa al menu principal
            if (tecla.Key == ConsoleKey.Enter || tecla.Key == ConsoleKey.Escape)
            {
                // Se limpia la pantalla del juego
                Console.Clear();
                // Se imprime nuevamente el menú en pantalla
                menu.EstaActivo = true;
                menu.Pintar();
            }
        }
    }
}
