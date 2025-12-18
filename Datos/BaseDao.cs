using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Datos
{
    public class BaseDao
    {
        public void CompletarDdlProvincias(DropDownList ddlProvincia)
        {
            ddlProvincia.Items.Clear();
            ddlProvincia.Items.Add(new ListItem("---Seleccionar---", "0"));

            DataTable tabla = new AccesoDatos().CompletarDdl("SELECT * FROM Provincias ORDER BY Descripcion_Provincia");

            foreach (DataRow fila in tabla.Rows)
            {
                ddlProvincia.Items.Add(new ListItem(fila["Descripcion_Provincia"].ToString(), fila["ID_Provincia"].ToString()));
            }
        }

        public void CompletarDdlLocalidades(DropDownList ddlLocalidad, int idProvincia)
        {
            ddlLocalidad.Items.Clear();
            ddlLocalidad.Items.Add(new ListItem("---Seleccionar---", "0"));

            if (idProvincia == 0) return;

            DataTable tabla = new AccesoDatos().CompletarDdl(
                $"SELECT * FROM Localidades WHERE ID_Provincia_Localidad = {idProvincia} ORDER BY Descripcion_Localidad"
            );

            foreach (DataRow fila in tabla.Rows)
            {
                ddlLocalidad.Items.Add(
                    new ListItem(fila["Descripcion_Localidad"].ToString(), fila["ID_Localidad"].ToString())
                );
            }
        }

        public void CompletarDdlSexo(DropDownList ddlSexo)
        {
            ddlSexo.Items.Clear();
            ddlSexo.Items.Add(new ListItem("--- Seleccionar ---", "0"));
            ddlSexo.Items.Add(new ListItem("Masculino", "Masculino"));
            ddlSexo.Items.Add(new ListItem("Femenino", "Femenino"));
            ddlSexo.Items.Add(new ListItem("Otro", "Otro"));
        }
    }
}
