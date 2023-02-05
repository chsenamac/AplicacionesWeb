<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListadoMensajesPrivadosDeUnUsuario.aspx.cs" Inherits="ListadoMensajesPrivadosDeUnUsuario" %>

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
            width: 158px;
            text-align: left;
        }
        .style6
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
                    LISTADOS DE MENSAJES PRIVADOS DE UN USUARIO</td>
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
                                Fecha Actual</td>
                            <td class="style6">
                                <asp:Label ID="lblFechaActual" runat="server"></asp:Label>
                            </td>
                            <td class="style6">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style4">
                                Usuario</td>
                            <td class="style6">
                                <asp:DropDownList ID="ddlUsuario" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td class="style6">
                                <asp:Label ID="lblErrorDDLUsuarios" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style4">
                                &nbsp;</td>
                            <td class="style6">
                                <asp:RadioButton ID="rdBtnEnviados" runat="server" Text="Enviados" 
                                    AutoPostBack="True" GroupName="EnviaRecibe" />
                                <asp:RadioButton ID="rdBtnRecibidos" runat="server" Text="Recibidos" 
                                    AutoPostBack="True" GroupName="EnviaRecibe" />
                            </td>
                            <td class="style6">
                                <asp:Button ID="btnMostrarMensajesListados" runat="server" 
                                    Text="Mostrar mensajes" onclick="btnMostrarMensajesListados_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td class="style4">
                                &nbsp;</td>
                            <td class="style6">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style4">
                                &nbsp;</td>
                            <td class="style6">
                                <asp:GridView ID="gvListadoMensajesComunes" runat="server">
                                </asp:GridView>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style4">
                                &nbsp;</td>
                            <td class="style6">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
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
