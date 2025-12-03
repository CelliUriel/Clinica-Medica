<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VisualizarTurnosMedico.aspx.cs" Inherits="TP_INTEGRADOR_GRUPO_8.VisualizarTurnosMedico" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Listado de Turnos del Médico</title>

    <style>
        .contenedor {
            width: 80%;
            margin: auto;
            padding: 20px;
            margin-top: 20px;
            background: #fff;
            border-radius: 10px;
            box-shadow: 0px 0px 12px #d5d5d5;
        }

        .titulo {
            text-align: center;
            font-size: 24px;
            margin-bottom: 25px;
            font-weight: bold;
            color: #2F6FA3;
        }

        .filtro-box {
            padding: 15px;
            background: #f2f7ff;
            border-radius: 8px;
            margin-bottom: 20px;
        }

        .grid table {
            width: 100%;
        }

        .grid th {
            background: #2F6FA3;
            color: white;
            padding: 10px;
            text-align: left;
        }

        .grid td {
            padding: 8px;
            background: #fafafa;
        }

        .btnVolver {
            margin-top: 15px;
            padding: 8px 20px;
            border: none;
            border-radius: 5px;
            background: #2F6FA3;
            color: white;
            cursor: pointer;
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">
        <div class="contenedor">

            <div class="titulo">Listado de Turnos del Médico</div>

            <asp:Label ID="lblNombreMedico" runat="server" 
                       Text="Nombre Médico" 
                       Style="display:block;text-align:center;font-size:18px;margin-bottom:20px;">
            </asp:Label>

            <!-- Filtros -->
            <div class="filtro-box">
                Fecha:
                <asp:TextBox ID="tbFecha" runat="server" TextMode="Date"></asp:TextBox>

                &nbsp; Estado:
                <asp:DropDownList ID="ddlEstado" runat="server">
                    <asp:ListItem Text="Todos" Value="Todos" />
                    <asp:ListItem Text="Presente" Value="Presente" />
                    <asp:ListItem Text="Ausente" Value="Ausente" />
                </asp:DropDownList>

                &nbsp;
                <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" />
            </div>

            <!-- GRID -->
            <asp:GridView ID="gvTurnos" runat="server" AutoGenerateColumns="False" CssClass="grid">
                <Columns>
                    <asp:TemplateField HeaderText="Fecha">
                        <ItemTemplate>
                            <asp:Label ID="it_listadoFecha" runat="server" Text='<%# Bind("Fecha") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Hora">
                        <ItemTemplate>
                            <asp:Label ID="it_listadoHora" runat="server" Text='<%# Bind("Hora") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Paciente">
                        <ItemTemplate>
                            <asp:Label ID="it_listadoPaciente" runat="server" Text='<%# Bind("Paciente") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Estado">
                        <ItemTemplate>
                            <asp:Label ID="it_listadoEstado" runat="server" Text='<%# Bind("Estado") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Observaciones">
                        <ItemTemplate>
                            <asp:Label ID="it_listadoObservaciones" runat="server" Text='<%# Bind("Observaciones") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Acciones">
                        <ItemTemplate>
                            <asp:Button ID="btnEditar" runat="server" Text="Editar"
                                CommandName="EditarTurno" CommandArgument= '0' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

            <asp:Button ID="btnVolver" runat="server" Text="← Volver al Menú" CssClass="btnVolver"/>

        </div>
    </form>
</body>
</html>