<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AgregarMensajePrivado.aspx.cs" Inherits="AgregarMensajePrivado" %>

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
            text-align: left;
            width: auto;
        }
        .style5
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
                    AGREGAR MENSAJE PRIVADO</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td class="style1">
                    <table style="width:100%;">
                        <tr>
                            <td>
                                Asunto</td>
                            <td>
                                <asp:TextBox ID="txtAsunto" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="lblErrorTXTAsunto" runat="server"></asp:Label>
                            </td>
                            <td class="style5">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                Texto</td>
                            <td>
                                <asp:TextBox ID="txtTexto" runat="server" Width="350px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="lblErrorTXTTexto" runat="server"></asp:Label>
                            </td>
                            <td class="style5">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                Usuario que envia</td>
                            <td>
                                <asp:DropDownList ID="ddlUsuarioEmisor" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Label ID="lblErrorDDLUsuarioEmisor" runat="server"></asp:Label>
                            </td>
                            <td class="style5">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                Usuario que recibe</td>
                            <td>
                                <asp:DropDownList ID="ddlUsuarioReceptor" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Label ID="lblErrorDDLUsuarioReceptor" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Button ID="btnAgregarMensaje" runat="server" Text="Enviar mensaje" 
                                    onclick="btnAgregarMensaje_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td class="style5">
                                &nbsp;</td>
                            <td class="style5">
                                &nbsp;</td>
                            <td class="style5">
                                &nbsp;</td>
                            <td class="style5">
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
