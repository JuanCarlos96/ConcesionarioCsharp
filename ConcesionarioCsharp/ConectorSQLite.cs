using Finisar.SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcesionarioCsharp
{
    public class ConectorSQLite
    {
        private SQLiteConnection sqlite_con; //Conexión
        private SQLiteCommand consulta; //Comando

        public ConectorSQLite()
        {
            sqlite_con = new SQLiteConnection(); // Se crea la instancia
            consulta = sqlite_con.CreateCommand();//La que me permitirá ejecutar acciones sobre la base de datos
            sqlite_con.ConnectionString = "Data Source=concesionario.db;Version=3;New=False;Compress=True;"; // Se crea la cadena de conexión para ABRIR
            try
            {
                sqlite_con.Open(); // Se abre la conexión
            }
            catch (Finisar.SQLite.SQLiteException)
            {
                sqlite_con.ConnectionString = "Data Source=concesionario.db;Version=3;New=True;Compress=True;"; // Se crea la cadena de conexión para CREAR
                sqlite_con.Open(); // Se abre la conexión
                crearBBDD();
            }
        }

        public SQLiteConnection DameConexion()
        {
            return sqlite_con;
        }

        public SQLiteCommand DameComando()
        {
            return this.consulta;
        }

        public void crearBBDD()
        {
            consulta.CommandText = "CREATE TABLE Coche (" +
                "N_Bastidor     TEXT  PRIMARY KEY," +
                "Marca      TEXT," +
                "Modelo     TEXT," +
                "Motor      TEXT," +
                "CV         INTEGER," +
                "Tipo       TEXT," +
                "Color      TEXT," +
                "Precio     REAL," +
                "Img        BLOB)";
            consulta.ExecuteNonQuery();

            consulta.CommandText = "INSERT INTO Coche VALUES ('324AER57G4ED349GX', 'NISSAN', 'PRIMERA', 'GASOLINA', 100, 'TURISMO', 'PLATA', 1000, NULL)";
            consulta.ExecuteNonQuery();

            consulta.CommandText = "CREATE TABLE Cliente (" +
                "Dni        TEXT  PRIMARY KEY," +
                "Nombre     TEXT," +
                "Apellidos      TEXT," +
                "Telefono       TEXT," +
                "Direccion      TEXT)";
            consulta.ExecuteNonQuery();

            consulta.CommandText = "INSERT INTO Cliente VALUES ('05983762J', 'Juan Carlos', 'Expósito Romero', '722256261', 'Poro 3, Torrecampo, Córdoba')";
            consulta.ExecuteNonQuery();

            consulta.CommandText = "CREATE TABLE Revision (" +
                "N_Revision     INTEGER DEFAULT 1 PRIMARY KEY," +
                "Fecha      TEXT," +
                "Frenos     TEXT," +
                "Aceite     TEXT," +
                "Filtro     TEXT," +
                "N_Bastidor     TEXT  REFERENCES Coche(N_Bastidor) " +
                    "ON DELETE CASCADE ON UPDATE CASCADE)";
            consulta.ExecuteNonQuery();

            consulta.CommandText = "INSERT INTO Revision VALUES (1, '08/01/2018', 'Sí', 'No', 'Sí', '324AER57G4ED349GX')";
            consulta.ExecuteNonQuery();

            consulta.CommandText = "CREATE TABLE Venta (" +
                "N_Bastidor     TEXT  REFERENCES Coche(N_Bastidor) " +
                    "ON DELETE CASCADE ON UPDATE CASCADE," +
                "Dni        TEXT  REFERENCES Cliente(Dni) " +
                    "ON DELETE CASCADE ON UPDATE CASCADE," +
                "Fecha      TEXT," +
                "Precio     REAL," +
                "PRIMARY KEY(N_Bastidor,Dni))";
            consulta.ExecuteNonQuery();

            consulta.CommandText = "INSERT INTO Venta VALUES ('324AER57G4ED349GX', '05983762J', '08/01/2018', 1000)";
            consulta.ExecuteNonQuery();

            Console.WriteLine("Base de datos creada");
        }

        public void reiniciarBBDD()
        {
            consulta.CommandText = "DROP Table Venta";
            consulta.ExecuteNonQuery();
            consulta.CommandText = "DROP Table Revision";
            consulta.ExecuteNonQuery();
            consulta.CommandText = "DROP Table Cliente";
            consulta.ExecuteNonQuery();
            consulta.CommandText = "DROP Table Coche";
            consulta.ExecuteNonQuery();
            crearBBDD();
        }

        public void cerrarBBDD()
        {
            sqlite_con.Close();
        }
    }
}
