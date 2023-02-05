using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaMensaje
    {
        public static void AltaMensaje(Mensaje pMensaje)
        {
            if (pMensaje is MensajeComun)
            {
                PersistenciaMensajeComun.AgregarMensajeComun((MensajeComun)pMensaje);
            }
            else
            {
                if (((MensajePrivado)pMensaje).FechaCaducidad.Date <= DateTime.Now.Date)
                {
                    throw new Exception("La fecha de caducidad debe ser mayor o igual a la actual.");
                }

                PersistenciaMensajePrivado.AgregarMensajePrivado((MensajePrivado)pMensaje);
            }
        }

        public static List<MensajeComun> ListadoMensajeComunUsuario(Usuario pUsuario, TipoMensaje pTipoMensaje, bool pEnviaRecibe)
        {
            return PersistenciaMensajeComun.ListadoMensajeComunUsuario(pUsuario, pTipoMensaje, pEnviaRecibe);
        }

        public static List<MensajePrivado> ListadoMensajePrivadoUsuario(Usuario pUsuario, bool pEnviaRecibe)
        {
            return PersistenciaMensajePrivado.ListadoMensajePrivadoUsuario(pUsuario, pEnviaRecibe);
        }
    }
}
