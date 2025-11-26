<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PanelMedico.aspx.cs" Inherits="TP_INTEGRADOR_GRUPO_8.PanelMedico" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>Panel del Médico</title>
<style>
    .panel-container {
width: 422px;
margin: 40px auto;
padding: 20px;
border-radius: 12px;
background: #f5f5f5;
box-shadow: 0 0 10px rgba(0,0,0,0.2);
text-align: center;
font-family: Arial;
        height: 180px;
    }
.btn {
padding: 10px 20px;
border: none;
background: #007bff;
color: white;
font-size: 18px;
cursor: pointer;
border-radius: 8px;
transition: 0.2s;
}
.btn:hover {
background: #0056b3;
}
</style>
</head>
<body>
<form id="form1" runat="server">
<div class="panel-container">
<h2>Panel del Médico</h2>
<p>Bienvenido doctor, seleccione una opción:</p>
<asp:Button ID="btnTurnos" runat="server" Text="Visualizar Turnos" CssClass="btn" PostBackUrl="~/VisualizarTurnosMedico.aspx" />
    <br />
    <br />
    <asp:LinkButton ID="lnkCerrarSesion" runat="server" PostBackUrl="~/Inicio.aspx">Cerrar Sesion</asp:LinkButton>
</div>
</form>
</body>
</html>