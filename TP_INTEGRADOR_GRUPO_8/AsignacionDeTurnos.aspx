<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AsignacionDeTurnos.aspx.cs" Inherits="TP_INTEGRADOR_GRUPO_8.AsignacionDeTurnos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Asignación de Turnos</title>
    <link rel="stylesheet" href="Styles.css" /> 
</head>
<body>
    <form id="form1" runat="server">
        <div class="main-card-container">
            
            <header class="card-header">
                <p>Usuario Logueado:
                <asp:Label ID="lblNombre" runat="server"></asp:Label>
                </p>
                <h2>ASIGNACIÓN DE TURNO</h2>
            </header>
            
            <div class="card-body">

                <div class="input-module">
                    <label class="input-label" for="<%= ddlEspecialidad.ClientID %>">Especialidad:</label>
                    <asp:DropDownList ID="ddlEspecialidad" runat="server" CssClass="select-control">
                        <asp:ListItem Value="">-- Seleccionar Especialidad --</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlEspecialidad" ForeColor="#3366CC">Se necesita completar este campo.</asp:RequiredFieldValidator>
                </div>

                <div class="input-module">
                    <label class="input-label" for="<%= ddlMedico.ClientID %>">Médico:</label>
                    <asp:DropDownList ID="ddlMedico" runat="server" CssClass="select-control">
                        <asp:ListItem Value="">-- Seleccionar Médico --</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlMedico" ForeColor="#3366CC">Se necesita completar este campo.</asp:RequiredFieldValidator>
                </div>

                <div class="input-module patient-selector">
                    <label class="input-label" for="<%= ddlPaciente.ClientID %>">Paciente:</label>
                    <asp:DropDownList ID="ddlPaciente" runat="server" CssClass="select-control">
                        <asp:ListItem Value="">-- Seleccionar Paciente --</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlPaciente" ForeColor="#3366CC">Se necesita completar este campo.</asp:RequiredFieldValidator>
                </div>

                <hr class="divider" />

                <div class="input-module-group-horizontal">
                    
                    <div class="input-module-half">
                        <div class="input-module">
                            <label class="input-label" for="<%= tbxFecha.ClientID %>">Fecha:</label>
                            <asp:TextBox ID="tbxFecha" runat="server" CssClass="text-control" TextMode="Date"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="tbxFecha" ForeColor="#3366CC">Se necesita completar este campo.</asp:RequiredFieldValidator>
                        </div>
                        <div class="input-module">
                            <label class="input-label" for="<%= ddlHora.ClientID %>">Hora:</label>
                            <asp:DropDownList ID="ddlHora" runat="server" CssClass="select-control">
                                <asp:ListItem Value="">-- Hora --</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlHora" ForeColor="#3366CC">Se necesita completar este campo.</asp:RequiredFieldValidator>
&nbsp;
                        </div>
                    </div>
                </div>

            </div>

            <footer class="card-footer">
                <asp:Button ID="btnAsignarTurno" runat="server" Text="ASIGNAR TURNO" CssClass="btn-action-primary" />
                <asp:LinkButton ID="lbVolver" runat="server" CssClass="link-secondary" PostBackUrl="~/MenuPrincipal.aspx">Volver al menu principal</asp:LinkButton>
                
                <asp:Label ID="lblMensaje" runat="server" CssClass="message-error" ForeColor="Red"></asp:Label>
            </footer>

        </div>
    </form>
</body>
</html>