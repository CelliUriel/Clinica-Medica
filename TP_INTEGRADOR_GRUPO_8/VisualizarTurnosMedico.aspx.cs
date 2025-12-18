using Entidades;
using Negocio;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_INTEGRADOR_GRUPO_8
{
    public partial class VisualizarTurnosMedico : System.Web.UI.Page
    {
        NegocioTurnos turnos = new NegocioTurnos();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] != null)
            {
                Usuario usuario = (Usuario)Session["Usuario"];
                lblNombreMedico.Text = "Nombre Medico:"+usuario.getNombre_usuario();
                
            }

            if (!IsPostBack)
            {
              //  turnos.ListarTurnos();
                CargarGridTurnos();
            }
        }
        private void CargarGridTurnos()
        {
            if (Session["Usuario"] != null)
            {
                NegocioMedicos negocio = new NegocioMedicos();

                Usuario usuario = (Usuario)Session["Usuario"];
                 
                gvTurnos.DataSource = turnos.ListarTurnos(usuario.getId_usuario());
                gvTurnos.DataBind();
            }
            else
            {
                lblNombreMedico.Text = "Ingreso sin usuario";
            }
        }

        protected void gvTurnos_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            gvTurnos.EditIndex = e.NewEditIndex;
            CargarGridTurnos();
        }

        protected void gvTurnos_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            gvTurnos.EditIndex = -1;
            CargarGridTurnos();
        }

        protected void gvTurnos_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            string estado = ((DropDownList)gvTurnos.Rows[e.RowIndex].FindControl("ddlEstado")).SelectedValue;
            string observacion = ((TextBox)gvTurnos.Rows[e.RowIndex].FindControl("tb_eit_observaciones")).Text;
            int idTurno = Convert.ToInt32(gvTurnos.DataKeys[e.RowIndex].Value);
            Turnos t = new Turnos();
            t.SetEstado_Turno(estado);
            t.SetObservacion_Turno(observacion);
            t.SetID_Turno(idTurno);
            turnos.ActualizarTurno(t);
            gvTurnos.EditIndex = -1;
            CargarGridTurnos();
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
           // Usuario usuario = (Usuario)Session["Usuario"];

            string estado = ddlEstado.SelectedValue.Trim();

         
                DateTime? fecha = null;
           

            if (!string.IsNullOrWhiteSpace(tbFecha.Text))
            {
                DateTime f;
                if (!DateTime.TryParse(tbFecha.Text, out f))
                {
                    lblMensaje.Text = "La fecha ingresada no es válida.";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                fecha = f;
            }

            if (fecha.HasValue || ddlEstado.SelectedIndex > 0)
            {
                if (Session["Usuario"] != null)
                {
                    Usuario usuario = (Usuario)Session["Usuario"];
                    gvTurnos.DataSource = turnos.FiltroTurnos(fecha, estado, usuario.getId_usuario());
                    gvTurnos.DataBind();
                    tbFecha.Text = string.Empty;
                    ddlEstado.SelectedIndex = 0;

                }
            } else
            {
                CargarGridTurnos();
            }
        }

        protected void ddlEstado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvTurnos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && (e.Row.RowState & DataControlRowState.Edit) > 0)
            {
                DropDownList ddlEstado = (DropDownList)e.Row.FindControl("ddlEstado");
                if (ddlEstado != null)
                {
                    ddlEstado.Items.Clear();
                    ddlEstado.Items.Add(new ListItem("Pendiente", "Pendiente"));
                    ddlEstado.Items.Add(new ListItem("Presente", "Presente"));
                    ddlEstado.Items.Add(new ListItem("Ausente", "Ausente"));

                    // Seleccionar el valor actual del turno
                    string estadoActual = DataBinder.Eval(e.Row.DataItem, "Estado").ToString();
                    ddlEstado.SelectedValue = estadoActual;
                }
            }
        }
    }

}