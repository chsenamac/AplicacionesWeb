using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class MensajeComun : Mensaje
    {
        private TipoMensaje tipoMensaje;

        public MensajeComun(TipoMensaje tipoMensaje, int numeroInterno, DateTime fechaHoraGenerado, string asunto, string texto, Usuario usuarioEnvia, Usuario usuarioRecibe)
            : base(numeroInterno, fechaHoraGenerado, asunto, texto, usuarioEnvia, usuarioRecibe)
        {
            TipoDeMensaje = tipoMensaje;
        }

        public TipoMensaje TipoDeMensaje
        {
            get { return tipoMensaje; }
            set
            {
                if (value == null)
                {
                    throw new Exception("El tipo de mensaje no puede estar vacio");
                }
                
                tipoMensaje = value;
            }
        }

        public override string ToString()
        {
            return " Tipo de mensaje: " + this.tipoMensaje + " - " + base.ToString();
        }
    }
}
