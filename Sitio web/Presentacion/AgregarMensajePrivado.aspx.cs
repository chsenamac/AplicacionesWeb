using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Drawing;

using EntidadesCompartidas;
using Logica;

public partial class AgregarMensajePrivado : System.Web.UI.Page
{
    private void CargarDatosDDLYSession()
    {
        List<Usuario> colListadoUsuarios = LogicaUsuario.ListadoUsuarios();

        if (colListadoUsuarios.Count == 0)
        {
            lblErrorDDLUsuarioEmisor.ForeColor = Color.Red;
            lblErrorDDLUsuarioEmisor.Text = "No hay usuarios registrados";

            lblErrorDDLUsuarioReceptor.ForeColor = Color.Red;
            lblErrorDDLUsuarioReceptor.Text = "No hay usuarios registrados";
        }
        else
        {
            ddlUsuarioEmisor.DataSource = colListadoUsuarios;
            ddlUsuarioEmisor.DataTextField = "DDLMostrarUsuarios";
            ddlUsuarioEmisor.DataValueField = "nombreUsuario";
            ddlUsuarioEmisor.DataBind();
            ddlUsuarioEmisor.Items.Insert(0, "- Seleccione una opcion");

            ddlUsuarioReceptor.DataSource = colListadoUsuarios;
            ddlUsuarioReceptor.DataTextField = "DDLMostrarUsuarios";
            ddlUsuarioReceptor.DataValueField = "nombreUsuario";
            ddlUsuarioReceptor.DataBind();
            ddlUsuarioReceptor.Items.Insert(0, "- Seleccione una opcion");

            Session["Usuarios"] = colListadoUsuarios;
        }
    }

    private void LimpiarControles()
    {
        txtAsunto.Text = "";
        txtTexto.Text = "";
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

    protected void btnAgregarMensaje_Click(object sender, EventArgs e)
    {
        try
        {
            Usuario oUsuarioEmisor = null;
            Usuario oUsuarioReceptor = null;
            DateTime fechaHoraGenerado = DateTime.Now;
            DateTime fechaCaducidad = DateTime.Now.AddDays(2);
            string asunto;
            string texto;

            List<Usuario> colUsuarios = (List<Usuario>)Session["Usuarios"];

            if (ddlUsuarioEmisor.SelectedIndex != 0)
            {
                foreach (Usuario oUsEmi in colUsuarios)
                {
                    if (oUsEmi.NombreUsuario == ddlUsuarioEmisor.SelectedValue)
                    {
                        oUsuarioEmisor = oUsEmi;
                        break;
                    }
                }
            }

            if (ddlUsuarioReceptor.SelectedIndex != 0)
            {
                foreach (Usuario oUsRec in colUsuarios)
                {
                    if (oUsRec.NombreUsuario == ddlUsuarioReceptor.SelectedValue)
                    {
                        oUsuarioReceptor = oUsRec;
                        break;
                    }
                }
            }

            if (oUsuarioEmisor == null)
            {
                throw new Exception("Debe seleccionar un usuario emisor de la lista");
            }

            if (oUsuarioReceptor == null)
            {
                throw new Exception("Debe seleccionar un usuario receptor de la lista");
            }

            asunto = txtAsunto.Text.Trim();
            texto = txtTexto.Text.Trim();

            MensajePrivado oMensajePrivado = new MensajePrivado(fechaCaducidad, 0, fechaHoraGenerado, asunto, texto, oUsuarioEmisor, oUsuarioReceptor);

            LogicaMensaje.AltaMensaje(oMensajePrivado);

            lblError.ForeColor = Color.Green;
            lblError.Text = "Mensaje enviado correctamente";

        }
        catch (Exception ex)
        {
            lblError.ForeColor = Color.Red;
            lblError.Text = ex.Message;
        }
    }
}