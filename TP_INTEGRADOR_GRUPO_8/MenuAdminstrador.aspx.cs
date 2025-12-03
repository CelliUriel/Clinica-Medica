using Entidades;
using System;

namespace TP_INTEGRADOR_GRUPO_8
{
    public partial class UsuarioAdminstrador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"]!=null)
            {


                Usuario usuario = (Usuario)Session["Usuario"];

                lbNombre.Text =usuario.getNombre_usuario();
               
            
            
            
            }
        }

      
    }
}