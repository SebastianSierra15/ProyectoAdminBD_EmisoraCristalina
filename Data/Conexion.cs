using MySql.Data.MySqlClient;
using System.Data;
using System.Reflection;
using System.Runtime.Intrinsics.X86;

namespace RadioDemo.Data
{

    public class Conexion
    {
        protected MySqlConnection connection;

        protected void Conectar()
        {
            try
            {
                connection = new MySqlConnection("Server=localhost;Port=3306;Database=emisora_cristalina;Uid=root;Pwd=root");
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
