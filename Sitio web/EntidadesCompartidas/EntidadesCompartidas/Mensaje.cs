using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Mensaje
    {
        private int numeroInterno;
        private DateTime fechaHoraGenerado;
        private string asunto;
        private string texto;
        private Usuario usuarioEnvia;
        private Usuario usuarioRecibe;

        public Mensaje(int numeroInterno, DateTime fechaHoraGenerado, string asunto, string texto, Usuario usuarioEnvia, Usuario usuarioRecibe)
        {
            NumeroInterno = numeroInterno;
            FechaHoraGenerado = fechaHoraGenerado;
            Asunto = asunto;
            Texto = texto;
            UsuarioEnvia = usuarioEnvia;
            UsuarioRecibe = usuarioRecibe;
        }

        public int NumeroInterno
        {
            get { return this.numeroInterno; }
            set { numeroInterno = value; }
        }

        public DateTime FechaHoraGenerado
        {
            get { return fechaHoraGenerado; }
            set 
            {
                if (fechaHoraGenerado.Date >= DateTime.Now.Date)
                {
                    throw new Exception("La fecha de generado el mensaje no puede ser posterior a la fecha actual");
                }
                
                fechaHoraGenerado = value; 
            }
        }

        public string Asunto
        {
            get { return asunto; }
            set
            {
                if (value.Trim() == "")
                {
                    throw new Exception("El asunto no puede quedar vacío.");
                }
                else if (value.Trim().Length > 50)
                {
                    throw new Exception("El asunto no puede exceder los 50 caractéres.");
                }

                asunto = value;
            }
        }

        public string Texto
        {
            get { return texto; }
            set
            {
                if (value.Trim() == "")
                {
                    throw new Exception("El cuerpo del mensaje no puede quedar vacío.");
                }
                else if (value.Trim().Length > 200)
                {
                    throw new Exception("El texto del cuerpo del mensaje no puede exceder los 200 caractéres.");
                }

                texto = value;
            }
        }

        public Usuario UsuarioEnvia
        {
            get { return this.usuarioEnvia; }
            set
            {
                if (value == null)
                {
                    throw new Exception("El usuario que envia no puede estar vacio");
                }
                
                usuarioEnvia = value;
            }
        }

        public Usuario UsuarioRecibe
        {
            get { return this.usuarioRecibe; }
            set
            {
                if (value == null)
                {
                    throw new Exception("El usuario que recibe no puede estar vacio");
                }
                
                usuarioRecibe = value;
            }
        }

        public override string ToString()
        {
            return "Numero interno: " + this.numeroInterno
                + "\nFecha y hora de generado: " + this.fechaHoraGenerado
                + "\nAsunto: " + this.asunto + "\nTexto: " + this.texto
                + "\nUsuario que envia: " + this.usuarioEnvia.ToString()
                + "\nUsuario que recibe: " + this.usuarioRecibe.ToString() + "\n";
        }
    }
}
