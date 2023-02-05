using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Text.RegularExpressions;

namespace EntidadesCompartidas
{
    public class TipoMensaje
    {
        private string codigoInterno;
        private string nombre;

        public TipoMensaje(string codigoInterno, string nombre)
        {
            CodigoInterno = codigoInterno;
            Nombre = nombre;
        }

        public string CodigoInterno
        {
            get { return codigoInterno; }
            set
            {
                if (value.Trim() == "")
                {
                    throw new Exception("El código interno no puede quedar vacío.");
                }
                else if (!Regex.IsMatch(value, "^[a-zA-Z]{3}$"))
                {
                    throw new Exception("El código interno puede contener solo 3 letras.");
                }

                codigoInterno = value;
            }
        }

        public string Nombre
        {
            get { return this.nombre; }
            set
            {

                if (value.Trim().Length > 20)
                {
                    throw new Exception("El nombre no puede exceder los 20 caracteres");
                }

                nombre = value;
            }
        }

        public virtual string DDLMostrarTipoMensaje
        {
            get { return nombre; }
        }

        public override string ToString()
        {
            return "Codigo interno: " + this.codigoInterno + " - Nombre: " + this.nombre;
        }
    }
}
