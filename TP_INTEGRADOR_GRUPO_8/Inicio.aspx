<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="TP_INTEGRADOR_GRUPO_8.WebForm1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="utf-8" />
<title>🔐 Iniciar Sesión - Clínica Médica</title>

<link href="https://fonts.googleapis.com/css2?family=Inter:wght@400;600;700&display=swap" rel="stylesheet" />
<link rel="stylesheet" type="text/css" href="~/styles.css" runat="server" />

<style>
    body {
        font-family: 'Inter', sans-serif;
        background: linear-gradient(135deg, #e9eff5, #f7f9fb);
        display: flex;
        justify-content: center;
        align-items: center;
        height: 100vh;
        margin: 0;
    }

    .login-card {
        background-color: #ffffff;
        width: 400px;
        border-radius: 16px;
        box-shadow: 0 6px 20px rgba(0, 0, 0, 0.08);
        padding: 40px 35px;
        text-align: center;
        animation: fadeIn 0.6s ease-in-out;
    }

    @keyframes fadeIn {
        from { opacity: 0; transform: translateY(-10px); }
        to { opacity: 1; transform: translateY(0); }
    }

    h1 {
        color: #0d6efd;
        margin-bottom: 8px;
        font-size: 1.8em;
    }

    h2 {
        color: #5f6c7b;
        font-size: 1em;
        margin-bottom: 30px;
    }

    .input-group {
        text-align: left;
        margin-bottom: 20px;
    }

    label {
        display: block;
        font-weight: 600;
        color: #2d3e50;
        margin-bottom: 6px;
    }

    .text-control {
        width: 100%;
        padding: 10px 12px;
        border: 1px solid #ccd4dd;
        border-radius: 8px;
        font-size: 1em;
        transition: border-color 0.3s, box-shadow 0.3s;
        box-sizing: border-box;
    }

    .text-control:focus {
        border-color: #0d6efd;
        box-shadow: 0 0 5px rgba(13, 110, 253, 0.25);
        outline: none;
    }

    .btn-action-primary {
        width: 100%;
        background-color: #0d6efd;
        color: white;
        border: none;
        border-radius: 8px;
        padding: 12px 0;
        font-weight: 600;
        cursor: pointer;
        transition: background-color 0.3s, transform 0.1s;
        text-transform: uppercase;
        letter-spacing: 0.5px;
        margin-top: 10px;
    }

    .btn-action-primary:hover {
        background-color: #0a58ca;
        transform: scale(1.02);
    }

    .footer-text {
        margin-top: 25px;
        font-size: 0.9em;
        color: #6c757d;
    }

    .footer-text a {
        color: #0d6efd;
        text-decoration: none;
        font-weight: 600;
    }

    .footer-text a:hover {
        text-decoration: underline;
    }
</style>
</head>

<body>
    <form id="form1" runat="server">
        <div class="login-card">
            <h1>🏥 CLÍNICA MÉDICA</h1>
            <h2>Inicio de Sesión</h2>

            <div class="input-group">
                <label for="<%= tbNombreDeUsuario.ClientID %>">Nombre de usuario</label>
                <asp:TextBox ID="tbNombreDeUsuario" runat="server" CssClass="text-control"></asp:TextBox>
            </div>

            <div class="input-group">
                <label for="<%= tbContraseniaDeUsuario.ClientID %>">Contraseña</label>
                <asp:TextBox ID="tbContraseniaDeUsuario" runat="server" CssClass="text-control" TextMode="Password"></asp:TextBox>
                <asp:Label ID="lblMensaje" runat="server"></asp:Label>
            </div>

            <asp:Button ID="btnIniciarSesion" runat="server" Text="Iniciar Sesión" CssClass="btn-action-primary" OnClick="btnIniciarSesion_Click" />

            
        </div>
    </form>
</body>
</html>

