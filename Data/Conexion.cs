using MySql.Data.MySqlClient;
using System.Data;

namespace ProyectoAdmin_EmisoraCristalina.Data
{

    public class Conexion
    {
        protected MySqlConnection? connection;

        protected void Conectar()
        {
            try
            {
                connection = new MySqlConnection("Server=localhost;Port=3306;Database=Emisora_Cristalina;Uid=root;Pwd=2002");
                connection.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        protected void Desconectar()
        {
            try
            {
                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
