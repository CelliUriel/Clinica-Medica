using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioUsuario
    {
        readonly DaoUsuarios daoUsuario = new DaoUsuarios();

        public bool GuardarUsuario(Usuario usuario)
        {
            return daoUsuario.InsertarUsuario(usuario);
        }

        public Usuario IniciarSesion(string nombreUsuario, string contrasenia)
        {
            return daoUsuario.InicioSesion(nombreUsuario, contrasenia);
        }

        public int CrearUsuarioYDevolverID(Usuario usuario)
        {
            DaoUsuarios daoUsuario = new DaoUsuarios();
            return daoUsuario.InsertarUsuarioYDevolverID(usuario);
        }

        public bool usuarioExistente(string usuario)
        {
            return (daoUsuario.ExisteUsuario(usuario));
             
        }

        public int ValidarLogin(string usuario, string pass)
        {  
            if (!daoUsuario.ExisteUsuario(usuario))
                return 0; // Usuario inexistente

            if (!daoUsuario.ContraseniaCorrectaLogin(usuario, pass))
                return 1; // Contraseña incorrecta

            return 2; // Todo correcto
        }
    }
}