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
                <h3><asp:Label ID="lblNombre" runat="server"></asp:Label></h3>
                <p>Seleccione un rango de &nbsp;fechas para generar el informe</p>
            </header>

            <!-- Cuerpo principal -->
            <div class="card-body">
                <div class="input-row">
                    <div class="input-module-half">
                        <label for="<%= tbxFechaDesde.ClientID %>">Desde:</label>
                        <asp:TextBox ID="tbxFechaDesde" runat="server" CssClass="text-control" TextMode="Date"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RfvFechaDesdeInformeMedicos" runat="server" ControlToValidate="tbxFechaDesde" ForeColor="#3366CC">Ingrese una fecha</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RevFechaDesdeInformeMedicos" runat="server" ControlToValidate="tbxFechaDesde" Display="Dynamic" ErrorMessage="RegularExpressionValidator" ForeColor="#3366CC" ValidationExpression="^(18[0-9]{2}|19[0-9]{2}|2[0-4][0-9]{2}|2500)-(0[1-9]|1[0-2])-(0[1-9]|[12][0-9]|3[01])$">Ingrese una fecha valida</asp:RegularExpressionValidator>
                    </div>

                    <div class="input-module-half">
                        <label for="<%= tbxFechaHasta.ClientID %>">Hasta:</label>
                        <asp:TextBox ID="tbxFechaHasta" runat="server" CssClass="text-control" TextMode="Date"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RfvFechaHastaInformeMedicos" runat="server" ControlToValidate="tbxFechaHasta" ForeColor="#3366CC">Ingrese una fecha</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RevFechaHastaInformeMedicos0" runat="server" ControlToValidate="tbxFechaHasta" Display="Dynamic" ErrorMessage="RegularExpressionValidator" ForeColor="#3366CC" ValidationExpression="^(18[0-9]{2}|19[0-9]{2}|2[0-4][0-9]{2}|2500)-(0[1-9]|1[0-2])-(0[1-9]|[12][0-9]|3[01])$">Ingrese una fecha valida</asp:RegularExpressionValidator>
                    </div>
                </div>

                <div class="action-row">
                    <asp:Button ID="btnGenerarInforme" runat="server" Text="Generar Informe" CssClass="btn-action-primary" OnClick="BtnGenerarInforme_Click" ValidationGroup="validacionFechas" />
                    <br />
                        <label for="<%= tbxFechaDesde.ClientID %>">
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="tbxFechaDesde" ControlToValidate="tbxFechaHasta" ErrorMessage="Ingrese una fecha valida." ForeColor="#CC0000" Operator="GreaterThan" Type="Date" ValidationGroup="validacionFechas"></asp:CompareValidator>
                    </label>
                </div>
            </div>

            <hr class="divider" />

            <!-- Sección de resultados -->
            <section class="report-results-section" style="padding: 0 35px 35px 35px;">
                <h3 class="results-header">Resultados del Informe">Resultados del Informe</h3>

                <asp:GridView ID="gvResultados" runat="server"
                    AutoGenerateColumns="true"
                    CssClass="results-grid"
                    EmptyDataText="Ingrese un rango de fechas para ver los médicos más productivos.">
                </asp:GridView>
            </section>

            <!-- Pie de página -->
            <footer class="card-footer">
                <asp:LinkButton ID="lbVolver" runat="server" CssClass="link-secondary" PostBackUrl="~/InformeMenu.aspx" CausesValidation="False">
                    ← Volver al Menú de Informes
                </asp:LinkButton>
            </footer>

        </div>
    </form>
</body>
</html>