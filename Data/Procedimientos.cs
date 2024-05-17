using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System.Data;
using System.Runtime.Intrinsics.X86;
using System.Transactions;
using ProyectoAdmin_EmisoraCristalina.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        public List<TipoDocumentoModel> RecopilarTipoDocumentos()
        {
            List<TipoDocumentoModel> tipoDocumentos = new List<TipoDocumentoModel>();
            Conectar();

            try
            {
                cmd = new MySqlCommand("RecopilarTipoDocumentos", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    tipoDocumentos.Add(new TipoDocumentoModel()
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

            return tipoDocumentos;
        }

        public List<GeneroModel> RecopilarGeneros()
        {
            List<GeneroModel> generos = new List<GeneroModel>();
            Conectar();

            try
            {
                cmd = new MySqlCommand("RecopilarGeneros", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    generos.Add(new GeneroModel()
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

            return generos;
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

        public List<TarifaModel> RecopilarTarifas()
        {
            List<TarifaModel> tarifas = new List<TarifaModel>();
            Conectar();

            try
            {
                cmd = new MySqlCommand("RecopilarTarifas", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    tarifas.Add(new TarifaModel()
                    {
                        Id = Convert.ToInt32(dr[0] + ""),
                        ValorPublicado = Convert.ToInt32(dr[1] + ""),
                        ValorEspecial = Convert.ToInt32(dr[2] + ""),
                        RangoInicial = Convert.ToInt32(dr[3] + ""),
                        RangoFinal = Convert.ToInt32(dr[4] + ""),
                        Programa = new ProgramaModel()
                        {
                            Id = Convert.ToInt32(dr[5] + ""),
                            Nombre = dr[6] + "",
                            Estado = ((dr[7] + "" == "1") ? true : false)
                        }
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

            return tarifas;
        }

        public void EditarTarifa(string id, string programa, string rangoInicial, string rangoFinal, string valorPublicado, string valorEspecial)
        {
            Conectar();

            try
            {
                cmd = new MySqlCommand("EditarTarifa", connection);
                cmd.Parameters.AddWithValue("id", id);
                cmd.Parameters.AddWithValue("valor1", valorPublicado);
                cmd.Parameters.AddWithValue("valor2", valorEspecial);
                cmd.Parameters.AddWithValue("rango1", rangoInicial);
                cmd.Parameters.AddWithValue("rango2", rangoFinal);
                cmd.Parameters.AddWithValue("idPrograma", programa);
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

        public void AgregarTarifa(string rangoInicial, string rangoFinal, string valorPublicado, string valorEspecial, string programa)
        {
            Conectar();

            try
            {
                cmd = new MySqlCommand("AgregarTarifa", connection);
                cmd.Parameters.AddWithValue("valor1", valorPublicado);
                cmd.Parameters.AddWithValue("valor2", valorEspecial);
                cmd.Parameters.AddWithValue("rango1", rangoInicial);
                cmd.Parameters.AddWithValue("rango2", rangoFinal);
                cmd.Parameters.AddWithValue("idPrograma", programa);
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

        public void EliminarTarifa(string id)
        {
            Conectar();

            try
            {
                cmd = new MySqlCommand("EliminarTarifa", connection);
                cmd.Parameters.AddWithValue("id", id);
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

        public List<AnuncianteModel> RecopilarAnunciantes()
        {
            List<AnuncianteModel> anunciantes = new List<AnuncianteModel>();
            Conectar();

            try
            {
                cmd = new MySqlCommand("RecopilarAnunciantes", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    anunciantes.Add(new AnuncianteModel()
                    {
                        Nit = Convert.ToInt32(dr[0] + ""),
                        Nombre = dr[1] + "",
                        Direccion = dr[2] + "",
                        Telefono = dr[3] + "",
                        Persona = new PersonaModel()
                        {
                            Documento = Convert.ToInt32(dr[4] + ""),
                            Nombre1 = dr[5] + "",
                            Nombre2 = dr[6] + "",
                            Apellido1 = dr[7] + "",
                            Apellido2 = dr[8] + "",
                            FechaNacimiento = dr[9] + "",
                            Correo = dr[10] + "",
                            TipoDocumento = new TipoDocumentoModel()
                            {
                                Id = Convert.ToInt32(dr[11] + ""),
                                Nombre = dr[12] + "",
                                Estado = ((dr[13] + "" == "1") ? true : false)
                            },
                            Genero = new GeneroModel()
                            {
                                Id = Convert.ToInt32(dr[14] + ""),
                                Nombre = dr[15] + "",
                                Estado = ((dr[16] + "" == "1") ? true : false)
                            }
                        }
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

            return anunciantes;
        }

        public AnuncianteModel BuscarAnunciante(string nit)
        {
            AnuncianteModel anunciante = new AnuncianteModel();
            Conectar();

            try
            {
                cmd = new MySqlCommand("BuscarAnunciante", connection);
                cmd.Parameters.AddWithValue("nit", nit);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    anunciante.Nit = Convert.ToInt32(dr[0] + "");
                    anunciante.Nombre = dr[1] + "";
                    anunciante.Direccion = dr[2] + "";
                    anunciante.Telefono = dr[3] + "";
                    anunciante.Persona = new PersonaModel()
                    {
                        Documento = Convert.ToInt32(dr[4] + ""),
                        Nombre1 = dr[5] + "",
                        Nombre2 = dr[6] + "",
                        Apellido1 = dr[7] + "",
                        Apellido2 = dr[8] + "",
                        FechaNacimiento = dr[9] + "",
                        Correo = dr[10] + "",
                        TipoDocumento = new TipoDocumentoModel()
                        {
                            Id = Convert.ToInt32(dr[11] + ""),
                            Nombre = dr[12] + "",
                            Estado = ((dr[13] + "" == "1") ? true : false)
                        },
                        Genero = new GeneroModel()
                        {
                            Id = Convert.ToInt32(dr[14] + ""),
                            Nombre = dr[15] + "",
                            Estado = ((dr[16] + "" == "1") ? true : false)
                        }
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

            return anunciante;
        }

        public void EditarAnunciante(string nit, string nombre, string direccion, string telefono, string nombre1, string nombre2, string apellido1, string apellido2, string correo)
        {
            Conectar();

            try
            {
                cmd = new MySqlCommand("EditarAnunciante", connection);
                cmd.Parameters.AddWithValue("nit", nit);
                cmd.Parameters.AddWithValue("nombre", nombre);
                cmd.Parameters.AddWithValue("direccion", direccion);
                cmd.Parameters.AddWithValue("telefono", telefono);
                cmd.Parameters.AddWithValue("nombre1", nombre1);
                cmd.Parameters.AddWithValue("nombre2", nombre2);
                cmd.Parameters.AddWithValue("apellido1", apellido1);
                cmd.Parameters.AddWithValue("apellido2", apellido2);
                cmd.Parameters.AddWithValue("correo", correo);
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

        public void AgregarAnunciante(string nit, string nombre, string direccion, string telefono, string tipoDocumento, string documento, string nombre1, string nombre2, string apellido1, string apellido2, string fecha, string correo, string genero)
        {
            Conectar();

            try
            {
                cmd = new MySqlCommand("AgregarAnunciante", connection);
                cmd.Parameters.AddWithValue("nit", nit);
                cmd.Parameters.AddWithValue("nombre", nombre);
                cmd.Parameters.AddWithValue("direccion", direccion);
                cmd.Parameters.AddWithValue("telefono", telefono);
                cmd.Parameters.AddWithValue("documento", documento);
                cmd.Parameters.AddWithValue("nombre1", nombre1);
                cmd.Parameters.AddWithValue("nombre2", nombre2);
                cmd.Parameters.AddWithValue("apellido1", apellido1);
                cmd.Parameters.AddWithValue("apellido2", apellido2);
                cmd.Parameters.AddWithValue("fecha", fecha);
                cmd.Parameters.AddWithValue("correo", correo);
                cmd.Parameters.AddWithValue("idTipoDocumento", tipoDocumento);
                cmd.Parameters.AddWithValue("idGenero", genero);
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
