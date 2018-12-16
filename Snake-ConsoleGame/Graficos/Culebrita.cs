using Snake_ConsoleGame.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_ConsoleGame.Graficos
{
    class Culebrita
    {
        private ParteDeCulebrita Cabeza;
        private ParteDeCulebrita Cola;
        private List<ParteDeCulebrita> Snake;
        private List<ParteDeCulebrita> SnakeBefore;
        private Marco Marco;
        public bool EstaViva { get; set; }
        public int Velocidad { get; set; }

        public Culebrita(Marco marco)
        {
            this.Marco = marco;
            this.Cabeza = PuntoCentral();  // Para que la cabeza de la serpiente aparezca en el centro de la pantalla
            this.Cabeza.Simbolo = '@';     // Representa la cabeza de la serpiente

            this.Cola = PuntoCentral();
            this.Cola.X--;                 // La cola tiene que estar detras de la cabeza en la coordenada X
            this.Cola.Simbolo = '*';       // Simbolo que representa la cola

            this.Snake = new List<ParteDeCulebrita>();  // Inicializa el cuerpo de la serpiente en una lista
            this.Snake.Add(Cabeza);        // Se agrega la cabeza al cuerpo de la serpiente
            this.Snake.Add(Cola);          // Se agrega la cola al cuerpo de la serpiente
            this.SnakeBefore = new List<ParteDeCulebrita>();

            this.EstaViva = true;
            this.Velocidad = 20;
        }

        public ParteDeCulebrita PuntoCentral()
        {
            ParteDeCulebrita coordLocal = new ParteDeCulebrita();

            coordLocal.X = this.Marco.base1 / 2;
            coordLocal.Y = (this.Marco.altura / 5) * 3;

            return coordLocal;
        }

        public void Pintar()
        {
            foreach(var parte in Snake)
            {
                Console.SetCursorPosition(parte.X, parte.Y);
                Console.Write(parte);
                //Console.Write(Snake.Count);
            }
            this.SnakeBefore = this.Snake.ToList();
        }

        public void Actualizar()
        {
            this.BorrarColaAnterior(); 
            // Imprimir Snake en el frame actual
            this.Pintar();
        }

        public void MoverArriba()
        {
            // copiar toda la culebrita antes de moverla
            //this.SnakeBefore.Clear();
            this.SnakeBefore = this.copiarCulebrita(this.Snake);
            List<ParteDeCulebrita> cuerpoTemp = this.copiarCulebrita(this.Snake);

            // Se limpia la lista
            this.Snake.Clear();
            ParteDeCulebrita apuntadorCabeza = this.Cabeza;
            // Se crea una cabeza temporal que no apunte hacia la cabeza actual
            ParteDeCulebrita cabezaNueva = new ParteDeCulebrita(apuntadorCabeza.X, apuntadorCabeza.Y, apuntadorCabeza.Simbolo);
            // Se cambia su coordenada en Y para subirla un espacio
            cabezaNueva.Y--;                 // Al restar una coordenada en Y la cabeza subira en la pantalla un espacio
            // Teniendo la lista limpia se agrega una nueva cabeza en una posicion arriba
            this.Snake.Add(cabezaNueva);

            // Se recorre la lista que contiene el apuntador a la cabeza, y a la cola
            ParteDeCulebrita parte;
            for(int i = 0; i < cuerpoTemp.Count; i++)
            {
                if (cuerpoTemp[i + 1].Simbolo == '*')
                {
                    parte = cuerpoTemp[i];
                    this.Snake.Add(new ParteDeCulebrita(parte.X, parte.Y, '*'));
                    // Se elimina la cola en la ultima posicion
                    // El apuntador necesita cambiarse a ultima posicion al terminar el ciclo
                    cuerpoTemp.RemoveAt(i + 1);
                }
                else
                {
                    parte = cuerpoTemp[i];
                    this.Snake.Add(new ParteDeCulebrita(parte.X, parte.Y, '#'));
                }
            }

            // Se actualiza posicion de cabeza
            this.Cabeza = this.Snake[0];
            // Se actualiza el apuntador a la cola en la ultima posicion de la lista
            this.Cola = this.Snake[this.Snake.Count - 1];
        }

        public void MoverDerecha()
        {
            // copiar toda la culebrita antes de moverla
            //this.SnakeBefore.Clear();
            this.SnakeBefore = this.copiarCulebrita(this.Snake);
            List<ParteDeCulebrita> cuerpoTemp = this.copiarCulebrita(this.Snake);

            // Se limpia la lista
            this.Snake.Clear();
            ParteDeCulebrita apuntadorCabeza = this.Cabeza;
            // Se crea una cabeza temporal que no apunte hacia la cabeza actual
            ParteDeCulebrita cabezaNueva = new ParteDeCulebrita(apuntadorCabeza.X, apuntadorCabeza.Y, apuntadorCabeza.Simbolo);
            // Se cambia su coordenada en Y para subirla un espacio
            cabezaNueva.X++;                 
            // Teniendo la lista limpia se agrega una nueva cabeza en una posicion arriba
            this.Snake.Add(cabezaNueva);

            // Se recorre la lista que contiene el apuntador a la cabeza, y a la cola
            ParteDeCulebrita parte;
            for (int i = 0; i < cuerpoTemp.Count; i++)
            {
                if (cuerpoTemp[i + 1].Simbolo == '*')
                {
                    parte = cuerpoTemp[i];
                    this.Snake.Add(new ParteDeCulebrita(parte.X, parte.Y, '*'));
                    // Se elimina la cola en la ultima posicion
                    // El apuntador necesita cambiarse a ultima posicion al terminar el ciclo
                    cuerpoTemp.RemoveAt(i + 1);
                }
                else
                {
                    parte = cuerpoTemp[i];
                    this.Snake.Add(new ParteDeCulebrita(parte.X, parte.Y, '#'));
                }
            }

            // Se actualiza posicion de cabeza
            this.Cabeza = this.Snake[0];
            // Se actualiza el apuntador a la cola en la ultima posicion de la lista
            this.Cola = this.Snake[this.Snake.Count - 1];
        }

        public void MoverIzquierda()
        {
            // copiar toda la culebrita antes de moverla
            //this.SnakeBefore.Clear();
            this.SnakeBefore = this.copiarCulebrita(this.Snake);
            List<ParteDeCulebrita> cuerpoTemp = this.copiarCulebrita(this.Snake);

            // Se limpia la lista
            this.Snake.Clear();
            ParteDeCulebrita apuntadorCabeza = this.Cabeza;
            // Se crea una cabeza temporal que no apunte hacia la cabeza actual
            ParteDeCulebrita cabezaNueva = new ParteDeCulebrita(apuntadorCabeza.X, apuntadorCabeza.Y, apuntadorCabeza.Simbolo);
            // Se cambia su coordenada en Y para subirla un espacio
            cabezaNueva.X--;                 
            // Teniendo la lista limpia se agrega una nueva cabeza en una posicion arriba
            this.Snake.Add(cabezaNueva);

            // Se recorre la lista que contiene el apuntador a la cabeza, y a la cola
            ParteDeCulebrita parte;
            for (int i = 0; i < cuerpoTemp.Count; i++)
            {
                if (cuerpoTemp[i + 1].Simbolo == '*')
                {
                    parte = cuerpoTemp[i];
                    this.Snake.Add(new ParteDeCulebrita(parte.X, parte.Y, '*'));
                    // Se elimina la cola en la ultima posicion
                    // El apuntador necesita cambiarse a ultima posicion al terminar el ciclo
                    cuerpoTemp.RemoveAt(i + 1);
                }
                else
                {
                    parte = cuerpoTemp[i];
                    this.Snake.Add(new ParteDeCulebrita(parte.X, parte.Y, '#'));
                }
            }

            // Se actualiza posicion de cabeza
            this.Cabeza = this.Snake[0];
            // Se actualiza el apuntador a la cola en la ultima posicion de la lista
            this.Cola = this.Snake[this.Snake.Count - 1];
        }

        public void MoverAbajo()
        {
            // copiar toda la culebrita antes de moverla
            //this.SnakeBefore.Clear();
            this.SnakeBefore = this.copiarCulebrita(this.Snake);
            List<ParteDeCulebrita> cuerpoTemp = this.copiarCulebrita(this.Snake);

            // Se limpia la lista
            this.Snake.Clear();
            ParteDeCulebrita apuntadorCabeza = this.Cabeza;
            // Se crea una cabeza temporal que no apunte hacia la cabeza actual
            ParteDeCulebrita cabezaNueva = new ParteDeCulebrita(apuntadorCabeza.X, apuntadorCabeza.Y, apuntadorCabeza.Simbolo);
            // Se cambia su coordenada en Y para subirla un espacio
            cabezaNueva.Y++;
            // Teniendo la lista limpia se agrega una nueva cabeza en una posicion arriba
            this.Snake.Add(cabezaNueva);

            // Se recorre la lista que contiene el apuntador a la cabeza, y a la cola
            ParteDeCulebrita parte;
            for (int i = 0; i < cuerpoTemp.Count; i++)
            {
                if (cuerpoTemp[i + 1].Simbolo == '*')
                {
                    parte = cuerpoTemp[i];
                    this.Snake.Add(new ParteDeCulebrita(parte.X, parte.Y, '*'));
                    // Se elimina la cola en la ultima posicion
                    // El apuntador necesita cambiarse a ultima posicion al terminar el ciclo
                    cuerpoTemp.RemoveAt(i + 1);
                }
                else
                {
                    parte = cuerpoTemp[i];
                    this.Snake.Add(new ParteDeCulebrita(parte.X, parte.Y, '#'));
                }
            }

            // Se actualiza posicion de cabeza
            this.Cabeza = this.Snake[0];
            // Se actualiza el apuntador a la cola en la ultima posicion de la lista
            this.Cola = this.Snake[this.Snake.Count - 1];
        }

        public void Crecer()
        {
            ParteDeCulebrita cuerpo = this.Snake[Snake.Count - 1];
            this.Snake.RemoveAt(this.Snake.Count - 1);
            this.Snake.Add(new ParteDeCulebrita(cuerpo.X, cuerpo.Y, '#'));

            // Insertar la cola de la serpiente en el momento anterior
            ParteDeCulebrita cola = this.SnakeBefore[SnakeBefore.Count - 1];
            this.Snake.Add(new ParteDeCulebrita(cola.X, cola.Y, '*'));

            this.Cola = cola;
        }

        public List<ParteDeCulebrita> copiarCulebrita(List<ParteDeCulebrita> snake)
        {
            List<ParteDeCulebrita> RSnake = new List<ParteDeCulebrita>();
            foreach(var parte in snake)
            {
                RSnake.Add(new ParteDeCulebrita(parte.X, parte.Y, parte.Simbolo));
            }
            return RSnake;
        }

        public bool Comio(Alimento alimento)
        {
            if (this.Cabeza.X == alimento.CoordX && this.Cabeza.Y == alimento.CoordY)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Colisiona()
        {
            // Validacion si choca con el muro
            if(Cabeza.X <= 0 || Cabeza.X > Marco.base1 - 1 || Cabeza.Y <= 3 || Cabeza.Y > Marco.altura - 1)
            {
                this.EstaViva = false;
                return true;
            }
            else
            {
                // Validacion si choca con ella misma
                if (this.SelfColision())
                {
                    this.EstaViva = false;
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private bool SelfColision()
        {
            // Cabeza
            ParteDeCulebrita parte = this.Snake[0];
            ParteDeCulebrita parteComparar;

            for(int i = 1; i < this.Snake.Count; i++)
            {
                parteComparar = this.Snake[i];
                /** Verificar si la cabeza tiene la misma coordenada
                 ** que alguna parte de su cuerpo para determinar si ha colisionado */
                if (parte.X == parteComparar.X && parte.Y == parteComparar.Y)
                {
                    return true;
                }
            }

            // Si no detecta coliciones de alguna parte del cuerpo con la cabeza, devuelve falso
            return false;
        }

        private void BorrarColaAnterior()
        {
            // Devolver la cola de la culebrita en el del momento anterior para borrarlo del buffer de la pantalla
            ParteDeCulebrita colaAnterior = SnakeBefore[SnakeBefore.Count - 1];

            Console.SetCursorPosition(colaAnterior.X, colaAnterior.Y);
            Console.Write(" ");
        }
    }
}
