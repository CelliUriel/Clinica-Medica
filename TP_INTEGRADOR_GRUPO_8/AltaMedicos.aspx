<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AltaMedicos.aspx.cs" Inherits="TP_INTEGRADOR_GRUPO_8.AltaMedicos" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="utf-8" />
<title>👨‍⚕️ Alta de Médico</title>

<!-- Fuente y hoja de estilo externa -->
<link href="https://fonts.googleapis.com/css2?family=Inter:wght@400;500;600;700&display=swap" rel="stylesheet" />
<link rel="stylesheet" type="text/css" href="~/styles.css" runat="server" />

<style>
    body {
        font-family: 'Inter', sans-serif;
        background-color: #f4f7fa;
        margin: 0;
        padding: 0;
    }

    .main-container {
        max-width: 900px;
        margin: 60px auto;
        background-color: #ffffff;
        border-radius: 16px;
        box-shadow: 0 8px 20px rgba(0, 0, 0, 0.08);
        padding: 30px 40px;
    }

    header {
        text-align: center;
        margin-bottom: 20px;
    }

    header h2 {
        color: #0d6efd;
        font-weight: 700;
        letter-spacing: 0.5px;
    }

    p {
        color: #5f6c7b;
        font-size: 0.95em;
        text-align: center;
    }

    hr {
        border: none;
        border-top: 1px solid #e0e6ed;
        margin: 25px 0;
    }

    /* === FORMULARIO === */
    .form-grid {
        display: grid;
        grid-template-columns: 1fr 1fr;
        gap: 20px 40px;
    }

    .form-group {
        display: flex;
        flex-direction: column;
    }

    label {
        font-weight: 600;
        color: #2d3e50;
        margin-bottom: 6px;
    }

    .text-control,
    .select-control {
        padding: 10px 12px;
        border: 1px solid #ccd4dd;
        border-radius: 8px;
        font-size: 1em;
        transition: border-color 0.3s, box-shadow 0.3s;
    }

    .text-control:focus,
    .select-control:focus {
        border-color: #0d6efd;
        box-shadow: 0 0 5px rgba(13,110,253,0.25);
        outline: none;
    }

    .days-section {
        grid-column: 1 / span 2;
        background-color: #f9fbfd;
        border: 1px solid #e2e8f0;
        border-radius: 10px;
        padding: 20px;
        margin-top: 10px;
    }

    .days-section h4 {
        color: #0d6efd;
        margin-bottom: 10px;
    }

    .btn-action-primary {
        background-color: #0d6efd;
        color: white;
        border: none;
        border-radius: 8px;
        padding: 12px 30px;
        font-weight: 600;
        cursor: pointer;
        transition: background-color 0.3s ease, transform 0.1s ease;
        display: block;
        margin: 30px auto 0 auto;
    }

    .btn-action-primary:hover {
        background-color: #0a58ca;
        transform: scale(1.02);
    }

    footer {
        text-align: center;
        margin-top: 30px;
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
                <h2>👨‍⚕️ Alta de Médico</h2>
                <p>Usuario Logueado: <asp:Label ID="lblNombre" runat="server"></asp:Label></p>
            </header>

            <hr />

            <div class="form-grid">

                <div class="form-group">
                    <label for="<%= tbDNI.ClientID %>">DNI</label>
                    <asp:TextBox ID="tbDNI" runat="server" CssClass="text-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbDNI" ForeColor="#3366CC">Se necesita completar este campo.</asp:RequiredFieldValidator>
                </div>

                <div class="form-group">
                    <label for="<%= tbNombre.ClientID %>">Nombre</label>
                    <asp:TextBox ID="tbNombre" runat="server" CssClass="text-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbNombre" ForeColor="#3366CC">Se necesita completar este campo.</asp:RequiredFieldValidator>
                </div>

                <div class="form-group">
                    <label for="<%= TbApellido.ClientID %>">Apellido</label>
                    <asp:TextBox ID="TbApellido" runat="server" CssClass="text-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TbApellido" ForeColor="#3366CC">Se necesita completar este campo.</asp:RequiredFieldValidator>
                </div>

                <div class="form-group">
                    <label for="<%= ddlSexo.ClientID %>">Sexo</label>
                    <asp:DropDownList ID="ddlSexo" runat="server" CssClass="select-control">
                        <asp:ListItem>--- Seleccionar ---</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlSexo" ForeColor="#3366CC">Se necesita completar este campo.</asp:RequiredFieldValidator>
                </div>

                <div class="form-group">
                    <label for="<%= tbNacionalidad.ClientID %>">Nacionalidad</label>
                    <asp:TextBox ID="tbNacionalidad" runat="server" CssClass="text-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="tbNacionalidad" ForeColor="#3366CC">Se necesita completar este campo.</asp:RequiredFieldValidator>
                </div>

                <div class="form-group">
                    <label for="<%= tbFechaNacimiento.ClientID %>">Fecha de Nacimiento</label>
                    <asp:TextBox ID="tbFechaNacimiento" runat="server" CssClass="text-control" TextMode="Date"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="tbFechaNacimiento" ForeColor="#3366CC">Se necesita completar este campo.</asp:RequiredFieldValidator>
                </div>

                <div class="form-group">
                    <label for="<%= tbDireccion.ClientID %>">Dirección</label>
                    <asp:TextBox ID="tbDireccion" runat="server" CssClass="text-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="tbDireccion" ForeColor="#3366CC">Se necesita completar este campo.</asp:RequiredFieldValidator>
                </div>

                <div class="form-group">
                    <label for="<%= ddlLocalidad.ClientID %>">Provincia</label>
                    <asp:DropDownList ID="ddlProvincia" runat="server" CssClass="select-control" AutoPostBack="true" OnSelectedIndexChanged="DdlProvincia_SelectedIndexChanged">
                        <asp:ListItem>--- Seleccionar ---</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddlLocalidad" ForeColor="#3366CC">Se necesita completar este campo.</asp:RequiredFieldValidator>
                </div>

                <div class="form-group">
                    Localidad <asp:DropDownList ID="ddlLocalidad" runat="server" CssClass="select-control">
                        <asp:ListItem>--- Seleccionar ---</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="ddlProvincia" ForeColor="#3366CC">Se necesita completar este campo.</asp:RequiredFieldValidator>
                </div>

                <div class="form-group">
                    <label for="<%= tbCorreoElectronico.ClientID %>">Correo Electrónico</label>
                    <asp:TextBox ID="tbCorreoElectronico" runat="server" CssClass="text-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="tbCorreoElectronico" ForeColor="#3366CC">Se necesita completar este campo.</asp:RequiredFieldValidator>
                </div>

                <div class="form-group">
                    <label for="<%= tbTelefono.ClientID %>">Teléfono</label>
                    <asp:TextBox ID="tbTelefono" runat="server" CssClass="text-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="tbTelefono" ForeColor="#3366CC">Se necesita completar este campo.</asp:RequiredFieldValidator>
                </div>

                <div class="form-group">
                    <label for="<%= ddlEspecialidad.ClientID %>">Especialidad</label>
                    <asp:DropDownList ID="ddlEspecialidad" runat="server" CssClass="select-control">
                        <asp:ListItem>--- Seleccionar ---</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="ddlEspecialidad" ForeColor="#3366CC">Se necesita completar este campo.</asp:RequiredFieldValidator>
                </div>

                <div class="form-group">
                    <label for="<%= ddlHoraInicio.ClientID %>">Hora Inicio</label>
                    <asp:DropDownList ID="ddlHoraInicio" runat="server" CssClass="select-control">
                        <asp:ListItem>- Seleccionar -</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="ddlHoraInicio" ForeColor="#3366CC">Se necesita completar este campo.</asp:RequiredFieldValidator>
                </div>

                <div class="form-group">
                    <label for="<%= ddlHoraFin.ClientID %>">Hora Fin</label>
                    <asp:DropDownList ID="ddlHoraFin" runat="server" CssClass="select-control">
                        <asp:ListItem>- Seleccionar -</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="ddlHoraInicio" ForeColor="#3366CC">Se necesita completar este campo.</asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="days-section">
                <h4>Días de Atención</h4>
                <asp:CheckBoxList ID="chkblDias" runat="server" RepeatDirection="Horizontal" RepeatColumns="3" ValidationGroup="2">
                    <asp:ListItem>Lunes</asp:ListItem>
                    <asp:ListItem>Martes</asp:ListItem>
                    <asp:ListItem>Miércoles</asp:ListItem>
                    <asp:ListItem>Jueves</asp:ListItem>
                    <asp:ListItem>Viernes</asp:ListItem>
                    <asp:ListItem>Sábado</asp:ListItem>
                </asp:CheckBoxList>
            </div>
            <div class="form-group">
        <label for="<%= tbUsuario.ClientID %>">Usuario</label>
        <asp:TextBox ID="tbUsuario" runat="server" CssClass="text-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvUsuario" runat="server" ControlToValidate="tbUsuario" ForeColor="#3366CC">Campo obligatorio</asp:RequiredFieldValidator>
    </div>

    <div class="form-group">
        <label for="<%= tbContrasenia.ClientID %>">Contraseña</label>
        <asp:TextBox ID="tbContrasenia" runat="server" CssClass="text-control" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvContrasenia" runat="server" ControlToValidate="tbContrasenia" ForeColor="#3366CC">Campo obligatorio</asp:RequiredFieldValidator>
    </div>

</div>

            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn-action-primary" OnClick="BtnGuardar_Click" />

            <footer>
                <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                <br />
                <br />
                <br />
                <asp:LinkButton ID="lnkVolver" runat="server" CssClass="link-secondary" PostBackUrl="~/ABMLMedico.aspx" CausesValidation="False">← Volver</asp:LinkButton>
            </footer>
        </div>
    </form>
</body>
</html>