using System;
using Negocio;
using Entidades;

namespace TP_INTEGRADOR_GRUPO_8
{
    public partial class VisualizarTurnosMedico : System.Web.UI.Page
    {
        NegocioTurnos turnos = new NegocioTurnos();
        
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                turnos.ListarTurnos();
                CargarGridTurnos();
            }
        }
        private void CargarGridTurnos()
        {
            gvTurnos.DataSource = turnos.ListarTurnos();
            gvTurnos.DataBind();
        }
    }
}