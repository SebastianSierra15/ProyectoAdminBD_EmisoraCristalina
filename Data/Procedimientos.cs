using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System.Data;
using System.Runtime.Intrinsics.X86;
using System.Transactions;
using RadioDemo.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics.Contracts;

namespace RadioDemo.Data
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
                        Estado = ((dr[15] + "" == "1") ? true : false),
                        Permisos = BuscarPermisos(dr[13] + "")
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

        public List<PermisoModel> BuscarPermisos(string id)
        {
            List<PermisoModel> permisos = new List<PermisoModel>();
            Conectar();

            try
            {
                cmd = new MySqlCommand("BuscarPermisos", connection);
                cmd.Parameters.AddWithValue("id", id);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    permisos.Add(new PermisoModel()
                    {
                        Id = Convert.ToInt32(dr[0] + ""),
                        Nombre = dr[1] + ""
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

            return permisos;
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

        public List<RolModel> RecopilarRoles()
        {
            List<RolModel> roles = new List<RolModel>();
            Conectar();

            try
            {
                cmd = new MySqlCommand("RecopilarRoles", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    roles.Add(new RolModel()
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

            return roles;
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

        public List<VendedorModel> RecopilarVendedores()
        {
            List<VendedorModel> vendedores = new List<VendedorModel>();
            Conectar();

            try
            {
                cmd = new MySqlCommand("RecopilarVendedores", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    vendedores.Add(new VendedorModel()
                    {
                        Id = Convert.ToInt32(dr[0] + ""),
                        Username = dr[1] + "",
                        Contrasenia = dr[2] + "",
                        Estado = ((dr[3] + "" == "1") ? true : false),
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
                        },
                        Rol = new RolModel()
                        {
                            Id = Convert.ToInt32(dr[17] + ""),
                            Nombre = dr[18] + "",
                            Estado = ((dr[19] + "" == "1") ? true : false)
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

            return vendedores;
        }

        public List<CuniaModel> RecopilarCunias(string idContrato)
        {
            List<CuniaModel> cunias = new List<CuniaModel>();
            Conectar();

            try
            {
                cmd = new MySqlCommand("RecopilarCunias", connection);
                cmd.Parameters.AddWithValue("idContrato", idContrato);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    cunias.Add(new CuniaModel()
                    {
                        Id = Convert.ToInt32(dr[0] + ""),
                        Nombre = dr[1] + "",
                        Descripcion = dr[2] + "",
                        Estado = ((dr[3] + "" == "1") ? true : false),
                        Tarifa = new TarifaModel()
                        {
                            Id = Convert.ToInt32(dr[4] + ""),
                            ValorPublicado = Convert.ToInt32(dr[5] + ""),
                            ValorEspecial = Convert.ToInt32(dr[6] + ""),
                            RangoInicial = Convert.ToInt32(dr[7] + ""),
                            RangoFinal = Convert.ToInt32(dr[8] + ""),
                            Programa = new ProgramaModel()
                            {
                                Id = Convert.ToInt32(dr[9] + ""),
                                Nombre = dr[10] + "",
                                Estado = ((dr[11] + "" == "1") ? true : false)
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

            return cunias;
        }

        public List<ContratoModel> RecopilarContratos()
        {
            List<ContratoModel> contratos = new List<ContratoModel>();
            Conectar();

            try
            {
                cmd = new MySqlCommand("RecopilarContratos", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    contratos.Add(new ContratoModel()
                    {
                        Id = Convert.ToInt32(dr[0] + ""),
                        Nombre = dr[1] + "",
                        FechaInicio = dr[2].ToString().Substring(0, 10),
                        FechaFin = dr[3].ToString().Substring(0, 10),
                        FechaCreacion = dr[4] + "",
                        Valor = Convert.ToInt32(dr[5] + ""),
                        NumeroCunias = Convert.ToInt32(dr[6] + ""),
                        Pdf = dr[7] + "",
                        DocumentoVendedor = Convert.ToInt32(dr[8] + ""),
                        NombreVendedor = dr[9] + "",
                        DocumentoAnunciante = Convert.ToInt32(dr[10] + ""),
                        NombreAnunciante = dr[11] + "",
                        Cunias = RecopilarCunias(dr[0] + "")
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

            return contratos;
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

        public VendedorModel BuscarVendedor(string id)
        {
            VendedorModel vendedor = new VendedorModel();
            Conectar();

            try
            {
                cmd = new MySqlCommand("BuscarVendedor", connection);
                cmd.Parameters.AddWithValue("id", id);
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
                    vendedor.Rol = new RolModel()
                    {
                        Id = Convert.ToInt32(dr[17] + ""),
                        Nombre = dr[18] + "",
                        Estado = ((dr[19] + "" == "1") ? true : false)
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

        public TarifaModel BuscarTarifa(string id)
        {
            TarifaModel tarifa = new TarifaModel();
            Conectar();

            try
            {
                cmd = new MySqlCommand("BuscarTarifa", connection);
                cmd.Parameters.AddWithValue("id", id);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    tarifa.Id = Convert.ToInt32(dr[0] + "");
                    tarifa.ValorPublicado = Convert.ToInt32(dr[1] + "");
                    tarifa.ValorEspecial = Convert.ToInt32(dr[2] + "");
                    tarifa.RangoInicial = Convert.ToInt32(dr[3] + "");
                    tarifa.RangoFinal = Convert.ToInt32(dr[4] + "");
                    tarifa.Programa = new ProgramaModel()
                    {
                        Id = Convert.ToInt32(dr[5] + ""),
                        Nombre = dr[6] + "",
                        Estado = ((dr[7] + "" == "1") ? true : false)
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

            return tarifa;
        }

        public ContratoModel BuscarContrato(string id)
        {
            ContratoModel contrato = new ContratoModel();
            Conectar();

            try
            {
                cmd = new MySqlCommand("BuscarContrato", connection);
                cmd.Parameters.AddWithValue("id", id);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    contrato.Id = Convert.ToInt32(dr[0] + "");
                    contrato.Nombre = dr[1] + "";
                    contrato.FechaInicio = dr[2].ToString().Substring(0, 10);
                    contrato.FechaFin = dr[3].ToString().Substring(0, 10);
                    contrato.FechaCreacion = dr[4] + "";
                    contrato.Valor = Convert.ToInt32(dr[5] + "");
                    contrato.NumeroCunias = Convert.ToInt32(dr[6] + "");
                    contrato.Pdf = dr[7] + "";
                    contrato.DocumentoVendedor = Convert.ToInt32(dr[8] + "");
                    contrato.NombreVendedor = dr[9] + "";
                    contrato.DocumentoAnunciante = Convert.ToInt32(dr[10] + "");
                    contrato.NombreAnunciante = dr[11] + "";
                    contrato.Cunias = RecopilarCunias(dr[0] + "");
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

            return contrato;
        }

        public int ContarContratosActivos()
        {
            int total = 0;
            Conectar();

            try
            {
                cmd = new MySqlCommand("SELECT COUNT(*) FROM contrato WHERE FECHAFIN_CONTRATO >= CURDATE()", connection);
                total = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Desconectar();
            }

            return total;
        }

        public int ContarAnunciantes()
        {
            int total = 0;
            Conectar();

            try
            {
                cmd = new MySqlCommand("SELECT COUNT(*) FROM anunciante", connection);
                total = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Desconectar();
            }

            return total;
        }

        public int ContarVendedores()
        {
            int total = 0;
            Conectar();

            try
            {
                cmd = new MySqlCommand("SELECT COUNT(*) FROM vendedor", connection);
                total = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Desconectar();
            }

            return total;
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

        public void AgregarVendedor(string username, string rol, string tipoDocumento, string documento, string nombre1, string nombre2, string apellido1, string apellido2, string fecha, string correo, string genero)
        {
            Conectar();

            try
            {
                cmd = new MySqlCommand("AgregarVendedor", connection);
                cmd.Parameters.AddWithValue("username", username);
                cmd.Parameters.AddWithValue("idRol", rol);
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

        public string AgregarContrato(string nombre, string fechaInicio, string fechaFin, string anunciante, string valor, string vendedor, int numCunias)
        {
            string id = "";
            Conectar();

            try
            {
                cmd = new MySqlCommand("AgregarContrato", connection);
                cmd.Parameters.AddWithValue("nombre", nombre);
                cmd.Parameters.AddWithValue("fechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("fechaFin", fechaFin);
                cmd.Parameters.AddWithValue("valor", valor);
                cmd.Parameters.AddWithValue("idvendedor", vendedor);
                cmd.Parameters.AddWithValue("idanunciante", anunciante);
                cmd.Parameters.AddWithValue("numCunias", numCunias);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    id = dr[0] + "";
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

            return id;
        }

        public void AgregarCunia(string nombre, string descripcion, string tarifa, string id)
        {
            Conectar();

            try
            {
                cmd = new MySqlCommand("AgregarCunia", connection);
                cmd.Parameters.AddWithValue("nombre", nombre);
                cmd.Parameters.AddWithValue("descripcion", descripcion);
                cmd.Parameters.AddWithValue("idtarifa", tarifa);
                cmd.Parameters.AddWithValue("idcontrato", id);
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

        public void EditarVendedor(string id, string username, string estado, string rol, string nombre1, string nombre2, string apellido1, string apellido2, string correo)
        {
            Conectar();

            try
            {
                cmd = new MySqlCommand("EditarVendedor", connection);
                cmd.Parameters.AddWithValue("id", id);
                cmd.Parameters.AddWithValue("username", username);
                cmd.Parameters.AddWithValue("estado", estado);
                cmd.Parameters.AddWithValue("idRol", rol);
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

        public void EditarPerfil(string id, string username, string nombre1, string nombre2, string apellido1, string apellido2, string correo, string contrasenia)
        {
            Conectar();

            try
            {
                cmd = new MySqlCommand("EditarPerfil", connection);
                cmd.Parameters.AddWithValue("id", id);
                cmd.Parameters.AddWithValue("username", username);
                cmd.Parameters.AddWithValue("nombre1", nombre1);
                cmd.Parameters.AddWithValue("nombre2", nombre2);
                cmd.Parameters.AddWithValue("apellido1", apellido1);
                cmd.Parameters.AddWithValue("apellido2", apellido2);
                cmd.Parameters.AddWithValue("correo", correo);
                cmd.Parameters.AddWithValue("contrasenia", contrasenia);
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

        public void GuardarPdf(string id, string pdf)
        {
            Conectar();

            try
            {
                cmd = new MySqlCommand("GuardarPdf", connection);
                cmd.Parameters.AddWithValue("id", id);
                cmd.Parameters.AddWithValue("pdf", pdf);
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
