<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuAdminstrador.aspx.cs" Inherits="TP_INTEGRADOR_GRUPO_8.UsuarioAdminstrador" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Panel del Administrador - Clínica Médica</title>

    <link href="https://fonts.googleapis.com/css2?family=Inter:wght@400;600;700&display=swap" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="~/styles.css" runat="server" />

    <style>
        body {
            font-family: 'Inter', sans-serif;
            background: linear-gradient(135deg, #e8f0fe, #f7f9fc);
            margin: 0;
            padding: 0;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
        }

        .admin-card {
            background-color: #ffffff;
            width: 500px;
            padding: 40px;
            border-radius: 16px;
            box-shadow: 0 6px 20px rgba(0, 0, 0, 0.08);
            text-align: center;
            /* animation removed */
        }

       

        h1 {
            color: #0d6efd;
            font-size: 1.8em;
            margin-bottom: 10px;
        }

        h2 {
            font-size: 1.1em;
            color: #6c757d;
            margin-bottom: 25px;
        }

        .welcome-label {
            display: block;
            margin-bottom: 30px;
            font-weight: 600;
            color: #333;
        }

        .menu-section {
            display: flex;
            flex-direction: column;
            gap: 15px;
        }

        .menu-button {
            display: block;
            text-decoration: none;
            background-color: #0d6efd;
            color: #ffffff;
            font-weight: 600;
            border: none;
            border-radius: 8px;
            padding: 12px;
            text-align: center;
            transition: background-color 0.3s;
            text-transform: uppercase;
            letter-spacing: 0.5px;
            /* transform removed */
        }

        .menu-button:hover {
            background-color: #0a58ca;
            /* removed transform: scale */
        }

        footer {
            margin-top: 30px;
        }

        .footer-link {
            text-decoration: none;
            color: #6c757d;
            font-size: 0.9em;
            transition: color 0.3s;
        }

        .footer-link:hover {
            color: #0d6efd;
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">
        <div class="admin-card">
            <h1>🏥 Clínica Médica</h1>
            <h2>Panel del Administrador</h2>

            <span class="welcome-label">
                Bienvenido, <asp:Label ID="lbNombre" runat="server" />
            </span>

            <div class="menu-section">
                <asp:LinkButton ID="lnkbtnABMLP" runat="server" CssClass="menu-button" PostBackUrl="~/ABMLPaciente.aspx">
                    ABML Pacientes
                </asp:LinkButton>

                <asp:LinkButton ID="lnkbtnABMLM" runat="server" CssClass="menu-button" PostBackUrl="~/ABMLMedico.aspx">
                    ABML Médicos
                </asp:LinkButton>

                <asp:LinkButton ID="lnkbtnAsignacionT" runat="server" CssClass="menu-button" PostBackUrl="~/AsignacionDeTurnos.aspx">
                    Asignación de Turnos
                </asp:LinkButton>

                <asp:LinkButton ID="lnkbtnInformes" runat="server" CssClass="menu-button" PostBackUrl="~/InformeMenu.aspx">
                    Informes
                </asp:LinkButton>
            </div>

            <footer>
                <asp:LinkButton ID="lnkVolver" runat="server" CssClass="footer-link" PostBackUrl="~/Inicio.aspx">
                    ← Cerrar sesión
                </asp:LinkButton>
            </footer>
        </div>
    </form>
</body>
</html>
