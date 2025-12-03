using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;


namespace TP_INTEGRADOR_GRUPO_8
{
    public partial class BajaPaciente : System.Web.UI.Page
    {
        NegocioMedicos negocio = new NegocioMedicos();

        protected void Page_Load(object sender, EventArgs e)
        {

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


        protected void gvMedicosBaja_RowCommand(object sender, GridViewCommandEventArgs e)
        {
           
        }

        // 2. MÉTODO PARA MANEJAR LA PAGINACIÓN (OnPageIndexChanging)
        protected void gvMedicosBaja_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
          
        }

        
        protected void gvMedicosBaja_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            string dni = tbxFiltrar.Text.Trim();

            if (!string.IsNullOrEmpty(dni))
            {
                gvMedicosBaja.DataSource = negocio.BuscarPorDNI(dni);
                gvMedicosBaja.DataBind();
            }
            else
            {
                CargarGridMedicos();
            }
        }

        protected void gvMedicosBaja_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }
    }
}