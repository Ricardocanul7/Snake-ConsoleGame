﻿using System;
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

        /**
         * El constructor se inicializa con las coordenadas donde se mostrará la puntuacion
         * */
        public Puntuacion(int CoordX, int CoordY)
        {
            this.CoordX = CoordX;
            this.CoordY = CoordY;
            this.Puntos = 0;
        }

        /**
         * El constructor se inicializa con las coordenadas donde se mostrará la puntuacion
         * Además si la puntuacion ya está guardada, y se quiere iniciar con puntuacion mayor a 0
         * se puede pasar como parametro
         * */
        public Puntuacion(int CoordX, int CoordY, int puntosIniciales)
        {
            this.CoordX = CoordX;
            this.CoordY = CoordY;
            this.Puntos = puntosIniciales;
        }

        /** Cada vez que el jugador logre algo,
         * llamar a esta funcion para hacer incrementar la puntuacion
        **/
        public void AgregarPuntos()
        {
            this.Puntos++;
        }

        
        public int GetPuntos()
        {
            return this.Puntos;
        }

        // Metodo para imprimir la puntuacion en la consola
        public void Pintar()
        {
            Console.SetCursorPosition(this.CoordX, this.CoordY);
            Console.WriteLine("Puntos: " + this.Puntos);
        }

        /**
         * Metodo para actualizar el grafico en pantalla,
         * y se muestre la puntuacion actualizada o cualquier elemento que haya cambiado
         * */
        public void Actualizar()
        {
            Console.Clear();
            this.Pintar();
        }
    }
}
