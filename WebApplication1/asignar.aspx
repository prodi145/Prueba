<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="asignar.aspx.cs" Inherits="WebApplication1.asignar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Asignar Marca a Componente"></asp:Label>
        <br />
        <br />
        Selecciona Componente:
        <asp:DropDownList ID="DropDownList1" runat="server">
        </asp:DropDownList>
        <br />
        <br />
        Selecciona Marca:
        <asp:DropDownList ID="DropDownList2" runat="server">
        </asp:DropDownList>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Asignar" />
&nbsp;
        <asp:Button ID="Button2" runat="server" Text="Ver Datos" />
&nbsp;
        <asp:Button ID="Button3" runat="server" Text="Editar" />
&nbsp;
        <asp:Button ID="Button4" runat="server" Text="Eliminar" />
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
    </form>
</body>
</html>
