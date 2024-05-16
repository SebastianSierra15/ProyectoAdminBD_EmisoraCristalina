using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System.Data;
using System.Runtime.Intrinsics.X86;
using System.Transactions;
using ProyectoAdmin_EmisoraCristalina.Models;

namespace ProyectoAdmin_EmisoraCristalina.Data
{
    public class Procedimientos : Conexion
    {
        MySqlCommand? cmd;
        
        public VendedorModel ValidarVendedor(string username, string contrasenia)
        {
            VendedorModel vendedor = new VendedorModel();
            Conectar();

            try
            {
                cmd = new MySqlCommand("ValidarVendedor", connection);
                cmd.Parameters.AddWithValue("username", username);
                cmd.Parameters.AddWithValue("contrasenia", contrasenia);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    vendedor.Id = Convert.ToInt32(dr[0] + "");
                    vendedor.Username = dr[1] + "";
                    vendedor.Contrasenia = dr[2] + "";
                    vendedor.Estado = ((dr[3] + "" == "1") ? true : false);
                    vendedor.Persona = new PersonaModel()
                    {
                        Documento = Convert.ToInt32(dr[4] + ""),
                        Nombre1 = dr[5] + "",
                        Nombre2 = dr[6] + "",
                        Apellido1 = dr[7] + "",
                        Apellido2 = dr[8] + "",
                        FechaNacimiento = dr[9] + "",
                        Correo = dr[10] + "",
                        Id_TipoDocumento = Convert.ToInt32(dr[11] + ""),
                        Id_Genero = Convert.ToInt32(dr[12] + "")
                    };
                    vendedor.Rol = new RolModel()
                    {
                        Id = Convert.ToInt32(dr[13] + ""),
                        Nombre = dr[14] + "",
                        Estado = ((dr[15] + "" == "1") ? true : false)
                    };
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                Desconectar();
            }

            return vendedor;
        }
    
        public List<ProgramaModel> RecopilarProgramas()
        {
            List<ProgramaModel> programas = new List<ProgramaModel>();
            Conectar();

            try
            {
                cmd = new MySqlCommand("RecopilarProgramas", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    programas.Add(new ProgramaModel()
                    {
                        Id = Convert.ToInt32(dr[0] + ""),
                        Nombre = dr[1] + "",
                        Estado = ((dr[2] + "" == "1") ? true : false)
                    });
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                Desconectar();
            }

            return programas;
        }

        public void EditarPrograma(string id, string nombre, string estado)
        {
            Conectar();

            try
            {
                cmd = new MySqlCommand("EditarPrograma", connection);
                cmd.Parameters.AddWithValue("id", id);
                cmd.Parameters.AddWithValue("nombre", nombre);
                cmd.Parameters.AddWithValue("estado", estado);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                MySqlDataReader dr = cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                Desconectar();
            }

            return;
        }

        public void AgregarPrograma(string nombre)
        {
            Conectar();

            try
            {
                cmd = new MySqlCommand("AgregarPrograma", connection);
                cmd.Parameters.AddWithValue("nombre", nombre);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                MySqlDataReader dr = cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                Desconectar();
            }

            return;
        }

    }
}
