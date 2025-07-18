using MySql.Data.MySqlClient;

namespace RadioDemo.Data
{

    public class Conexion
    {
        protected MySqlConnection connection;

        protected void Conectar()
        {
            try
            {
                connection = new MySqlConnection("Server=localhost;Port=3306;Database=radio_demo;Uid=root;Pwd=root");
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
