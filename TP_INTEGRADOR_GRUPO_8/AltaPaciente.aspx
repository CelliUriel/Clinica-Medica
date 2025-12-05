<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AltaPaciente.aspx.cs" Inherits="TP_INTEGRADOR_GRUPO_8.AltaPaciente" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="utf-8" />
<title>🧾 Alta de Nuevo Paciente</title>

<!-- Fuente y hoja de estilo global -->
<link href="https://fonts.googleapis.com/css2?family=Inter:wght@400;500;600;700&display=swap" rel="stylesheet" />
<link rel="stylesheet" type="text/css" href="~/styles.css" runat="server" />

<style>
    body {
        font-family: 'Inter', sans-serif;
        background-color: #f5f7fa;
        margin: 0;
        padding: 0;
    }

    .main-container {
        max-width: 850px;
        margin: 60px auto;
        background-color: #fff;
        border-radius: 16px;
        box-shadow: 0 8px 20px rgba(0, 0, 0, 0.08);
        padding: 35px 45px;
    }

    header {
        text-align: center;
        margin-bottom: 20px;
    }

    header h2 {
        color: #0d6efd;
        font-weight: 700;
        margin-bottom: 5px;
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
                <h2>🧾 Alta de Nuevo Paciente</h2>
                <p>Usuario Logueado: <asp:Label ID="lblNombre" runat="server"></asp:Label></p>
            </header>

            <hr />

            <div class="form-grid">
                <div class="form-group">
                    <label for="<%= tbxDNI.ClientID %>">DNI</label>
                    <asp:TextBox ID="tbxDNI" runat="server" CssClass="text-control" MaxLength="8"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbxDNI" ForeColor="#3366CC">Se necesita completar este campo.</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="tbxDNI" ErrorMessage="RegularExpressionValidator" ForeColor="#3366CC" ValidationExpression="^\d+$">Ingrese solo numeros sin espacio</asp:RegularExpressionValidator>
                </div>

                <div class="form-group">
                    <label for="<%= tbxNombre.ClientID %>">Nombre</label>
                    <asp:TextBox ID="tbxNombre" runat="server" CssClass="text-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbxNombre" ForeColor="#3366CC">Se necesita completar este campo.</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="tbxNombre" ErrorMessage="RegularExpressionValidator" ForeColor="#3366CC" ValidationExpression="^[A-Za-z]+$">Ingrese solo letras sin espacio</asp:RegularExpressionValidator>
                </div>

                <div class="form-group">
                    <label for="<%= tbxApellido.ClientID %>">Apellido</label>
                    <asp:TextBox ID="tbxApellido" runat="server" CssClass="text-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbxApellido" ForeColor="#3366CC">Se necesita completar este campo.</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="tbxApellido" ErrorMessage="RegularExpressionValidator" ForeColor="#3366CC" ValidationExpression="^[A-Za-z]+$">Ingrese solo letras sin espacio</asp:RegularExpressionValidator>
                </div>

                <div class="form-group">
                    <label for="<%= ddlSexo.ClientID %>">Sexo</label>
                    <asp:DropDownList ID="ddlSexo" runat="server" CssClass="select-control">
                        <asp:ListItem Value="">-- Seleccionar --</asp:ListItem>
                        <asp:ListItem Value="M">Masculino</asp:ListItem>
                        <asp:ListItem Value="F">Femenino</asp:ListItem>
                        <asp:ListItem Value="X">Otro / No Binario</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlSexo" ForeColor="#3366CC">Se necesita completar este campo.</asp:RequiredFieldValidator>
                </div>

                <div class="form-group">
                    <label for="<%= tbxNacionalidad.ClientID %>">Nacionalidad</label>
                    <asp:TextBox ID="tbxNacionalidad" runat="server" CssClass="text-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="tbxNacionalidad" ForeColor="#3366CC">Se necesita completar este campo.</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="tbxNacionalidad" ErrorMessage="RegularExpressionValidator" ForeColor="#3366CC" ValidationExpression="^[A-Za-z]+$">Ingrese solo letras sin espacio</asp:RegularExpressionValidator>
                </div>

                <div class="form-group">
                    <label for="<%= tbxFechaNacimiento.ClientID %>">Fecha de Nacimiento</label>
                    <asp:TextBox ID="tbxFechaNacimiento" runat="server" CssClass="text-control" TextMode="Date"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="tbxFechaNacimiento" ForeColor="#3366CC">Se necesita completar este campo.</asp:RequiredFieldValidator>
                </div>

                <div class="form-group">
                    <label for="<%= tbxDireccion.ClientID %>">Dirección</label>
                    <asp:TextBox ID="tbxDireccion" runat="server" CssClass="text-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="tbxDireccion" ForeColor="#3366CC">Se necesita completar este campo.</asp:RequiredFieldValidator>
                </div>

                <div class="form-group">
                    <label for="<%= ddlLocalidades.ClientID %>">Localidad</label>
                    <asp:DropDownList ID="ddlLocalidades" runat="server" CssClass="select-control">
                        <asp:ListItem>--- Seleccionar ---</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlLocalidades" ForeColor="#3366CC">Se necesita completar este campo.</asp:RequiredFieldValidator>
                </div>

                <div class="form-group">
                    <label for="<%= ddlProvincias.ClientID %>">Provincia</label>
                    <asp:DropDownList ID="ddlProvincias" runat="server" CssClass="select-control" OnSelectedIndexChanged="ddlProvincias_SelectedIndexChanged" AutoPostBack="True">
                        <asp:ListItem>--- Seleccionar ---</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddlProvincias" ForeColor="#3366CC">Se necesita completar este campo.</asp:RequiredFieldValidator>
                </div>

                <div class="form-group">
                    <label for="<%= tbxCorreo.ClientID %>">Correo Electrónico</label>
                    <asp:TextBox ID="tbxCorreo" runat="server" CssClass="text-control" TextMode="Email"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="tbxCorreo" ForeColor="#3366CC">Se necesita completar este campo.</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="tbxCorreo" ErrorMessage="RegularExpressionValidator" ForeColor="#3366CC" ValidationExpression="^\S+$">Ingrese sin espacios</asp:RegularExpressionValidator>
                </div>

                <div class="form-group">
                    <label for="<%= tbxTelefono.ClientID %>">Teléfono</label>
                    <asp:TextBox ID="tbxTelefono" runat="server" CssClass="text-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="tbxTelefono" ForeColor="#3366CC">Se necesita completar este campo.</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="tbxTelefono" ErrorMessage="RegularExpressionValidator" ForeColor="#3366CC" ValidationExpression="^\d+$">Ingrese solo numeros sin espacio</asp:RegularExpressionValidator>
                </div>
            </div>

            <asp:Button ID="btnGuardar" runat="server" Text="Guardar Paciente" CssClass="btn-action-primary" OnClick="btnGuardar_Click" />

            <asp:Label ID="lblMensaje" runat="server"></asp:Label>

            <footer>
                <asp:LinkButton ID="lnkVolver" runat="server" CssClass="link-secondary" PostBackUrl="~/ABMLPaciente.aspx" CausesValidation="False">← Volver</asp:LinkButton>
            </footer>
        </div>
    </form>
</body>
</html>