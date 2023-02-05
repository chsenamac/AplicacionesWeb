using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

using EntidadesCompartidas;

namespace Persistencia
{
    public class PersistenciaMensajeComun
    {
        public static void AgregarMensajeComun(MensajeComun pMensajeComun)
        {
            SqlConnection oConexion = new SqlConnection(InternoPersistencia.STRCONEXION);
            SqlCommand oComando = new SqlCommand("AgregarMensajeComun ", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@asunto", pMensajeComun.Asunto);
            oComando.Parameters.AddWithValue("@texto", pMensajeComun.Texto);
            oComando.Parameters.AddWithValue("@usuarioEmisor", pMensajeComun.UsuarioEnvia.NombreUsuario);
            oComando.Parameters.AddWithValue("@usuarioReceptor", pMensajeComun.UsuarioRecibe.NombreUsuario);
            oComando.Parameters.AddWithValue("@codigoInternoMensaje", pMensajeComun.TipoDeMensaje.CodigoInterno);

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
                    throw new Exception("No existe el usuario que emite el mensaje.");
                }
                else if (resultado == -2)
                {
                    throw new Exception("No existe el usuario que recibe el mensaje.");
                }
                else if (resultado == -3)
                {
                    throw new Exception("No existe el tipo de mensaje.");
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
        
        public static List<MensajeComun> ListadoMensajeComunUsuario(Usuario pUsuario, TipoMensaje pTipoMensaje, bool pEnviaRecibe)
        {
            List<MensajeComun> colMensajeComunUsuario = new List<MensajeComun>();

            SqlConnection oConexion = new SqlConnection(InternoPersistencia.STRCONEXION);
            SqlCommand oComando = new SqlCommand("ListadoMensajeComunUsuario ", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@nombreUsuario", pUsuario.NombreUsuario);
            oComando.Parameters.AddWithValue("@codigoInternoTM", pTipoMensaje.CodigoInterno);
            oComando.Parameters.AddWithValue("@enviaRecibe", pEnviaRecibe);

            try
            {
                oConexion.Open();
                SqlDataReader oLector = oComando.ExecuteReader();

                if (oLector.HasRows)
                {
                    while (oLector.Read())
                    {
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

                        MensajeComun oMensajeComun = new MensajeComun(pTipoMensaje, numeroInterno, fechaGenerado, asunto, texto, usuarioEnvia, usuarioRecibe);
                        colMensajeComunUsuario.Add(oMensajeComun);
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
            return colMensajeComunUsuario;
        }
    }
}
