<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InformePacientes.aspx.cs" Inherits="TP_INTEGRADOR_GRUPO_8.InformePacientes" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>📋 Informe de Asistencias y Ausentismo</title>
    
    <!-- Fuente moderna + estilo limpio y profesional -->
    <link href="https://fonts.googleapis.com/css2?family=Inter:wght@400;500;600;700&display=swap" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="~/styles.css" runat="server" />

    <style>
        body {
            font-family: 'Inter', sans-serif;
            background-color: #f5f8fb;
            margin: 0;
            padding: 0;
        }

        .main-container {
            max-width: 900px;
            margin: 60px auto;
            background-color: #ffffff;
            border-radius: 16px;
            box-shadow: 0 8px 20px rgba(0,0,0,0.08);
            overflow: hidden;
        }

        header {
            background: linear-gradient(135deg, #0d6efd, #3f8efc);
            color: white;
            text-align: center;
            padding: 30px 20px;
        }

        header h2 {
            margin: 0;
            font-weight: 600;
            letter-spacing: 0.5px;
        }

        .report-filter-area {
            padding: 30px;
            background-color: #fafbfd;
        }

        .report-filter-area label {
            font-weight: 600;
            color: #2d3e50;
            display: block;
            margin-bottom: 6px;
        }

        .text-control {
            width: 100%;
            padding: 10px 12px;
            border-radius: 8px;
            border: 1px solid #ccd4dd;
            font-size: 1em;
            transition: border-color 0.3s, box-shadow 0.3s;
        }

        .text-control:focus {
            border-color: #0d6efd;
            box-shadow: 0 0 5px rgba(13,110,253,0.25);
            outline: none;
        }

        .btn-action-primary {
            background-color: #0d6efd;
            color: white;
            border: none;
            border-radius: 8px;
            padding: 10px 25px;
            font-weight: 600;
            cursor: pointer;
            transition: background-color 0.3s ease, transform 0.1s ease;
        }

        .btn-action-primary:hover {
            background-color: #0a58ca;
            transform: scale(1.02);
        }

        hr {
            border: none;
            border-top: 1px solid #e0e6ed;
            margin: 30px 0;
        }

        section {
            padding: 0 30px 30px 30px;
        }

        h3 {
            color: #0d6efd;
            border-left: 4px solid #0d6efd;
            padding-left: 10px;
            margin-bottom: 15px;
        }

        table {
            width: 100%;
            border-collapse: collapse;
            background-color: #ffffff;
        }

        table td {
            border: 1px solid #e2e8f0;
            padding: 12px 15px;
            text-align: center;
            vertical-align: middle;
            color: #2d3e50;
            font-size: 0.95em;
        }

        .summary-table td p {
            margin: 0;
            color: #5f6c7b;
        }

        .summary-table td label {
            font-weight: 700;
            font-size: 1.1em;
        }

        .results-grid {
            width: 100%;
            border-collapse: collapse;
        }

        .results-grid th {
            background-color: #0d6efd;
            color: white;
            padding: 10px;
            text-align: left;
            font-weight: 600;
        }

        .results-grid td {
            padding: 10px;
            border-bottom: 1px solid #e2e8f0;
        }

        .results-grid tr:hover {
            background-color: #f1f6ff;
        }

        footer {
            background-color: #f9fafb;
            padding: 20px 30px;
            text-align: right;
            border-top: 1px solid #e0e6ed;
        }

        .link-secondary {
            color: #0d6efd;
            text-decoration: none;
            font-weight: 600;
        }

        .link-secondary:hover {
            text-decoration: underline;
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">
        <div class="main-container">
            
            <header>
                <h2>📋 Informe de Asistencias de Pacientes</h2>
            </header>
            
            <div class="report-filter-area">
                <table style="width: 100%;">
                    <tr>
                        <td style="width: 50%;">
                            <label for="<%= tbxFechaDesde.ClientID %>">Desde:</label>
                            <asp:TextBox ID="tbxFechaDesde" runat="server" CssClass="text-control" TextMode="Date"></asp:TextBox>
                        </td>
                        <td style="width: 50%;">
                            <label for="<%= tbxFechaHasta.ClientID %>">Hasta:</label>
                            <asp:TextBox ID="tbxFechaHasta" runat="server" CssClass="text-control" TextMode="Date"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                
                <div style="text-align: center; margin-top: 25px;">
                    <asp:Button ID="btnGenerarInforme" runat="server" Text="Generar Informe" CssClass="btn-action-primary" OnClick="BtnGenerarInforme_Click" />
                </div>
            </div>
            
            <hr />

            <section runat="server" id="pnlResumen" Visible="false">
                <h3>Resumen de Asistencia Global</h3>
                <table class="summary-table">
                    <tr>
                        <td>
                            <p>Total de Turnos</p>
                            <asp:Label ID="lblTotalTurnos" runat="server" Font-Bold="True" Text="0"></asp:Label>
                        </td>
                        <td>
                            <p>Tasa de Presentismo</p>
                            <asp:Label ID="lblPorcentajePresentes" runat="server" Font-Bold="True" Text="0%"></asp:Label>
                        </td>
                        <td>
                            <p>Tasa de Ausentismo</p>
                            <asp:Label ID="lblPorcentajeAusentes" runat="server" Font-Bold="True" Text="0%"></asp:Label>
                        </td>
                    </tr>
                </table>
            </section>
            
            <hr />

            <section>
                <h3>Pacientes Ausentes</h3>
                <asp:GridView ID="gvAusentes" runat="server" AutoGenerateColumns="true" CssClass="results-grid"
                    EmptyDataText="No se registraron ausencias en el período." GridLines="Vertical"></asp:GridView>

                <h3 style="margin-top: 35px;">Pacientes Presentes</h3>
                <asp:GridView ID="gvPresentes" runat="server" AutoGenerateColumns="true" CssClass="results-grid"
                    EmptyDataText="No se registraron asistencias en el período." GridLines="Vertical"></asp:GridView>
            </section>

            <footer>
                <asp:LinkButton ID="lbVolver" runat="server" CssClass="link-secondary" PostBackUrl="~/InformeMenu.aspx">
                    ← Volver al Menú de Informes
                </asp:LinkButton>
            </footer>
        </div>
    </form>
</body>
</html>