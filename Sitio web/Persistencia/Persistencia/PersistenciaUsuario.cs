using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

using EntidadesCompartidas;

namespace Persistencia
{
    public class PersistenciaUsuario
    {
        public static void AltaUsuario(Usuario pUsuario)
        {
            SqlConnection oConexion = new SqlConnection(InternoPersistencia.STRCONEXION);
            SqlCommand oComando = new SqlCommand("AltaUsuario ", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@cedula", pUsuario.Cedula);
            oComando.Parameters.AddWithValue("@nombreCompleto", pUsuario.NombreCompleto);
            oComando.Parameters.AddWithValue("@nombreUsuario", pUsuario.NombreUsuario);

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int resultado = Convert.ToInt32(oComando.Parameters["@Retorno"].Value);

                if (resultado == -1)
                {
                    throw new Exception("Ya existe " + pUsuario.NombreUsuario + " registrado, el nombre de usuario no puede estar repetido.");
                }
                else if (resultado == -2)
                {
                    throw new Exception("Ocurrio un error inesperado.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                oConexion.Close();
            }
        }

        public static void ModificarUsuario(Usuario pUsuario)
        {
            SqlConnection oConexion = new SqlConnection(InternoPersistencia.STRCONEXION);
            SqlCommand oComando = new SqlCommand("ModificarUsuario ", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@cedula", pUsuario.Cedula);
            oComando.Parameters.AddWithValue("@nombreCompleto", pUsuario.NombreCompleto);
            oComando.Parameters.AddWithValue("@nombreUsuario", pUsuario.NombreUsuario);

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int resultado = Convert.ToInt32(oComando.Parameters["@Retorno"].Value);

                if (resultado == -1)
                {
                    throw new Exception("El usuario " + pUsuario.NombreUsuario + " no esta registrado, no se modifica.");
                }
                else if (resultado == -2)
                {
                    throw new Exception("Ocurrio un error inesperado.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                oConexion.Close();
            }
        }

        public static void EliminarUsuario(Usuario pUsuario)
        {
            SqlConnection oConexion = new SqlConnection(InternoPersistencia.STRCONEXION);
            SqlCommand oComando = new SqlCommand("EliminarUsuario ", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@nombreUsuario", pUsuario.NombreUsuario);

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int resultado = Convert.ToInt32(oComando.Parameters["@Retorno"].Value);

                if (resultado == -1)
                {
                    throw new Exception("El usuario " + pUsuario.NombreUsuario + " no esta registrado, no se elimina.");
                }
                else if (resultado == -2)
                {
                    throw new Exception("El usuario " + pUsuario.NombreUsuario + " tiene mensajes asociados, no se elimina.");
                }
                else if (resultado == -3)
                {
                    throw new Exception("Ocurrio un error inesperado.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                oConexion.Close();
            }
        }

        public static Usuario BuscarUsuario(string pNombreUsuario)
        {
            int cedula;
            string nombreCompleto;
            string nombreUsuario;

            Usuario oUsuario = null;
            SqlDataReader oLector;

            SqlConnection oConexion = new SqlConnection(InternoPersistencia.STRCONEXION);
            SqlCommand oComando = new SqlCommand("BuscarUsuario ", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@nombreUsuario", pNombreUsuario);
            try
            {
                oConexion.Open();
                oLector = oComando.ExecuteReader();

                if (oLector.HasRows)
                {
                    if (oLector.Read())
                    {
                        cedula = Convert.ToInt32(oLector["cedula"]);
                        nombreCompleto = oLector["nombreCompleto"].ToString();
                        nombreUsuario = oLector["NombreUsuario"].ToString();

                        oUsuario = new Usuario(cedula, nombreCompleto, nombreUsuario);
                    }
                }
                
                oLector.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                oConexion.Close();
            }

            return oUsuario;
        }

        public static List<Usuario> ListadoUsuarios()
        {
            int cedula;
            string nombreCompleto;
            string nombreUsuario;

            List<Usuario> auxiliar = new List<Usuario>();

            SqlDataReader oLector;
            SqlConnection oConexion = new SqlConnection(InternoPersistencia.STRCONEXION);
            SqlCommand oComando = new SqlCommand("ListadoUsuarios", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            try
            {
                oConexion.Open();
                oLector = oComando.ExecuteReader();

                if (oLector.HasRows)
                {
                    while (oLector.Read())
                    {
                        cedula = Convert.ToInt32(oLector["cedula"]);
                        nombreCompleto = oLector["nombreCompleto"].ToString();
                        nombreUsuario = oLector["nombreUsuario"].ToString();

                        Usuario oUsuario = new Usuario(cedula, nombreCompleto, nombreUsuario);
                        auxiliar.Add(oUsuario);
                    }
                }

                oLector.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                oConexion.Close();
            }

            return auxiliar;
        }
    }
}
