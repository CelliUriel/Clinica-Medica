using Entidades;
using Negocio;
using System;
using System.Data;

namespace TP_INTEGRADOR_GRUPO_8
{
    public partial class InformePacientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] != null)
            {
                Usuario usuario = (Usuario)Session["Usuario"];
                LblNombre.Text = "Usuario logueado: "+usuario.getNombre_usuario().ToString();
            }
        }

        protected void BtnGenerarInforme_Click(object sender, EventArgs e)
        {
            DateTime fechaDesde = DateTime.Parse(tbxFechaDesde.Text);
            DateTime fechaHasta = DateTime.Parse(tbxFechaHasta.Text);
            NegocioTurnos negocioTurnos = new NegocioTurnos();

            gvAusentes.DataSource = negocioTurnos.ListarTurnoPorFechaAusentes(fechaDesde, fechaHasta);
            gvAusentes.DataBind();

            gvPresentes.DataSource = negocioTurnos.ListarTurnoPorFechaPresentes(fechaDesde, fechaHasta);
            gvPresentes.DataBind();

            int cantAusentes = negocioTurnos.TotalTurnosAusentes(fechaDesde, fechaHasta);
            int cantPresentes = negocioTurnos.TotalTurnosPresentes(fechaDesde, fechaHasta);

            int pacientesTotales = cantAusentes + cantPresentes;
            float porcentajeTasaPresentismo = ((float)cantPresentes * 100) / pacientesTotales;
            float porcentajeTasaAusentismo = ((float)cantAusentes * 100) / pacientesTotales;

            lblTotalTurnos.Text = pacientesTotales.ToString();
            lblPorcentajePresentes.Text = porcentajeTasaPresentismo.ToString() + "%";
            lblPorcentajeAusentes.Text = porcentajeTasaAusentismo.ToString() + "%";

            LimpiarCampo();
        }

        private void LimpiarCampo()
        {
            tbxFechaDesde.Text = string.Empty;
            tbxFechaHasta.Text = string.Empty;
        }
    }
}