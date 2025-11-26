<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ABMLMedico.aspx.cs" Inherits="TP_INTEGRADOR_GRUPO_8.BajaPaciente" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>👨‍⚕️ Gestión de Médicos</title>

    <!-- Fuente moderna + Hoja de estilos -->
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
            max-width: 1000px;
            margin: 60px auto;
            background-color: #ffffff;
            border-radius: 16px;
            box-shadow: 0 8px 20px rgba(0,0,0,0.08);
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
        }

        hr {
            border: none;
            border-top: 1px solid #e0e6ed;
            margin: 25px 0;
        }

        /* === Buscar médico === */
        .search-section {
            display: flex;
            align-items: center;
            justify-content: space-between;
            background-color: #f9fbfd;
            border: 1px solid #e2e8f0;
            border-radius: 12px;
            padding: 20px 25px;
            margin-bottom: 25px;
        }

        .search-section label {
            font-weight: 600;
            color: #2d3e50;
            margin-right: 15px;
        }

        .text-control {
            padding: 10px 12px;
            border: 1px solid #ccd4dd;
            border-radius: 8px;
            font-size: 1em;
            width: 300px;
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

        /* === GridView === */
        .gridview-style {
            width: 100%;
            border-collapse: collapse;
            margin-top: 15px;
            margin-right: 0px;
        }

        .gridview-style th {
            background-color: #0d6efd;
            color: white;
            padding: 10px;
            text-align: left;
            font-weight: 600;
        }

        .gridview-style td {
            padding: 10px;
            border-bottom: 1px solid #e2e8f0;
        }

        .gridview-style tr:hover {
            background-color: #f1f6ff;
        }

        .empty-text {
            text-align: center;
            color: #5f6c7b;
            padding: 20px 0;
        }

        /* === Links === */
        .link-section {
            margin-top: 30px;
            display: flex;
            flex-direction: column;
            gap: 12px;
        }

        .link-section a,
        .link-section asp\:linkbutton {
            color: #0d6efd;
            text-decoration: none;
            font-weight: 600;
            font-size: 1em;
        }

        .link-section a:hover,
        .link-section asp\:linkbutton:hover {
            text-decoration: underline;
        }
    </style>
</head>

<body>
    <form id="form2" runat="server">
        <div class="main-container">
            
            <header>
                <h2>👨‍⚕️ ABML de Médicos</h2>
                <p>Usuario Logueado: <asp:Label ID="lblNombre" runat="server"></asp:Label></p>
            </header>

            <hr />

            <!-- Buscar médico -->
            <div class="search-section">
                <div>
                    <label for="<%= tbxFiltrar.ClientID %>">Buscar Médico (DNI):</label>
                    <asp:TextBox ID="tbxFiltrar" runat="server" CssClass="text-control"></asp:TextBox>
                </div>
                <asp:Button ID="btnFiltrar" runat="server" Text="Buscar" CssClass="btn-action-primary" OnClick="btnFiltrar_Click" />
            </div>

            <hr />

            <!-- Listado -->
            <h3 style="color:#0d6efd; margin-bottom: 10px;">Listado de Médicos</h3>
            <asp:GridView ID="gvMedicosBaja" runat="server"
                AutoGenerateColumns="False"
                DataKeyNames="DNI"
                OnRowCommand="gvMedicosBaja_RowCommand"
                AllowPaging="True"
                OnPageIndexChanging="gvMedicosBaja_PageIndexChanging"
                EmptyDataText="No se encontraron médicos registrados."
                CssClass="gridview-style" AutoGenerateEditButton="True" OnRowEditing="gvMedicosBaja_RowEditing">

                <Columns>
                    <asp:TemplateField HeaderText="DNI">
                        <EditItemTemplate>
                            <asp:Label ID="lbl_eit_dni" runat="server" Text='<%# Bind("DNI") %>'></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_dni" runat="server" Text='<%# Bind("DNI") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nombre">
                        <EditItemTemplate>
                            <asp:TextBox ID="txt_eit_nombre" runat="server" Text='<%# Bind("Nombre") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_Nombre" runat="server" Text='<%# Bind("Nombre") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Apellido">
                        <EditItemTemplate>
                            <asp:TextBox ID="txt_eit_apellido" runat="server" Text='<%# Bind("Apellido") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_Apellido" runat="server" Text='<%# Bind("Apellido") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Teléfono">
                        <EditItemTemplate>
                            <asp:TextBox ID="txt_eit_telefono" runat="server" Text='<%# Bind("Telefono") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_telefono" runat="server" Text='<%# Bind("Telefono") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Estado (0 = Activo)">
                        <EditItemTemplate>
                            <asp:TextBox ID="txt_eit_estado" runat="server" Text='<%# Bind("Estado") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_estado" runat="server" Text='<%# Bind("Estado") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Especialidad">
                        <EditItemTemplate>
                            <asp:TextBox ID="txt_eit_especialidad" runat="server" Text='<%# Bind("Codigo_Especialidad_Medico") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_especialidad" runat="server" Text='<%# Bind("Codigo_Especialidad_Medico") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

            <!-- Acciones -->
            <div class="link-section">
                <asp:LinkButton ID="lnkbtnMedico" runat="server" PostBackUrl="~/AltaMedicos.aspx">➕ Registrar nuevo médico</asp:LinkButton>
                <asp:LinkButton ID="LinkButton1" runat="server">👤 Crear nuevo Usuario Médico</asp:LinkButton>
                <asp:LinkButton ID="lnkbtnVolver" runat="server" PostBackUrl="~/MenuAdminstrador.aspx">← Volver</asp:LinkButton>
            </div>

        </div>
    </form>
</body>
</html>