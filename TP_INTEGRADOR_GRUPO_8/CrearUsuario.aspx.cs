using Entidades;
using System;
using Negocio;
namespace TP_INTEGRADOR_GRUPO_8
{
    public partial class Resgistrarse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();

            usuario.setNombre_usuario(txtUsuario.Text.Trim());
            usuario.setContrasenia(txtContrasenia.Text.Trim());
            usuario.setRol(true);
            NegocioUsuario negocio = new NegocioUsuario();
            
            if (txtRepetirContrasenia.Text == txtContrasenia.Text)
            {
                negocio.guardarUsuario(usuario);
                lblMensaje.Text = "usuario creado correctamente.";
                Response.Redirect("~/Inicio.aspx");
            }
            else
            {
                lblMensaje.Text = "verifique la contrasenia.";
            }

        }

       
    }
}