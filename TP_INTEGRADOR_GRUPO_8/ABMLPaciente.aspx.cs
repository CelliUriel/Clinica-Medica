using System;
using System.Web.UI.WebControls;
using Negocio;
namespace TP_INTEGRADOR_GRUPO_8
{
    public partial class ABMLPaciente : System.Web.UI.Page
    {

        readonly NegocioPacientes negocio= new NegocioPacientes();
        protected void Page_Load(object sender, EventArgs e)
        {

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

        protected void GvPacientesBaja_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }
        protected void GvPacientesBaja_RowCommand(object sender, GridViewCommandEventArgs e)
        {



        }


        protected void GvPacientesBaja_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void BtnFiltrarPaciente_Click(object sender, EventArgs e)
        {
            string dni=tbxFiltro.Text.Trim();


            if (!string.IsNullOrWhiteSpace(dni))
            {
                gvPacientesBaja.DataSource = negocio.FiltrarPorDniPaciente(dni);
                gvPacientesBaja.DataBind();
                tbxFiltro.Text = string.Empty;
            } else
            {

                CargarGridView();
            }
        }
    }
}