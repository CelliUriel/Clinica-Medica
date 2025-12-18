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

        protected void BtnIniciarSesion_Click(object sender, EventArgs e)
        {
            string nombre = tbNombreDeUsuario.Text.Trim();
            string pass = tbContraseniaDeUsuario.Text.Trim();

            NegocioUsuario negocio = new NegocioUsuario();
            

            int estado = negocio.ValidarLogin(nombre,pass);
          
            if (estado == 0)
            {
               lblMensaje.Text = "Usuario inexistente";
               
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                LimpiarCampos();
                return;
            }

            if (estado == 1)
            {
                lblMensaje.Text = "Contraseña incorrecta";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                LimpiarCampos();
                return;
            }

            Usuario u = negocio.IniciarSesion(nombre, pass);

            Session["Usuario"] = u;
            LimpiarCampos();
            if (u.getRol())
                Response.Redirect("~/MenuAdminstrador.aspx");
            else
                Response.Redirect("~/PanelMedico.aspx");
        }
    
        private void LimpiarCampos()
        {
            tbContraseniaDeUsuario.Text = string.Empty;
            tbNombreDeUsuario.Text = string.Empty;
           
        }
    
    
    }        
}