using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaUsuario
    {
        public static void AltaUsuario(Usuario pUsuario)
        {
            PersistenciaUsuario.AltaUsuario(pUsuario);
        }
        public static void ModificarUsuario(Usuario pUsuario)
        {
            PersistenciaUsuario.ModificarUsuario(pUsuario);
        }
        public static void EliminarUsuario(Usuario pUsuario)
        {
            PersistenciaUsuario.EliminarUsuario(pUsuario);
        }
        public static Usuario BuscarUsuario(String pNombreUsuario)
        {
            Usuario oUsuario = PersistenciaUsuario.BuscarUsuario(pNombreUsuario);

            return oUsuario;
        }
        public static List<Usuario> ListadoUsuarios()
        {
            return PersistenciaUsuario.ListadoUsuarios();
        }
    }
}
