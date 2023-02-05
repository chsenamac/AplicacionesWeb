using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Usuario
    {
        private int cedula;
        private string nombreCompleto;
        private string nombreUsuario;

        public Usuario(int cedula, string nombreCompleto, string nombreUsuario)
        {
            Cedula = cedula;
            NombreCompleto = nombreCompleto;
            NombreUsuario = nombreUsuario;
        }

        public int Cedula
        {
            get { return this.cedula; }
            set { cedula = value; }
        }

        public string NombreCompleto
        {
            get { return nombreCompleto; }
            set
            {
                if (value.Length > 50)
                {
                    throw new Exception("El nombre de completo no puede superar los 50 caracteres");
                }

                nombreCompleto = value;
            }
        }

        public string NombreUsuario
        {
            get { return nombreUsuario; }
            set
            {
                if (value == "")
                {
                    throw new Exception("El nombre de usuario no puede estar vacio");
                }
                else if (value.Length > 20)
                {
                    throw new Exception("El nombre de completo no puede superar los 20 caracteres");
                }
                nombreUsuario = value;
            }
        }

        public virtual string DDLMostrarUsuarios
        {
            get { return nombreUsuario + " - " + nombreCompleto; }
        }

        public override string ToString()
        {
            return "Cedula: " + this.cedula + " - Nombre usuario: "
                + this.nombreUsuario + " - Nombre completo: " + this.nombreCompleto;
        }
    }
}
