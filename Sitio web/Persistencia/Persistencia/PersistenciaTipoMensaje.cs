using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

using EntidadesCompartidas;

namespace Persistencia
{
    public class PersistenciaTipoMensaje
    {
        public static void AltaTipoMensaje(TipoMensaje pTipoMensaje)
        {
            SqlConnection oConexion = new SqlConnection(InternoPersistencia.STRCONEXION);
            SqlCommand oComando = new SqlCommand("AltaTipoMensaje ", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@codigoInterno", pTipoMensaje.CodigoInterno);
            oComando.Parameters.AddWithValue("@nombre", pTipoMensaje.Nombre);

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
                    throw new Exception("Ya existe " + pTipoMensaje.CodigoInterno + " registrado, el codigo de tipo de mensaje no puede estar repetido.");
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

        public static void ModificarTipoMensaje(TipoMensaje pTipoMensaje)
        {
            SqlConnection oConexion = new SqlConnection(InternoPersistencia.STRCONEXION);
            SqlCommand oComando = new SqlCommand("ModificarTipoMensaje ", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@codigoInterno", pTipoMensaje.CodigoInterno);
            oComando.Parameters.AddWithValue("@nombre", pTipoMensaje.Nombre);

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
                    throw new Exception("El tipo de mensaje " + pTipoMensaje.CodigoInterno + " no esta registrado, no se modifica.");
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

        public static void EliminarTipoMensaje(TipoMensaje pTipoMensaje)
        {
            SqlConnection oConexion = new SqlConnection(InternoPersistencia.STRCONEXION);
            SqlCommand oComando = new SqlCommand("EliminarTipoMensaje ", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@codigoInterno", pTipoMensaje.CodigoInterno);

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
                    throw new Exception("El codigo de tipo de mensaje " + pTipoMensaje.CodigoInterno + " no esta registrado, no se elimina.");
                }
                else if (resultado == -2)
                {
                    throw new Exception("El tipo de mensaje " + pTipoMensaje.CodigoInterno + " tiene mensajes asociados, no se elimina.");
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

        public static TipoMensaje BuscarTipoMensaje(string pCodigoInterno)
        {
            string codigoInterno;
            string nombre;

            TipoMensaje oTipoMensaje = null;
            SqlDataReader oLector;

            SqlConnection oConexion = new SqlConnection(InternoPersistencia.STRCONEXION);
            SqlCommand oComando = new SqlCommand("BuscarTipoMensaje ", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@codigoInterno", pCodigoInterno);
            try
            {
                oConexion.Open();
                oLector = oComando.ExecuteReader();

                if (oLector.HasRows)
                {
                    if (oLector.Read())
                    {
                        codigoInterno = oLector["CodigoInterno"].ToString();
                        nombre = oLector["Nombre"].ToString();

                        oTipoMensaje = new TipoMensaje(codigoInterno, nombre);
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

            return oTipoMensaje;
        }

        public static List<TipoMensaje> ListadoTipoMensajes()
        {
            string codigoInterno;
            string nombre;

            List<TipoMensaje> auxiliar = new List<TipoMensaje>();

            SqlDataReader oLector;
            SqlConnection oConexion = new SqlConnection(InternoPersistencia.STRCONEXION);
            SqlCommand oComando = new SqlCommand("ListadoTipoMensajes", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            try
            {
                oConexion.Open();
                oLector = oComando.ExecuteReader();

                if (oLector.HasRows)
                {
                    while (oLector.Read())
                    {
                        codigoInterno = oLector["codigoInterno"].ToString();
                        nombre = oLector["nombre"].ToString();

                        TipoMensaje oTipoMensaje = new TipoMensaje(codigoInterno, nombre);
                        auxiliar.Add(oTipoMensaje);
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
