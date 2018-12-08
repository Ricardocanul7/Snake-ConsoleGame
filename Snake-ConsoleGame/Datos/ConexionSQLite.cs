using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using Snake_ConsoleGame.Modelos;

namespace Snake_ConsoleGame.Datos
{
    class ConexionSQLite
    {
        private string DatabasePath;
        private string DatabaseName;

        public ConexionSQLite()
        {
            DatabasePath = "Puntuaciones.sqlite";
            DatabaseName = "Puntuaciones";
        }

        public void CrearTabla()
        {
            try
            {

                if(!System.IO.File.Exists(System.IO.Directory.GetCurrentDirectory() + "/" + DatabasePath))
                {
                    SQLiteConnection.CreateFile(DatabasePath);

                    SQLiteConnection conexion = new SQLiteConnection("Data Source=" + DatabasePath + ";Version=3;");
                    conexion.Open();

                    string sql = "CREATE TABLE IF NOT EXISTS " + DatabaseName + "(id INTEGER PRIMARY KEY, " +
                                                                                "nombre VARCHAR(60) NOT NULL, " +
                                                                                "puntuacion INTEGER, " +
                                                                                "fecha TEXT)";

                    SQLiteCommand command = new SQLiteCommand(sql, conexion);
                    command.ExecuteNonQuery();

                    conexion.Close();
                    command.Dispose();
                }
            }
            catch(SQLiteException e)
            {
                Console.SetCursorPosition(1, 1);
                Console.WriteLine("ERROR CREATE TABLE - " + e.Message);
                Console.ReadKey();
            }
        }

        public void InsertarJugador(Jugador jugador)
        {
            try
            {
                SQLiteConnection conexion = new SQLiteConnection("Data Source=" + DatabasePath + ";Version=3;");
                conexion.Open();

                string sql = "INSERT INTO " + DatabaseName + "(nombre, puntuacion, fecha)" +
                                                               "values(" +
                                                               "'" + jugador.Nombre + "'," +
                                                               jugador.Puntuacion + "," +
                                                               "'" + jugador.Fecha.ToString() + "'" +
                                                               ")";

                SQLiteCommand command = new SQLiteCommand(sql, conexion);
                command.ExecuteNonQuery();

                conexion.Close();
                command.Dispose();
            }catch(SQLiteException e)
            {
                Console.SetCursorPosition(1, 1);
                Console.WriteLine("ERROR INSERT INTO - " + e.Message);
                Console.ReadKey();
            }
           
        }
    }
}
