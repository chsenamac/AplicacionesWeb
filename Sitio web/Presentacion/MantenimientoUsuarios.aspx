<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MantenimientoUsuarios.aspx.cs" Inherits="MantenimientoUsuarios" %>

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
            width: auto;
        }
        .style4
        {
            text-align: left;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    
        <table style="width:100%;">
            <tr>
                <td class="style3">
                    <img alt="Logotipo Servicio Mensajeria" class="style2" 
                        src="recursos/img/iconoMensaje.png" /></td>
                <td class="style1">
                    MANTENIMIENTO DE USUARIOS</td>
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
                                Usuario</td>
                            <td class="style4">
                                <asp:TextBox ID="txtNombreUsuario" runat="server" Width="200px"></asp:TextBox>
                            </td>
                            <td class="style4">
                                <asp:Button ID="btnBuscarUsuario" runat="server" Text="Buscar" Width="120px" 
                                    onclick="btnBuscarUsuario_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td class="style4">
                                Cedula</td>
                            <td class="style4">
                                <asp:TextBox ID="txtCedula" runat="server" Width="200px"></asp:TextBox>
                            </td>
                            <td class="style4">
                                <asp:Button ID="btnModificarUsuario" runat="server" Text="Modificar" 
                                    Width="120px" onclick="btnModificarUsuario_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td class="style4">
                                Nombre completo</td>
                            <td class="style4">
                                <asp:TextBox ID="txtNombreCompleto" runat="server" Width="330px"></asp:TextBox>
                            </td>
                            <td class="style4">
                                <asp:Button ID="btnEliminarUsuario" runat="server" Text="Eliminar" 
                                    Width="120px" onclick="btnEliminarUsuario_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td class="style4">
                                &nbsp;</td>
                            <td class="style4">
                                &nbsp;</td>
                            <td class="style4">
                                <asp:Button ID="btnAgregarUsuario" runat="server" Text="Agregar " 
                                    Width="120px" onclick="btnAgregarUsuario_Click" />
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
    
    </form>
</body>
</html>
