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

            Culebrita snake = new Culebrita(this.Marco);
            snake.Pintar();

            do{
                tecla = Console.ReadKey();
                // Si serpiente come alimento... Generar uno nuevo
                if (snake.Comio(alimento))
                {
                    snake.Crecer();

                    // Borra alimento actual en pantalla
                    alimento.BorrarAlimento();
                    // Aumentar puntos por comer
                    puntos.AgregarPuntos();
                    puntos.Actualizar();
                    alimento = new Alimento(this.Marco);
                    alimento.Actualizar();
                }

                if (tecla.Key == ConsoleKey.UpArrow)
                {
                    snake.MoverArriba();
                }
                if(tecla.Key == ConsoleKey.RightArrow)
                {
                    snake.MoverDerecha();
                }
                if (tecla.Key == ConsoleKey.LeftArrow)
                {
                    snake.MoverIzquierda();
                }
                if (tecla.Key == ConsoleKey.DownArrow)
                {
                    snake.MoverAbajo();
                }

                snake.Actualizar();
                
            } while (snake.Colisiona() == false && tecla.Key != ConsoleKey.Escape) ;

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
