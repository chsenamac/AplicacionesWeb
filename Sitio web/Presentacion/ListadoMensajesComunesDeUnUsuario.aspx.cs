using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Drawing;

using EntidadesCompartidas;
using Logica;

public partial class ListadoMensajesComunesDeUnUsuario : System.Web.UI.Page
{
    private void CargarDatosDDLYSession()
    {
        List<Usuario> colListadoUsuarios = LogicaUsuario.ListadoUsuarios();
        List<TipoMensaje> colListadoTipoMensajes = LogicaTipoMensaje.ListadoTipoMensajes();

        if (colListadoUsuarios.Count == 0)
        {
            lblErrorDDLUsuarios.ForeColor = Color.Red;
            lblErrorDDLUsuarios.Text = "No hay usuarios registrados";
        }
        else
        {
            ddlUsuario.DataSource = colListadoUsuarios;
            ddlUsuario.DataTextField = "DDLMostrarUsuarios";
            ddlUsuario.DataValueField = "nombreUsuario";
            ddlUsuario.DataBind();
            ddlUsuario.Items.Insert(0, "- Seleccione una opcion");

            Session["Usuarios"] = colListadoUsuarios;
        }

        if (colListadoTipoMensajes.Count == 0)
        {
            lblErrorDDLTipoMensajes.ForeColor = Color.Red;
            lblErrorDDLTipoMensajes.Text = "No hay tipos de mensajes registrados";
        }
        else
        {
            ddlTipoMensaje.DataSource = colListadoTipoMensajes;
            ddlTipoMensaje.DataTextField = "DDLMostrarTipoMensaje";
            ddlTipoMensaje.DataValueField = "codigoInterno";
            ddlTipoMensaje.DataBind();
            ddlTipoMensaje.Items.Insert(0, "- Seleccione una opcion");
            
            Session["TipoMensajes"] = colListadoTipoMensajes;
        }
 
        rdBtnEnviados.Checked = true;
    }

    private void LimpiarControles()
    {
        gvListadoMensajesComunes.DataSource = null;
        gvListadoMensajesComunes.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            lblError.Text = "";

            if (!IsPostBack)
            {
                CargarDatosDDLYSession();
            }
        }
        catch (Exception ex)
        {
            lblError.ForeColor = Color.Red;
            lblError.Text = ex.Message;
        }
    }
    
    protected void btnMostrarMensajesListados_Click(object sender, EventArgs e)
    {
        try
        {
            TipoMensaje oTipoMensaje = null;
            Usuario oUsuario = null;
            bool enviaRecibe = true;
            
            List<Usuario> colUsuarios = (List<Usuario>)Session["Usuarios"];
            if (ddlUsuario.SelectedIndex != 0)
            {
                foreach (Usuario oUs in colUsuarios)
                {
                    if (oUs.NombreUsuario == ddlUsuario.SelectedValue)
                    {
                        oUsuario = oUs;
                    }
                }
            }

            List<TipoMensaje> colTipoMensajes = (List<TipoMensaje>)Session["TipoMensajes"];

            if (ddlTipoMensaje.SelectedIndex != 0)
            {
                foreach (TipoMensaje oTM in colTipoMensajes)
                {
                    if (oTM.CodigoInterno == ddlTipoMensaje.SelectedValue)
                    {
                        oTipoMensaje = oTM;
                    }
                }
            }

            if (rdBtnEnviados.Checked)
            {
                enviaRecibe = false;
            }

            if (rdBtnRecibidos.Checked)
            {
                enviaRecibe = true;
            }

            if (oTipoMensaje == null)
            {
                LimpiarControles();
                throw new Exception("Debe seleccionar un tipo de mensaje de la lista");
            }

            if (oUsuario == null)
            {
                LimpiarControles();
                throw new Exception("Debe seleccionar un usuario de la lista");
            }

            List<MensajeComun> colAuxiliar = LogicaMensaje.ListadoMensajeComunUsuario(oUsuario, oTipoMensaje, enviaRecibe);
            
            if (colAuxiliar.Count != 0)
            {
                gvListadoMensajesComunes.DataSource = colAuxiliar;
                gvListadoMensajesComunes.DataBind();
            }
            else
            {
                LimpiarControles();
                lblError.ForeColor = Color.Green;
                lblError.Text = "No se encontraron mensajes comunes que coincidan con los criterios de busqueda.";
            }
        }
        catch (Exception ex)
        {
            lblError.ForeColor = Color.Red;
            lblError.Text = ex.Message;
        }
    }
}