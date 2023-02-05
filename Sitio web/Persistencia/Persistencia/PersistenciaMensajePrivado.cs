using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

using EntidadesCompartidas;

namespace Persistencia
{
    public class PersistenciaMensajePrivado
    {
        public static void AgregarMensajePrivado(MensajePrivado pPrivado)
        {
            SqlConnection oConexion = new SqlConnection(InternoPersistencia.STRCONEXION);
            SqlCommand oComando = new SqlCommand("AgregarMensajePrivado ", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@asunto", pPrivado.Asunto);
            oComando.Parameters.AddWithValue("@texto", pPrivado.Texto);
            oComando.Parameters.AddWithValue("@usuarioEmisor", pPrivado.UsuarioEnvia.NombreUsuario);
            oComando.Parameters.AddWithValue("@usuarioReceptor", pPrivado.UsuarioRecibe.NombreUsuario);
            oComando.Parameters.AddWithValue("@fechaCaducidad", pPrivado.FechaCaducidad);

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
                    throw new Exception("La fecha de caducidad no puede ser anterior a la fecha actual.");
                }
                else if (resultado == -2)
                {
                    throw new Exception("No existe el usuario que emite el mensaje.");
                }
                else if (resultado == -3)
                {
                    throw new Exception("No existe el usuario que recibe el mensaje.");
                }
                else if (resultado == -4)
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
        public static List<MensajePrivado> ListadoMensajePrivadoUsuario(Usuario pUsuario, bool pEnviaRecibe)
        {
            List<MensajePrivado> colMensajePrivadoUsuario = new List<MensajePrivado>();

            SqlConnection oConexion = new SqlConnection(InternoPersistencia.STRCONEXION);
            SqlCommand oComando = new SqlCommand("ListadoMensajePrivadoUsuario ", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@nombreUsuario", pUsuario.NombreUsuario);
            oComando.Parameters.AddWithValue("@enviaRecibe", pEnviaRecibe);

            try
            {
                oConexion.Open();
                SqlDataReader oLector = oComando.ExecuteReader();

                if (oLector.HasRows)
                {
                    while (oLector.Read())
                    {
                        DateTime fechaCaducidad = Convert.ToDateTime(oLector["fechaCaducidad"]);
                        int numeroInterno = Convert.ToInt32(oLector["numeroInterno"]);
                        DateTime fechaGenerado = Convert.ToDateTime(oLector["fechaGenerado"]);
                        string asunto = oLector["asunto"].ToString();
                        string texto = oLector["texto"].ToString();
                        Usuario usuarioEnvia = pUsuario;
                        Usuario usuarioRecibe = pUsuario;

                        if (pEnviaRecibe == false)
                        {
                            usuarioEnvia = PersistenciaUsuario.BuscarUsuario(oLector["usuarioEmisor"].ToString());
                        }
                        else
                        {
                            usuarioRecibe = PersistenciaUsuario.BuscarUsuario(oLector["usuarioReceptor"].ToString());
                        }
                        
                        MensajePrivado oMensajePrivado = new MensajePrivado(fechaCaducidad, numeroInterno,
                                                fechaGenerado, asunto, texto, usuarioEnvia, usuarioRecibe);
                        colMensajePrivadoUsuario.Add(oMensajePrivado);
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
            return colMensajePrivadoUsuario;
        }
    }
}
