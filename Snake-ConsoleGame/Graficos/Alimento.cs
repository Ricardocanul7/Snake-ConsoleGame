using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_ConsoleGame.Graficos
{
    class Alimento
    {
        private int CoordX;
        private int CoordY;
        private Marco marco;
        private Random random;

        public Alimento(Marco marco)
        {
            this.marco = marco;
            this.GenerarNuevo();
        }

        public int getCoordX()
        {
            return this.CoordX;
        }

        public int getCoordY()
        {
            return this.CoordY;
        }

        // Metodo para generar un nuevo alimento en coordenadas nuevas
        public void GenerarNuevo()
        {
            int limiteIzqX = 1;     // Limite 1 porque en 0 está impreso el muro del marco
            int limiteDerX = this.marco.base1;  // Limite es la base porque en la ultima coordenada está impresa el muro
            int limiteSupY = 4;     // Porque el marco comienza a partir de Y = 3 donde se pinta el muro superior
            int limiteInfY = this.marco.altura;

            // Genero numeros aleatorios para X y Y dentro de un rango dentro de los muros del marco
            random = new Random();
            this.CoordX = random.Next(limiteIzqX, limiteDerX);
            this.CoordY = random.Next(limiteSupY, limiteInfY);
        }

        //Método para imprimir en la coordenada indicada la comida de la serpiente
        public void Pintar()
        {
            Console.SetCursorPosition(this.CoordX, this.CoordY);
            Console.Write("+");
        }

        // Utilizar este metodo cuando se cambie algun valor en los atributos
        // para refrescar la posicion visual de la comida
        public void Actualizar()
        {
            Console.Clear();
            this.Pintar();
        }
    }
}
