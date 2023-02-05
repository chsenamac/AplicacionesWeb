using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaTipoMensaje
    {
        public static void AltaTipoMensaje(TipoMensaje pTipoMensaje)
        {
            PersistenciaTipoMensaje.AltaTipoMensaje(pTipoMensaje);
        }
        public static void ModificarTipoMensaje(TipoMensaje pTipoMensaje)
        {
            PersistenciaTipoMensaje.ModificarTipoMensaje(pTipoMensaje);
        }
        public static void EliminarTipoMensaje(TipoMensaje pTipoMensaje)
        {
            PersistenciaTipoMensaje.EliminarTipoMensaje(pTipoMensaje);
        }
        public static TipoMensaje BuscarTipoMensaje(String pNombreTipoMensaje)
        {
            TipoMensaje oTipoMensaje = PersistenciaTipoMensaje.BuscarTipoMensaje(pNombreTipoMensaje);

            return oTipoMensaje;
        }
        public static List<TipoMensaje> ListadoTipoMensajes()
        {
            return PersistenciaTipoMensaje.ListadoTipoMensajes();
        }
    }
}
