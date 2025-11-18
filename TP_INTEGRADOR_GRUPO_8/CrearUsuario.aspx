<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CrearUsuario.aspx.cs" Inherits="TP_INTEGRADOR_GRUPO_8.Resgistrarse" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Crear Usuario Médico</title>

    <!-- Fuente e ícono -->
    <link href="https://fonts.googleapis.com/css2?family=Inter:wght@400;600;700&display=swap" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="~/styles.css" runat="server" />

    <style>
        body {
            font-family: 'Inter', sans-serif;
            background: linear-gradient(135deg, #e8f0fe, #f9fafc);
            margin: 0;
            padding: 0;
            display: flex;
            justify-content: center;
            align-items: center;
            min-height: 100vh;
        }

        .register-card {
            background-color: #ffffff;
            width: 460px;
            padding: 40px;
            border-radius: 14px;
            box-shadow: 0 8px 25px rgba(0, 0, 0, 0.08);
            animation: fadeIn 0.6s ease;
        }

        @keyframes fadeIn {
            from { opacity: 0; transform: translateY(-10px); }
            to { opacity: 1; transform: translateY(0); }
        }

        h1 {
            text-align: center;
            color: #0d6efd;
            font-size: 1.7em;
            margin-bottom: 10px;
        }

        h2 {
            text-align: center;
            color: #6c757d;
            font-size: 1em;
            margin-bottom: 30px;
        }

        label {
            display: block;
            font-weight: 600;
            color: #333;
            margin-bottom: 6px;
            margin-top: 10px;
        }

        .text-control {
            width: 100%;
            padding: 10px 12px;
            border: 1px solid #d0d7de;
            border-radius: 8px;
            font-size: 0.95em;
            transition: all 0.3s ease;
        }

        .text-control:focus {
            border-color: #0d6efd;
            box-shadow: 0 0 0 3px rgba(13, 110, 253, 0.25);
            outline: none;
        }

        .btn-primary {
            background-color: #0d6efd;
            color: white;
            border: none;
            padding: 12px 0;
            width: 100%;
            border-radius: 8px;
            font-weight: 700;
            margin-top: 25px;
            cursor: pointer;
            transition: background-color 0.3s ease, transform 0.1s;
        }

        .btn-primary:hover {
            background-color: #0a58ca;
            transform: scale(1.02);
        }

        .footer-link {
            display: block;
            text-align: center;
            margin-top: 20px;
            text-decoration: none;
            color: #6c757d;
            font-size: 0.9em;
            transition: color 0.3s;
        }

        .footer-link:hover {
            color: #0d6efd;
        }

        .logged-user {
            text-align: center;
            font-weight: 600;
            color: #495057;
            margin-bottom: 25px;
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">
        <div class="register-card">
            <h1>🏥 Clínica Médica</h1>
            <h2>Registro de Nuevo Usuario Médico</h2>

            <div class="logged-user">
                Usuario Logueado:
                <asp:Label ID="lblNombre0" runat="server" />
            </div>

            <label for="<%= txbNombre.ClientID %>">Nombre:</label>
            <asp:TextBox ID="txbNombre" runat="server" CssClass="text-control" />

            <label for="<%= txbNombre.ClientID %>">
            <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txbNombre" ForeColor="#3366CC" style="font-weight: 700">Se necesita completar este campo.</asp:RequiredFieldValidator>
            </label>

            <label for="<%= txbApellido.ClientID %>">Apellido:</label>
            <asp:TextBox ID="txbApellido" runat="server" CssClass="text-control" />

            <asp:RequiredFieldValidator ID="rfvApellido" runat="server" ControlToValidate="txbApellido" ForeColor="#3366CC" style="font-weight: 700">Se necesita completar este campo.</asp:RequiredFieldValidator>

            <label for="<%= txtUsuario.ClientID %>">Nombre de Usuario:</label>
            <asp:TextBox ID="txtUsuario" runat="server" CssClass="text-control" />

            <asp:RequiredFieldValidator ID="rfvNombreUsuario" runat="server" ControlToValidate="txtUsuario" ForeColor="#3366CC" style="font-weight: 700">Se necesita completar este campo.</asp:RequiredFieldValidator>

            <label for="<%= txtContrasenia.ClientID %>">Contraseña:</label>
            <asp:TextBox ID="txtContrasenia" runat="server" TextMode="Password" CssClass="text-control" />

            <asp:RequiredFieldValidator ID="rfvContrasenia" runat="server" ControlToValidate="txtContrasenia" ForeColor="#3366CC" style="font-weight: 700">Se necesita completar este campo.</asp:RequiredFieldValidator>

            <label for="<%= txtRepetirContrasenia.ClientID %>">Repetir Contraseña:</label>
            <asp:TextBox ID="txtRepetirContrasenia" runat="server" TextMode="Password" CssClass="text-control" />

            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtRepetirContrasenia" ForeColor="#3366CC" style="font-weight: 700">Se necesita completar este campo.</asp:RequiredFieldValidator>

            <asp:Button ID="btnRegistrar" runat="server" Text="Registrar Usuario" CssClass="btn-primary" />

            <a href="~/MenuAdminstrador.aspx" class="footer-link" runat="server">← Volver al Panel de Administración</a>
        </div>
    </form>
</body>
</html>
