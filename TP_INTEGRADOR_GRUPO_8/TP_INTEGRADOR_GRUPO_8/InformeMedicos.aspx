<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InformeMedicos.aspx.cs" Inherits="TP_INTEGRADOR_GRUPO_8.InformeMedicos" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Informe de medicos con mayor cantidad de turnos</title>

    <!-- Fuente moderna y hoja de estilos externa -->
    <link href="https://fonts.googleapis.com/css2?family=Inter:wght@400;500;600;700&display=swap" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="~/Styles.css" runat="server" />
</head>

<body>
    <form id="form1" runat="server">
        <div class="main-card-container">
            
            <!-- Encabezado -->
            <header class="card-header">
                <h2>Informe de Médicos con Mayor Cantidad de Turnos</h2>
                <p>Seleccione un rango de fechas para generar el informe</p>
            </header>

            <!-- Cuerpo principal -->
            <div class="card-body">
                <div class="input-row">
                    <div class="input-module-half">
                        <label for="<%= tbxFechaDesde.ClientID %>">Desde:</label>
                        <asp:TextBox ID="tbxFechaDesde" runat="server" CssClass="text-control" TextMode="Date"></asp:TextBox>
                    </div>

                    <div class="input-module-half">
                        <label for="<%= tbxFechaHasta.ClientID %>">Hasta:</label>
                        <asp:TextBox ID="tbxFechaHasta" runat="server" CssClass="text-control" TextMode="Date"></asp:TextBox>
                    </div>
                </div>

                <div class="action-row">
                    <asp:Button ID="btnGenerarInforme" runat="server" Text="Generar Informe" CssClass="btn-action-primary" />
                </div>
            </div>

            <hr class="divider" />

            <!-- Sección de resultados -->
            <section class="report-results-section" style="padding: 0 35px 35px 35px;">
                <h3 class="results-header">Resultados del Informe</h3>

                <asp:GridView ID="gvResultados" runat="server"
                    AutoGenerateColumns="true"
                    CssClass="results-grid"
                    EmptyDataText="Ingrese un rango de fechas para ver los médicos más productivos.">
                </asp:GridView>
            </section>

            <!-- Pie de página -->
            <footer class="card-footer">
                <asp:LinkButton ID="lbVolver" runat="server" CssClass="link-secondary" PostBackUrl="~/InformesMenu.aspx">
                    ← Volver al Menú de Informes
                </asp:LinkButton>
            </footer>

        </div>
    </form>
</body>
</html>