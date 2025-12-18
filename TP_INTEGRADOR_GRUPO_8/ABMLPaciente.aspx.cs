using Entidades;
using Negocio;
using System;
using System.Data;
using System.Reflection.Emit;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace TP_INTEGRADOR_GRUPO_8
{
    public partial class ABMLPaciente : System.Web.UI.Page
    {

        NegocioPacientes negocio = new NegocioPacientes();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] != null)
            {
                Usuario usuario = (Usuario)Session["Usuario"];
                lblNombre.Text = usuario.getNombre_usuario().ToString();
            }
            if (!IsPostBack)
            {
                CargarGridViewPaciente();
            }
        }


        private void CargarGridViewPaciente()
        {
            gvPacientesBaja.DataSource = negocio.ListarPacientes();
            gvPacientesBaja.DataBind();
        }

        protected void gvPacientesBaja_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }
        protected void gvPacientesBaja_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }


        protected void gvPacientesBaja_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void btnFiltrarPaciente_Click(object sender, EventArgs e)
        {
            string dni = tbxFiltro.Text.Trim();
            LimpiarAlta();

            if (!string.IsNullOrWhiteSpace(dni))
            {
                gvPacientesBaja.DataSource = negocio.filtrarPorDniPaciente(dni);
                gvPacientesBaja.DataBind();
                tbxFiltro.Text = string.Empty;
            }
            else
            {

                CargarGridViewPaciente();
            }
        }

        protected void gvPacientesBaja_RowCommand1(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EliminarPaciente")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                string dni = gvPacientesBaja.DataKeys[index].Value.ToString();

                Pacientes paciente = new Pacientes(dni);
                NegocioPacientes negocio = new NegocioPacientes();

                negocio.EliminarPaciente(paciente);

                gvPacientesBaja.DataSource = negocio.ListarPacientes();
                gvPacientesBaja.DataBind();
            }
        }

        protected void gvPacientesBaja_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string dni = gvPacientesBaja.DataKeys[e.RowIndex].Value.ToString();
            Pacientes paciente = new Pacientes(dni);
            bool eliminado = new NegocioPacientes().EliminarPaciente(paciente);
            if (eliminado)
            {
                CargarGridViewPaciente();
            }
        }

        protected void gvPacientesBaja_RowEditing1(object sender, GridViewEditEventArgs e)
        {
            gvPacientesBaja.EditIndex = e.NewEditIndex;
            CargarGridViewPaciente();
            LimpiarAlta();

        }

        protected void gvPacientesBaja_RowDataBound(object sender, GridViewRowEventArgs e)
        {


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string nombre = DataBinder.Eval(e.Row.DataItem, "Nombre").ToString();
                string apellido = DataBinder.Eval(e.Row.DataItem, "Apellido").ToString();

                foreach (Control c in e.Row.Controls)
                {
                    if (c is TableCell)
                    {
                        foreach (Control ctrl in c.Controls)
                        {
                            if (ctrl is LinkButton btn &&
                                btn.CommandName == "Delete")
                            {
                                btn.OnClientClick =
                                    $"return confirm('¿Eliminar al paciente {nombre} {apellido}?');";
                            }
                        }
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.DataRow &&
               (e.Row.RowState & DataControlRowState.Edit) > 0)
            {
                DataRowView drv = e.Row.DataItem as DataRowView;
                if (drv == null) return;

                
                (e.Row.FindControl("tb_eit_nombre") as TextBox).Text = drv["Nombre"].ToString();
                (e.Row.FindControl("tb_eit_apellido") as TextBox).Text = drv["Apellido"].ToString();
                (e.Row.FindControl("tb_eit_direccion") as TextBox).Text = drv["Direccion"].ToString();
                (e.Row.FindControl("tb_eit_correo") as TextBox).Text = drv["Correo"].ToString();
                (e.Row.FindControl("tb_eit_telefono") as TextBox).Text = drv["Telefono"].ToString();
                (e.Row.FindControl("tb_eit_nacionalidad") as TextBox).Text = drv["Nacionalidad"].ToString();

                DropDownList ddlSexo = e.Row.FindControl("ddl_eit_sexo") as DropDownList;
                if (ddlSexo != null)
                {
                    ddlSexo.Items.Clear();
                    ddlSexo.Items.Add(new ListItem("Masculino", "Masculino"));
                    ddlSexo.Items.Add(new ListItem("Femenino", "Femenino"));
                    ddlSexo.Items.Add(new ListItem("Otro", "Otro"));

                    string sexo = drv["Sexo"]?.ToString();
                    if (!string.IsNullOrEmpty(sexo))
                    {
                        ListItem item = ddlSexo.Items.FindByValue(sexo);
                        if (item != null) item.Selected = true;
                    }
                }

               
                DropDownList ddlProvincia = e.Row.FindControl("ddl_eit_provincia") as DropDownList;
                DropDownList ddlLocalidad = e.Row.FindControl("ddl_eit_localidad") as DropDownList;

                if (ddlProvincia != null && ddlLocalidad != null)
                {
                    NegocioPacientes negocio = new NegocioPacientes();

                    negocio.CompletarDdlProvincias(ddlProvincia);

                    string provinciaIdStr = drv["ID_Provincia"]?.ToString();
                    if (!string.IsNullOrEmpty(provinciaIdStr))
                    {
                        ddlProvincia.SelectedValue = provinciaIdStr;

                        negocio.CompletarDdlLocalidades(ddlLocalidad, int.Parse(provinciaIdStr));

                        string localidadIdStr = drv["ID_Localidad"]?.ToString();
                        if (!string.IsNullOrEmpty(localidadIdStr))
                        {
                            ddlLocalidad.SelectedValue = localidadIdStr;
                        }
                    }
                }

                
                CheckBox chkEstado = e.Row.FindControl("cbx_eit_estado") as CheckBox;
                if (chkEstado != null)
                {
                    bool estado = false;
                    bool.TryParse(drv["Estado"]?.ToString(), out estado);
                    chkEstado.Checked = estado;
                }
            }
        }

        protected void gvPacientesBaja_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gvPacientesBaja.Rows[e.RowIndex];

            
            string dni = gvPacientesBaja.DataKeys[e.RowIndex].Value.ToString();

           
            string nombre = ((TextBox)row.FindControl("tb_eit_nombre")).Text;
            string apellido = ((TextBox)row.FindControl("tb_eit_apellido")).Text;
            string sexo = ((DropDownList)row.FindControl("ddl_eit_sexo")).SelectedValue;
            string nacionalidad = ((TextBox)row.FindControl("tb_eit_nacionalidad")).Text;
            string direccion = ((TextBox)row.FindControl("tb_eit_direccion")).Text;
            string correo = ((TextBox)row.FindControl("tb_eit_correo")).Text;
            string telefono = ((TextBox)row.FindControl("tb_eit_telefono")).Text;

            int idProvincia = int.Parse(((DropDownList)row.FindControl("ddl_eit_provincia")).SelectedValue);
            int idLocalidad = int.Parse(((DropDownList)row.FindControl("ddl_eit_localidad")).SelectedValue);

          

            Pacientes p = new Pacientes();
            p.SetDni_Paciente(dni);
            p.SetNombre_Paciente(nombre);
            p.SetApellido_Paciente(apellido);
            p.SetSexo_Paciente(sexo);
            p.SetNacionalidad_Paciente(nacionalidad);
            p.SetDireccion_Paciente(direccion);
            p.SetCorreo_Paciente(correo);
            p.SetTelefono_Paciente(telefono);
            p.SetIdProvincia_Paciente(idProvincia);
            p.SetIdLocalidad_Paciente(idLocalidad);
            p.SetEstado_Paciente(true);

            
            NegocioPacientes negocio = new NegocioPacientes();
            negocio.Actualizar(p);

           
            gvPacientesBaja.EditIndex = -1;
            CargarGridViewPaciente();
            LimpiarAlta();
        }

        protected void gvPacientesBaja_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvPacientesBaja.EditIndex = -1;
            CargarGridViewPaciente();
            LimpiarAlta();
        }

        protected void ddl_eit_Provincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlProvincia = sender as DropDownList;
            GridViewRow row = ddlProvincia.NamingContainer as GridViewRow;
            DropDownList ddlLocalidad = row.FindControl("ddl_eit_localidad") as DropDownList;

            if (ddlProvincia != null && ddlLocalidad != null)
            {
                int provinciaID = int.Parse(ddlProvincia.SelectedValue);
                negocio.CompletarDdlLocalidades(ddlLocalidad, provinciaID);
            }
        }

        protected void btnAlta_Click(object sender, EventArgs e)
        {
            if (!tbxAlta.Visible)
            {
                tbxAlta.Visible = true;
                tbxAlta.Focus();
                lblAlta.Text = "Ingrese DNI";
                return;

            }
            string dni = tbxAlta.Text.Trim();

            int filas = negocio.Alta(dni);
            if (filas != 0)
            {
                tbxAlta.Visible = false;
                tbxAlta.Text = string.Empty;

                lblAlta.Text = "Medico dado de alta.";
                CargarGridViewPaciente();
            }
            else
            {
                lblAlta.Text = "No se pudo dar de alta el medico";
                tbxAlta.Text = string.Empty;
            }

        }

         private void LimpiarAlta()
        {
            tbxAlta.Visible = false;
            lblAlta.Text = string.Empty;
            tbxAlta.Text=string.Empty;
        }

        protected void gvPacientesBaja_PageIndexChanging1(object sender, GridViewPageEventArgs e)
        {
            gvPacientesBaja.PageIndex = e.NewPageIndex;
            CargarGridViewPaciente();
        }
    }
    
}
