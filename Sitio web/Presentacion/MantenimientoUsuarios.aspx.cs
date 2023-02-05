using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Drawing;

using EntidadesCompartidas;
using Logica;

public partial class MantenimientoUsuarios : System.Web.UI.Page
{
    private void HabilitarControlesC(bool pHabDes = false)
    {
        btnAgregarUsuario.Enabled = !pHabDes;
        btnEliminarUsuario.Enabled = pHabDes;
        btnModificarUsuario.Enabled = pHabDes;
        txtNombreUsuario.Enabled = pHabDes;
        txtNombreCompleto.Enabled = !pHabDes;
        txtCedula.Enabled = !pHabDes;
        txtCedula.Focus();
    }
    
    private void HabilitarControlesR(bool pHabDes = false)
    {
        //btnBuscarUsuario.Enabled = pHabDes;
        btnEliminarUsuario.Enabled = pHabDes;
        btnModificarUsuario.Enabled = pHabDes;
        btnAgregarUsuario.Enabled = pHabDes;
        txtNombreUsuario.Enabled = !pHabDes;
        txtNombreUsuario.Focus();
        txtNombreCompleto.Enabled = pHabDes;
        txtCedula.Enabled = pHabDes;
    }

    private void HabilitarControlesUD(bool pHabDes = false)
    {
        btnAgregarUsuario.Enabled = pHabDes;
        btnEliminarUsuario.Enabled = !pHabDes;
        btnModificarUsuario.Enabled = !pHabDes;
        txtNombreUsuario.Enabled = pHabDes;
        txtNombreCompleto.Enabled = !pHabDes;
        txtCedula.Enabled = !pHabDes;
        txtCedula.Focus();
    }

    private void LimpiarFormulario()
    {
        txtNombreUsuario.Text = "";
        txtCedula.Text = "";
        txtCedula.Focus();
        txtNombreCompleto.Text = "";
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
    
    protected void btnBuscarUsuario_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtNombreUsuario.Text == "")
            {
                throw new Exception("El nombre de usuario debe contener algo para poder buscar");
            }

            Usuario oUsuario = LogicaUsuario.BuscarUsuario(txtNombreUsuario.Text.Trim());

            if (oUsuario != null)
            {
                txtCedula.Text = oUsuario.Cedula.ToString();
                txtNombreCompleto.Text = oUsuario.NombreCompleto;

                HabilitarControlesUD();
                
                Session["Usuario"] = oUsuario;
            }
            else
            {
                HabilitarControlesC();
                lblError.ForeColor = Color.Green;
                lblError.Text = "No existe un usuario registrado con el nombre de usuario: " + txtNombreUsuario.Text;
            }
        }
        catch (Exception ex)
        {
            lblError.ForeColor = Color.Red;
            lblError.Text = ex.Message;
        }
    }

    protected void btnModificarUsuario_Click(object sender, EventArgs e)
    {
        try
        {
            Usuario oUsuario = (Usuario)Session["Usuario"];

            oUsuario.Cedula = Convert.ToInt32(txtCedula.Text.Trim());
            oUsuario.NombreCompleto = txtNombreCompleto.Text.Trim();

            LogicaUsuario.ModificarUsuario(oUsuario);

            lblError.ForeColor = Color.Green;
            lblError.Text = "Usuario modificado exitosamente";

            LimpiarFormulario();
        }
        catch (Exception ex)
        {
            lblError.ForeColor = Color.Red;
            lblError.Text = ex.Message;
        }
    }
    
    protected void btnEliminarUsuario_Click(object sender, EventArgs e)
    {
        try
        {
            Usuario oUsuario = (Usuario)Session["Usuario"];

            LogicaUsuario.EliminarUsuario(oUsuario);

            lblError.ForeColor = Color.Green;
            lblError.Text = "Usuario eliminado exitosamente";

            LimpiarFormulario();
        }
        catch (Exception ex)
        {
            lblError.ForeColor = Color.Red;
            lblError.Text = ex.Message;
        }
    }
    
    protected void btnAgregarUsuario_Click(object sender, EventArgs e)
    {
        try
        {
            string nombreUsuario = txtNombreUsuario.Text.Trim();
            int cedula = Convert.ToInt32(txtCedula.Text.Trim());
            string nombreCompleto = txtNombreCompleto.Text.Trim();

            Usuario oUsuario = new Usuario(cedula,nombreCompleto,nombreUsuario);

            LogicaUsuario.AltaUsuario(oUsuario);

            lblError.ForeColor = Color.Green;
            lblError.Text = "Usuario agregado correctamente";

            LimpiarFormulario();
        }
        catch (Exception ex)
        {
            lblError.ForeColor = Color.Red;
            lblError.Text = ex.Message;
        }
    }
}