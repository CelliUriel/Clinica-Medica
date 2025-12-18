using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_INTEGRADOR_GRUPO_8
{
    public partial class PanelMedico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] != null)
            {
                Usuario usuario = (Usuario)Session["Usuario"];
                lblUsuarioRol.Text = "Bienvenido doctor "+usuario.getNombre_usuario()+", seleccione una opción";
            }
        }

        protected void btnTurnos_Click(object sender, EventArgs e)
        {

        }
    }
}