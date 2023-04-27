<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LaboratorioJson._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Ingreso de notas</h1>
        <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
        <p class="lead">Nombre del alumno
            <asp:TextBox ID="TextBoxAlumno" runat="server"></asp:TextBox>
        </p>
        <p class="lead">Curso
            <asp:TextBox ID="TextBoxCurso" runat="server"></asp:TextBox>
&nbsp; Nota
            <asp:TextBox ID="TextBoxNota" runat="server"></asp:TextBox>
&nbsp;<asp:Button ID="ButtonNota" runat="server" Text="Ingresar Nota" class ="btn-warning btn-md" OnClick="ButtonNota_Click" />
        </p>
        <p><asp:Button ID="ButtonMostrar" runat="server" Text="Mostrar" class ="btn-primary btn-lg" OnClick="ButtonIngresar_Click" />
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
        </p>
    </div>

</asp:Content>
