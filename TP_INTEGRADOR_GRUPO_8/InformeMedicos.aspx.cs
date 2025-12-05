using Negocio;
using System;
using System.Data;

namespace TP_INTEGRADOR_GRUPO_8
{
    public partial class InformeMedicos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnGenerarInforme_Click(object sender, EventArgs e)
        {
            DateTime fechaDesde = DateTime.Parse(tbxFechaDesde.Text);
            DateTime fechaHasta = DateTime.Parse(tbxFechaHasta.Text);

            NegocioMedicos negocio = new NegocioMedicos();
            DataTable tabla = negocio.ObtenerInformeMedicos(fechaDesde, fechaHasta);

            gvResultados.DataSource = tabla;
            gvResultados.DataBind();

        }
    }
}