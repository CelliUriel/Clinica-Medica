using Entidades;
using Negocio;
using System;
using System.Web.UI.WebControls;
namespace TP_INTEGRADOR_GRUPO_8
{
    public partial class ABMLPaciente : System.Web.UI.Page
    {

        NegocioPacientes negocio= new NegocioPacientes();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] != null)
            {
                Usuario usuario = (Usuario)Session["Usuario"];
                lblNombre.Text = usuario.getNombre_usuario().ToString();
            }
            if (!IsPostBack)
            {
                CargarGridView();
            }
        }


        private void CargarGridView()
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
            string dni=tbxFiltro.Text.Trim();


            if (!string.IsNullOrWhiteSpace(dni))
            {
                gvPacientesBaja.DataSource = negocio.filtrarPorDniPaciente(dni);
                gvPacientesBaja.DataBind();
                tbxFiltro.Text = string.Empty;
            } else
            {

                CargarGridView();
            }
        }
    }
}