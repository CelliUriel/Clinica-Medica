using Entidades;
using Negocio;
using System;

namespace TP_INTEGRADOR_GRUPO_8
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            string nombre = tbNombreDeUsuario.Text.Trim();
            string pass = tbContraseniaDeUsuario.Text.Trim();

            NegocioUsuario negocio = new NegocioUsuario();

            Usuario u = negocio.IniciarSesion(nombre, pass);

            if (u == null)
            {
                lblMensaje.Text = "Usuario o contraseña incorrectos.";
                return;
            }

            Session["Usuario"] = u;

            if (u.getRol())    
            {
                Response.Redirect("~/MenuAdminstrador.aspx");
            }
            if (u.getRol()== false)
            {
                Response.Redirect("~/PanelMedico.aspx");
            }

        }
    }
}