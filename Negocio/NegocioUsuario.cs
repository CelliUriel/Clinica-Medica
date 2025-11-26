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
        DaoUsuario daoUsuario = new DaoUsuario();

        public bool guardarUsuario(Usuario usuario)
        {
            return daoUsuario.InsertarUsuario(usuario);
        }

        public Usuario IniciarSesion(string nombreUsuario, string contrasenia)
        {
            return daoUsuario.InicioSesion(nombreUsuario, contrasenia);
        }

        public int CrearUsuarioYDevolverID(Usuario usuario)
        {
            DaoUsuario daoUsuario = new DaoUsuario();
            return daoUsuario.InsertarUsuarioYDevolverID(usuario);
        }


    }
}