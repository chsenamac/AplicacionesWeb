using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Drawing;

using EntidadesCompartidas;
using Logica;

public partial class MantenimientoTiposMensajes : System.Web.UI.Page
{
    private void HabilitarControlesC(bool pHabDes = false)
    {
        btnAgregarTipoMensaje.Enabled = !pHabDes;
        btnEliminarTipoMensaje.Enabled = pHabDes;
        btnModificarTipoMensaje.Enabled = pHabDes;
        
        txtCodigoInterno.Enabled = pHabDes;
        txtNombreTipoMensaje.Enabled = !pHabDes;
        txtNombreTipoMensaje.Focus();
    }

    private void HabilitarControlesR(bool pHabDes = false)
    {
        btnEliminarTipoMensaje.Enabled = pHabDes;
        btnModificarTipoMensaje.Enabled = pHabDes;
        btnAgregarTipoMensaje.Enabled = pHabDes;
        txtNombreTipoMensaje.Enabled = pHabDes;
        txtCodigoInterno.Enabled = !pHabDes;
        txtCodigoInterno.Focus();
    }

    private void HabilitarControlesUD(bool pHabDes = false)
    {
        btnAgregarTipoMensaje.Enabled = pHabDes;
        btnEliminarTipoMensaje.Enabled = !pHabDes;
        btnModificarTipoMensaje.Enabled = !pHabDes;

        txtCodigoInterno.Enabled = pHabDes;
        txtNombreTipoMensaje.Enabled = !pHabDes;
        txtNombreTipoMensaje.Focus();
    }

    private void LimpiarFormulario()
    {
        txtNombreTipoMensaje.Text = "";
        txtCodigoInterno.Text = "";
        txtCodigoInterno.Focus();
        HabilitarControlesR();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        lblError.Text = "";

        if (!IsPostBack)
        {
            LimpiarFormulario();
        }
    }

    protected void btnBuscarTipoMensaje_Click(object sender, EventArgs e)
    {
        try
        {
            string codAux = txtCodigoInterno.Text.Trim();

            if (codAux == "")
            {
                throw new Exception("El codigo debe contener algo para poder buscar");
            }

            TipoMensaje oTipoMensaje = LogicaTipoMensaje.BuscarTipoMensaje(codAux);

            if (oTipoMensaje != null)
            {
                txtCodigoInterno.Text = oTipoMensaje.CodigoInterno.ToString();
                txtNombreTipoMensaje.Text = oTipoMensaje.Nombre;

                HabilitarControlesUD();

                Session["TipoMensaje"] = oTipoMensaje;
            }
            else
            {
                HabilitarControlesC();
                lblError.ForeColor = Color.Green;
                lblError.Text = "No existe un tipo de registrado con el codigo: " + txtCodigoInterno.Text.Trim();
            }
        }
        catch (Exception ex)
        {
            lblError.ForeColor = Color.Red;
            lblError.Text = ex.Message;
        }
    }
    
    protected void btnModificarTipoMensaje_Click(object sender, EventArgs e)
    {
        try
        {
            TipoMensaje oTipoMensaje = (TipoMensaje)Session["TipoMensaje"];

            oTipoMensaje.Nombre = txtNombreTipoMensaje.Text.Trim();

            LogicaTipoMensaje.ModificarTipoMensaje(oTipoMensaje);

            lblError.ForeColor = Color.Green;
            lblError.Text = "Tipo de mensaje modificado exitosamente";

            LimpiarFormulario();
        }
        catch (Exception ex)
        {
            lblError.ForeColor = Color.Red;
            lblError.Text = ex.Message;
        }
    }
    
    protected void btnEliminarTipoMensaje_Click(object sender, EventArgs e)
    {
        try
        {
            TipoMensaje oTipoMensaje = (TipoMensaje)Session["TipoMensaje"];

            LogicaTipoMensaje.EliminarTipoMensaje(oTipoMensaje);

            lblError.ForeColor = Color.Green;
            lblError.Text = "Tipo de mensaje eliminado exitosamente";

            LimpiarFormulario();
        }
        catch (Exception ex)
        {
            lblError.ForeColor = Color.Red;
            lblError.Text = ex.Message;
        }
    }
    
    protected void btnAgregarTipoMensaje_Click(object sender, EventArgs e)
    {
        try
        {
            string codigoInterno = txtCodigoInterno.Text.Trim();
            string nombre = txtNombreTipoMensaje.Text.Trim();

            TipoMensaje oTipoMensaje = new TipoMensaje(codigoInterno, nombre);

            LogicaTipoMensaje.AltaTipoMensaje(oTipoMensaje);

            lblError.ForeColor = Color.Green;
            lblError.Text = "Tipo de mensaje agregado correctamente";

            LimpiarFormulario();
        }
        catch (Exception ex)
        {
            lblError.ForeColor = Color.Red;
            lblError.Text = ex.Message;
        }
    }
}