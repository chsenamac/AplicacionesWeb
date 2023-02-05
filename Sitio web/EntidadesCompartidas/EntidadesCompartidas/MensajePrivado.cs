using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class MensajePrivado : Mensaje
    {
        private DateTime fechaCaducidad;

        public MensajePrivado(DateTime fechaCaducidad, int numeroInterno, DateTime fechaHoraGenerado, string asunto, string texto, Usuario usuarioEnvia, Usuario usuarioRecibe)
            : base(numeroInterno, fechaHoraGenerado, asunto, texto, usuarioEnvia, usuarioRecibe)
        {
            FechaCaducidad = fechaCaducidad;
        }

        public DateTime FechaCaducidad
        {
            get { return this.fechaCaducidad; }
            set { fechaCaducidad = value; }
        }

        public override string ToString()
        {
            return base.ToString() + " - Fecha de caducidad: " + this.fechaCaducidad;
        }

    }
}
