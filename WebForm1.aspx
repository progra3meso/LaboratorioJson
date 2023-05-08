<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="LaboratorioJson.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
    <br />
    Eliminar Universidad</h1>
<p>
    Universidad a Buscar
    <asp:TextBox ID="TextBoxUniversidad" runat="server"></asp:TextBox>
    <asp:Button ID="ButtonBuscar" runat="server" OnClick="ButtonBuscar_Click" Text="Buscar" />
</p>
<p>
    <asp:Label ID="LabelUniversidad" runat="server"></asp:Label>
    <asp:Button ID="ButtonEliminar" runat="server" Enabled="False" OnClick="ButtonEliminar_Click" Text="Eliminar" />
</p>
<p>
</p>
</asp:Content>
