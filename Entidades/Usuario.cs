using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuario
    {
       private int id_Usuario;
       private string Nombre_Usuario;
       private string contrasenia;
       private bool rol;


        public int getId_usuario()
        {
            return id_Usuario;
        }

        public string getNombre_usuario()
        {
            return Nombre_Usuario;
        }
        public string getContrasenia()
        {
            return contrasenia;
        }
        public bool getRol()
        {
            return rol;
        }
        public void setRol(bool rol_usuario)
        {
            rol = rol_usuario;
        }

        public void setNombre_usuario(string nombreUsuario)
        {
            Nombre_Usuario = nombreUsuario;
        }

        public void setContrasenia(string contraseniaUser)
        {
            contrasenia = contraseniaUser;
        }

        public void setId_usuario(int idUsuario)
        {
            id_Usuario = idUsuario;
        }

    }
}
