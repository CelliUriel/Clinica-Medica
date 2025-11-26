using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Entidades
{
    internal class Usuarios
    {
        private int idUsuario;
        private char nombreUsuario;
        private char contraseniaUsuario;
        private bool rolUsuario;

        public Usuarios()
        {

        }

        public int getIdUsuario()
        {
            return idUsuario;
        }

        public void setIdUsuario(int id)
        {
            idUsuario = id;
        }

        public char getNombreUsuario()
        {
            return nombreUsuario;
        }
        
        public void setNombreUsuario(char nombre)
        {
            nombreUsuario = nombre;
        }

        public char getContraseniaUsuario()
        {
            return contraseniaUsuario;
        }

        public void setContraseniaUsuario(char contrasenia)
        {
            contraseniaUsuario = contrasenia;
        }

        public bool getRolUsuario()
        {
            return rolUsuario;
        }

        public void setRolUsuario(bool rol)
        {
            rolUsuario = rol;
        }
    }
}
