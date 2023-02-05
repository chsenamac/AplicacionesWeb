<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MantenimientoTiposMensajes.aspx.cs" Inherits="MantenimientoTiposMensajes" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style3
        {
            width: 55px;
        }
        .style2
        {
            width: 110px;
            height: 110px;
        }
        .style1
        {
            text-align: center;
            width: 492px;
        }
        .style4
        {
            text-align: left;
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
                    MANTENIMIENTO DE TIPOS DE MENSAJES</td>
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
                    <table style="width:100%;">
                        <tr>
                            <td class="style4">
                                Codigo</td>
                            <td class="style4">
                                <asp:TextBox ID="txtCodigoInterno" runat="server" Width="200px"></asp:TextBox>
                            </td>
                            <td class="style4">
                                <asp:Button ID="btnBuscarTipoMensaje" runat="server" Text="Buscar" 
                                    Width="120px" onclick="btnBuscarTipoMensaje_Click"/>
                            </td>
                        </tr>
                        <tr>
                            <td class="style4">
                                Nombre</td>
                            <td class="style4">
                                <asp:TextBox ID="txtNombreTipoMensaje" runat="server" Width="200px"></asp:TextBox>
                            </td>
                            <td class="style4">
                                <asp:Button ID="btnModificarTipoMensaje" runat="server" Text="Modificar" 
                                    Width="120px" onclick="btnModificarTipoMensaje_Click"/>
                            </td>
                        </tr>
                        <tr>
                            <td class="style4">
                                &nbsp;</td>
                            <td class="style4">
                                &nbsp;</td>
                            <td class="style4">
                                <asp:Button ID="btnEliminarTipoMensaje" runat="server" Text="Eliminar" 
                                    Width="120px" onclick="btnEliminarTipoMensaje_Click"/>
                            </td>
                        </tr>
                        <tr>
                            <td class="style4">
                                &nbsp;</td>
                            <td class="style4">
                                &nbsp;</td>
                            <td class="style4">
                                <asp:Button ID="btnAgregarTipoMensaje" runat="server" Text="Agregar " 
                                    Width="120px" onclick="btnAgregarTipoMensaje_Click"/>
                            </td>
                        </tr>
                    </table>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td class="style1">
                    <asp:Label ID="lblError" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:LinkButton ID="lnkBtnVolverADefault" runat="server" 
                        PostBackUrl="~/Default.aspx">Volver</asp:LinkButton>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
