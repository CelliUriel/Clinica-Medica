<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InformeMenu.aspx.cs" Inherits="TP_INTEGRADOR_GRUPO_8.InformeMenu" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>📑 Menú de Informes</title>

    <!-- Fuente moderna + estilo visual -->
    <link href="https://fonts.googleapis.com/css2?family=Inter:wght@400;500;600;700&display=swap" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="~/styles.css" runat="server" />

    <style>
        body {
            font-family: 'Inter', sans-serif;
            background-color: #f4f7fa;
            margin: 0;
            padding: 0;
        }

        .report-menu-container {
            max-width: 900px;
            margin: 60px auto;
            background-color: #ffffff;
            border-radius: 16px;
            box-shadow: 0 8px 20px rgba(0, 0, 0, 0.08);
            overflow: hidden;
        }

        /* HEADER */
        .menu-header {
            background: linear-gradient(135deg, #0d6efd, #3f8efc);
            color: white;
            text-align: center;
            padding: 30px 20px;
        }

        .menu-header h2 {
            margin: 0;
            font-size: 1.8em;
            font-weight: 700;
            letter-spacing: 0.5px;
        }

        .user-context-tag {
            display: inline-block;
            background-color: rgba(255, 255, 255, 0.2);
            padding: 6px 14px;
            border-radius: 30px;
            font-size: 0.9em;
            margin-top: 10px;
        }

        .menu-divider {
            border: none;
            border-top: 1px solid #e0e6ed;
            margin: 0;
        }

        /* MENU BODY */
        .menu-options {
            padding: 40px 50px;
            display: flex;
            flex-direction: column;
            gap: 30px;
        }

        .menu-item {
            background-color: #f9fbfd;
            border: 1px solid #e2e8f0;
            border-radius: 12px;
            padding: 25px 30px;
            transition: transform 0.2s ease, box-shadow 0.2s ease;
        }

        .menu-item:hover {
            transform: scale(1.01);
            box-shadow: 0 4px 12px rgba(0, 0, 0, 0.06);
        }

        .menu-item h3 {
            color: #0d6efd;
            margin-bottom: 8px;
            font-size: 1.3em;
            font-weight: 600;
        }

        .menu-item p {
            color: #5f6c7b;
            margin-top: 0;
            margin-bottom: 15px;
            font-size: 0.95em;
        }

        .btn-link-action {
            display: inline-block;
            background-color: #0d6efd;
            color: white;
            text-decoration: none;
            padding: 10px 18px;
            border-radius: 8px;
            font-weight: 600;
            transition: background-color 0.3s ease;
        }

        .btn-link-action:hover {
            background-color: #0a58ca;
            text-decoration: none;
        }

        /* FOOTER */
        .menu-footer {
            background-color: #f9fafb;
            padding: 20px 30px;
            border-top: 1px solid #e0e6ed;
            text-align: right;
        }

        .link-back-main {
            color: #0d6efd;
            text-decoration: none;
            font-weight: 600;
        }

        .link-back-main:hover {
            text-decoration: underline;
        }

        /* RESPONSIVE */
        @media (max-width: 700px) {
            .menu-options {
                padding: 25px;
            }

            .menu-item {
                padding: 20px;
            }
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">
        <div class="report-menu-container">
            
            <!-- Encabezado -->
            <header class="menu-header">
                <h2>📑 Reportes del Sistema</h2>
                <asp:Label ID="lblUsuarioRol" runat="server" CssClass="user-context-tag"></asp:Label>
            </header>

            <hr class="menu-divider" />

            <!-- Sección de opciones -->
            <section class="menu-options">
                <div class="menu-item">
                    <h3>Informe de Médicos con Mayor Cantidad de Turnos</h3>
                    <p>Visualiza los médicos con más turnos en los primeros seis meses.</p>
                    <asp:LinkButton ID="lbTurnosEspecialidad" runat="server" CssClass="btn-link-action" PostBackUrl="~/InformeMedicos.aspx">
                        Ver Informe
                    </asp:LinkButton>
                </div>

                <div class="menu-item">
                    <h3>Informe de Asistencias</h3>
                    <p>Consulta los pacientes ausentes y presentes hasta la fecha.</p>
                    <asp:LinkButton ID="lbInformePacientes" runat="server" CssClass="btn-link-action" PostBackUrl="~/InformePacientes.aspx">
                        Ver Informe
                    </asp:LinkButton>
                </div>
            </section>

            <!-- Pie de página -->
            <footer class="menu-footer">
                <asp:LinkButton ID="lbVolver" runat="server" CssClass="link-back-main" PostBackUrl="~/PaginaInicio.aspx">
                    ← Volver al Menú Principal
                </asp:LinkButton>
            </footer>

        </div>
    </form>
</body>
</html>