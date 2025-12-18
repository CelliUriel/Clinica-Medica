<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ABMLPaciente.aspx.cs" Inherits="TP_INTEGRADOR_GRUPO_8.ABMLPaciente" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>👥 Gestión de Pacientes</title>

    <!-- Fuente moderna y estilo visual unificado -->
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
            max-width: 1440px;
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
        }

        hr {
            border: none;
            border-top: 1px solid #e0e6ed;
            margin: 25px 0;
        }

        /* === Buscar paciente === */
        .search-section {
        display: flex;
        align-items: center;
        justify-content: center; 
        gap: 20px;              
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
    <form id="form1" runat="server">
        <div class="main-container">
            
            <header>
                <h2>👥 ABML de Pacientes</h2>
                <p>Usuario Logueado: <asp:Label ID="lblNombre" runat="server"></asp:Label></p>
            </header>

            <hr />

            <!-- Buscar paciente -->
            <div class="search-section">
                <div>
                    <label for="<%= tbxFiltro.ClientID %>">Buscar Paciente (DNI):</label>
                    <asp:TextBox ID="tbxFiltro" runat="server" CssClass="text-control"></asp:TextBox>
                </div>
                <asp:Button ID="btnFiltrarPaciente" runat="server" Text="Buscar" CssClass="btn-action-primary" OnClick="btnFiltrarPaciente_Click" />
                <asp:RegularExpressionValidator ID="revBuscarDni" runat="server" ControlToValidate="tbxFiltro" Display="Dynamic" ErrorMessage="Ingrese solo numeros sin espacio" ForeColor="#3366CC" ValidationExpression="^\d*$"></asp:RegularExpressionValidator>
                <asp:RegularExpressionValidator ID="revDni" runat="server" ControlToValidate="tbxFiltro" Display="Dynamic" ErrorMessage="Ingrese un DNI valido" ForeColor="#3366CC" ValidationExpression="^(\d{8}|)$" Visible="False"></asp:RegularExpressionValidator>
            </div>

            <asp:Button ID="btnAlta" runat="server" CssClass="btn-action-primary" OnClick="btnAlta_Click" Text="Alta" />
            <asp:TextBox ID="tbxAlta" runat="server" CssClass="text-control" Visible="False"></asp:TextBox>
            <asp:Label ID="lblAlta" runat="server" ForeColor="#3366CC"></asp:Label>

            <hr />

            <!-- Listado -->
            <h3 style="color:#0d6efd; margin-bottom: 10px;">Listado de Pacientes</h3>
    <asp:GridView ID="gvPacientesBaja" runat="server"
                AutoGenerateColumns="False"
                DataKeyNames="DNI"
                AllowPaging="True"
                EmptyDataText="No se encontraron pacientes registrados."
                CssClass="gridview-style" AutoGenerateDeleteButton="True" OnRowCommand="gvPacientesBaja_RowCommand1" OnRowDeleting="gvPacientesBaja_RowDeleting" OnRowCancelingEdit="gvPacientesBaja_RowCancelingEdit" OnRowDataBound="gvPacientesBaja_RowDataBound" OnRowEditing="gvPacientesBaja_RowEditing1" OnRowUpdating="gvPacientesBaja_RowUpdating" AutoGenerateEditButton="True" OnPageIndexChanging="gvPacientesBaja_PageIndexChanging1">

                <Columns>
                    <asp:TemplateField HeaderText="DNI" >
                        <ItemTemplate>
                            <asp:Label ID="lb_it_dni" runat="server" Text='<%# Bind("DNI") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nombre" >
                        <EditItemTemplate>
                            <asp:TextBox ID="tb_eit_nombre" runat="server" Text='<%# Bind("Nombre") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lb_it_nombre" runat="server" Text='<%# Bind("Nombre") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Apellido" >
                        <EditItemTemplate>
                            <asp:TextBox ID="tb_eit_apellido" runat="server" Text='<%# Bind("Apellido") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lb_it_apeliido" runat="server" Text='<%# Bind("Apellido") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Fecha de nacimiento">
                        <EditItemTemplate>
                            <asp:Label ID="lb_eit_fecha" runat="server" Text='<%# Bind("FechaNacimiento") %>'></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lb_it_fecha" runat="server" Text='<%# Bind("FechaNacimiento") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Sexo">
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddl_eit_Sexo" runat="server">
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lb_it_sexo" runat="server" Text='<%# Bind("Sexo") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nacionalidad">
                        <EditItemTemplate>
                            <asp:TextBox ID="tb_eit_nacionalidad" runat="server" Text='<%# Bind("Nacionalidad") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lb_it_nacionalidad" runat="server" Text='<%# Bind("Nacionalidad") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Provincia">
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddl_eit_Provincia" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_eit_Provincia_SelectedIndexChanged">
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lb_it_provincia" runat="server" Text='<%# Bind("Provincia") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Localidad">
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddl_eit_localidad" runat="server">
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lb_it_paciente" runat="server" Text='<%# Bind("Localidad") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Direccion">
                        <EditItemTemplate>
                            <asp:TextBox ID="tb_eit_direccion" runat="server" Text='<%# Bind("Direccion") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lb_it_direccion" runat="server" Text='<%# Bind("Direccion") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Correo">
                        <EditItemTemplate>
                            <asp:TextBox ID="tb_eit_correo" runat="server" Text='<%# Bind("Correo") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lb_it_correo" runat="server" Text='<%# Bind("Correo") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Teléfono" >
                        <EditItemTemplate>
                            <asp:TextBox ID="tb_eit_telefono" runat="server" Text='<%# Bind("Telefono") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lb_it_telefono" runat="server" Text='<%# Bind("Telefono") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Estado (0 = Activo)" >
                     
                        <ItemTemplate>
                            <asp:Label ID="lb_it_estado" runat="server" Text='<%# Bind("Estado") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>


            <!-- Acciones -->
            <div class="link-section">
                <asp:LinkButton ID="lnkbtnPaciente" runat="server" PostBackUrl="~/AltaPaciente.aspx">➕ Agregar nuevo paciente</asp:LinkButton>
                <asp:LinkButton ID="lnkbtnVolverMenu" runat="server" PostBackUrl="~/MenuAdminstrador.aspx">← Volver</asp:LinkButton>
            </div>

        </div>
    </form>
</body>
</html>