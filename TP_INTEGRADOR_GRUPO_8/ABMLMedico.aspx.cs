using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace TP_INTEGRADOR_GRUPO_8
{
    public partial class BajaPaciente : System.Web.UI.Page
    {
        readonly NegocioMedicos negocio = new NegocioMedicos();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] != null)
            {
                Usuario usuario = (Usuario)Session["Usuario"];
                lblNombre.Text = usuario.getNombre_usuario().ToString();
            }
            if (!IsPostBack)
            {
                CargarGridMedicos();
            }

          
        }

        private void CargarGridMedicos()
        {
            gvMedicosBaja.DataSource = negocio.ListarMedicos();
            gvMedicosBaja.DataBind();
            
        }
        
        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            string dni = tbxFiltrar.Text.Trim();

            LimpiarAlta();
            if (!string.IsNullOrEmpty(dni))
            {
                gvMedicosBaja.DataSource = negocio.BuscarPorDNI(dni);
                gvMedicosBaja.DataBind();
                tbxFiltrar.Text = string.Empty;


            }
            else
            {

                CargarGridMedicos();
            }
        }

        protected void gvMedicosBaja_RowEditing(object sender, GridViewEditEventArgs e)
        {
            LimpiarAlta();
            gvMedicosBaja.EditIndex = e.NewEditIndex;
            CargarGridMedicos();
        }

        protected void gvMedicosBaja_RowDataBound(object sender, GridViewRowEventArgs e)
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
                                    $"return confirm('¿Eliminar al médico {nombre} {apellido}?');";
                            }
                        }
                    }
                }
            }



            if (e.Row.RowType == DataControlRowType.DataRow && (e.Row.RowState & DataControlRowState.Edit) > 0)
            {
                DataRowView drv = e.Row.DataItem as DataRowView;
                if (drv == null) return;

                TextBox tbNombre = e.Row.FindControl("tb_eit_nombre") as TextBox;
                TextBox tbApellido = e.Row.FindControl("tb_eit_apellido") as TextBox;
                if (tbNombre != null) tbNombre.Text = drv["Nombre"].ToString();
                if (tbApellido != null) tbApellido.Text = drv["Apellido"].ToString();

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
                    NegocioMedicos negocio = new NegocioMedicos();
                    negocio.CompletarDdlProvincias(ddlProvincia);
                    string provinciaIdStr = drv["ID_Provincia"]?.ToString();
                    int idProvincia = 0;
                    int.TryParse(provinciaIdStr, out idProvincia);
                    if (idProvincia > 0)
                    {
                        ddlProvincia.SelectedValue = provinciaIdStr;
                        negocio.CompletarDdlLocalidades(ddlLocalidad, idProvincia);
                        string localidadIdStr = drv["ID_Localidad"]?.ToString();
                        if (!string.IsNullOrEmpty(localidadIdStr))
                        {
                            ddlLocalidad.SelectedValue = localidadIdStr;
                        }
                    }
                }

                CheckBoxList chkDias = e.Row.FindControl("chkbx_eit_dias") as CheckBoxList;
                if (chkDias != null)
                {
                    string dias = drv["DiasAtencion"]?.ToString();
                    if (!string.IsNullOrEmpty(dias))
                    {
                        string[] diasArray = dias.Split(',');
                        foreach (string d in diasArray)
                        {
                            ListItem li = chkDias.Items.FindByText(d.Trim());
                            if (li != null) li.Selected = true;
                        }
                    }
                }

                DropDownList ddlHoraInicio = e.Row.FindControl("ddl_eit_horaInicio") as DropDownList;
                DropDownList ddlHoraFin = e.Row.FindControl("ddl_eit_HoraFin") as DropDownList;
                if (ddlHoraInicio != null && ddlHoraFin != null)
                {
                    NegocioMedicos negocio = new NegocioMedicos();
                    negocio.CompletarDdlHoras(ddlHoraInicio);
                    negocio.CompletarDdlHoras(ddlHoraFin);
                    string horario = drv["HorarioAtencion"]?.ToString();
                    if (!string.IsNullOrEmpty(horario))
                    {
                        string[] partes = horario.Split('-');
                        if (partes.Length == 2)
                        {
                            ListItem inicio = ddlHoraInicio.Items.FindByValue(partes[0].Trim());
                            if (inicio != null) inicio.Selected = true;
                            ListItem fin = ddlHoraFin.Items.FindByValue(partes[1].Trim());
                            if (fin != null) fin.Selected = true;
                        }
                    }
                }

                DropDownList ddlEspecialidad = e.Row.FindControl("ddl_eit_especialidad") as DropDownList;
                if (ddlEspecialidad != null)
                {
                    NegocioMedicos negocio = new NegocioMedicos();
                    negocio.CompletarDdlEspecialidades(ddlEspecialidad);
                    string idEspecialidad = drv["ID_Especialidad"]?.ToString();
                    if (!string.IsNullOrEmpty(idEspecialidad))
                    {
                        ListItem item = ddlEspecialidad.Items.FindByValue(idEspecialidad);
                        if (item != null) item.Selected = true;
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

        protected void gvMedicosBaja_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            LimpiarAlta();
            gvMedicosBaja.EditIndex = -1;
            CargarGridMedicos();
        }

        protected void ddl_eit_provincia_SelectedIndexChanged(object sender, EventArgs e)
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

        protected void gvMedicosBaja_RowUpdating1(object sender, GridViewUpdateEventArgs e)
        {
            //ONTENER EL CONTENIDO DE LOS CONTROLES
            string dni = ((Label)gvMedicosBaja.Rows[e.RowIndex].FindControl("lbl_eit_dni")).Text;
            string nombre = ((TextBox)gvMedicosBaja.Rows[e.RowIndex].FindControl("tb_eit_nombre")).Text;
            string apellido = ((TextBox)gvMedicosBaja.Rows[e.RowIndex].FindControl("tb_eit_apellido")).Text;
            string sexo = ((DropDownList)gvMedicosBaja.Rows[e.RowIndex].FindControl("ddl_eit_sexo")).SelectedValue;
            string nacionalidad = ((TextBox)gvMedicosBaja.Rows[e.RowIndex].FindControl("tb_eit_nacionalidad")).Text;
            string direccion = ((TextBox)gvMedicosBaja.Rows[e.RowIndex].FindControl("tb_eit_direccion")).Text;
            string correo = ((TextBox)gvMedicosBaja.Rows[e.RowIndex].FindControl("tb_eit_correo")).Text;
            string telefono = ((TextBox)gvMedicosBaja.Rows[e.RowIndex].FindControl("tb_eit_telefono")).Text;
            CheckBoxList cb = ((CheckBoxList)gvMedicosBaja.Rows[e.RowIndex].FindControl("chkbx_eit_dias"));
            DropDownList ddlInicio = ((DropDownList)gvMedicosBaja.Rows[e.RowIndex].FindControl("ddl_eit_horaInicio"));
            DropDownList ddlFin = ((DropDownList)gvMedicosBaja.Rows[e.RowIndex].FindControl("ddl_eit_HoraFin"));
            string especialidad = ((DropDownList)gvMedicosBaja.Rows[e.RowIndex].FindControl("ddl_eit_especialidad")).SelectedValue;

            int localidad = int.Parse(((DropDownList)gvMedicosBaja.Rows[e.RowIndex].FindControl("ddl_eit_localidad")).SelectedValue);
            int provincia = int.Parse(((DropDownList)gvMedicosBaja.Rows[e.RowIndex].FindControl("ddl_eit_provincia")).SelectedValue);
           
            string dias =ObtenerDias(cb) ;
            string horario = ddlInicio.SelectedValue + " - " +ddlFin.SelectedValue;
            Medicos m = new Medicos();
            m.SetDniMedico(dni);
            m.SetNombre_Medico(nombre);
            m.SetApellido_Medico(apellido);
            m.SetSexo_Medico(sexo);
            m.SetNacionalidad_Medico(nacionalidad);
            m.SetDireccion_Medico(direccion);
            m.SetCorreo_Medico(correo);
            m.SetTelefono_Medico(telefono);
            m.SetDiasAtencion_Medico(dias);
            m.SetHorariosAtencion_Medico(horario);
            m.SetCodigo_Especialidad_Medico(Convert.ToInt32(especialidad));
            m.SetId_Provincia_Medico(provincia);
            m.SetId_Localidad_Medico(localidad);
            m.SetEstado_Medico(true);

            NegocioMedicos gm = new NegocioMedicos();
            gm.ActualizarMedico(m);
      

            LimpiarAlta();
            gvMedicosBaja.EditIndex = -1;
            CargarGridMedicos();

        }

        protected void gvMedicosBaja_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Eliminar")
            {
                int idMedico = Convert.ToInt32(e.CommandArgument);
                Medicos m = new Medicos();
                m.SetId_Medico(idMedico);

                bool exito = negocio.EliminarMedico(m);
                if (exito)
                {
                    CargarGridMedicos();
                }
            }
            LimpiarAlta();
        }

        protected void gvMedicosBaja_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
           // int idMedico = Convert.ToInt32(gvMedicosBaja.DataKeys[e.RowIndex].Value);
            string id=((Label)gvMedicosBaja.Rows[e.RowIndex].FindControl("lbl_it_idMedicos")).Text;
            int idMedico=Convert.ToInt32(id);
            Medicos medico = new Medicos();
            medico.SetId_Medico(idMedico);

            negocio.EliminarMedico(medico);

            CargarGridMedicos();
            LimpiarAlta();
        }

        protected void btnAlta_Click(object sender, EventArgs e)
        {
            if (!tbAlta.Visible)
            {
                tbAlta.Visible = true;
                tbAlta.Focus();
                Label1.Text = "Ingrese DNI";
                return;

            }
            string dni = tbAlta.Text.Trim();

            int filas = negocio.Alta(dni);
            if (filas != 0)
            {
                tbAlta.Visible = false;
                tbAlta.Text = string.Empty;

                Label1.Text = "Medico dado de alta.";
                CargarGridMedicos();
            }
            else
            {
                Label1.Text = "No se pudo dar de alta el medico";
                tbAlta.Text=string.Empty;
            }
        
        }
   
        private string ObtenerDias(CheckBoxList cb)
        {
            string dias = "";
            foreach (ListItem item in cb.Items)
            {
                if (item.Selected)
                {
                    dias += item.Text + ",";   
                }
            }
            if (dias.EndsWith(","))
            {
               dias= dias.TrimEnd(',');
            }

            return dias;
        }

       


        private void LimpiarAlta()
        {
            tbAlta.Visible = false;
            Label1.Text = string.Empty;
        }

        protected void gvMedicosBaja_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvMedicosBaja.PageIndex = e.NewPageIndex;
            CargarGridMedicos();
        }

        protected void gvMedicosBaja_RowCreated(object sender, GridViewRowEventArgs e)
        {
           
        }
    }
}