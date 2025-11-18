using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    internal class Localidades
    {
        private int id_localidad;
        private string descripcion_localidad;
        private int id_provincia_localidad;
        
        public int getId_localidad ()
        {
            return id_localidad;
        }
        public void setId_localidad (int idLocalidad)
        {
            id_localidad = idLocalidad;
        }
        public string getDescripcion_localidad ()
        {
            return descripcion_localidad;
        }
        public void setDescripcion_localidad (string descripcionLocalidad)
        {
            descripcion_localidad = descripcionLocalidad;
        }

        public int getId_provincia_localidad ()
        {
            return id_provincia_localidad;
        }
        public void setId_provincia_localidad(int idProvinciaLocalidad)
        {
            id_provincia_localidad = idProvinciaLocalidad;
        }
    }
}
