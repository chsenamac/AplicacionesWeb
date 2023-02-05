<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            text-align: center;
            width: 492px;
        }
        .style2
        {
            width: 110px;
            height: 110px;
        }
        .style3
        {
            width: 55px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table style="width:100%;">
            <tr>
                <td class="style3">
                    <img alt="Logotipo Servicio Mensajeria" class="style2" 
                        src="recursos/img/iconoMensaje.png" /></td>
                <td class="style1">
                    PÁGINA PRINCIPAL</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td class="style1">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td class="style1">
                    <asp:LinkButton ID="lnkBtnMantenimientoUsuarios" runat="server" 
                        PostBackUrl="~/MantenimientoUsuarios.aspx">Mantenimiento de usuarios</asp:LinkButton>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td class="style1">
                    <asp:LinkButton ID="lnkBtnMantenimientoTipoMensajes" runat="server" 
                        PostBackUrl="~/MantenimientoTiposMensajes.aspx">Mantenimiento de tipos de mensaje</asp:LinkButton>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td class="style1">
                    <asp:LinkButton ID="lnkBtnAgregarMensajePrivado" runat="server" 
                        PostBackUrl="~/AgregarMensajePrivado.aspx">Agregar mensaje privado</asp:LinkButton>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td class="style1">
                    <asp:LinkButton ID="lnkBtnAgregarMensajeComu" runat="server" 
                        PostBackUrl="~/AgregarMensajeComun.aspx">Agregar mensaje común</asp:LinkButton>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td class="style1">
                    <asp:LinkButton ID="lnkBtnListadoMensajesComunesDeUnUsuario" runat="server" 
                        PostBackUrl="~/ListadoMensajesComunesDeUnUsuario.aspx">Listado de mensajes comunes de un usuario</asp:LinkButton>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td class="style1">
                    <asp:LinkButton ID="lnkBtnListadoMensajesPrivadosDeUnUsuario" runat="server" 
                        PostBackUrl="~/ListadoMensajesPrivadosDeUnUsuario.aspx">Listado de mensajes privados de un usuario</asp:LinkButton>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td class="style1">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
