using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace Datos
{
    public class DaoMedicos
    {
        AccesoDatos ds = new AccesoDatos();
        public void completarDdlProvincias(DropDownList ddlProvincias)
        {
            SqlDataReader sqlDataReader = ds.completarDdl("SELECT * FROM Provincia");

            ddlProvincias.DataSource = sqlDataReader;
            ddlProvincias.DataTextField = "Descripcion_Provincia";
            ddlProvincias.DataValueField = "id_Provincia";
            ddlProvincias.DataBind();

            ddlProvincias.Items.Insert(0, new ListItem("--- Seleccionar ---", "0"));

        }

        public DataTable ListarMedicos()
        {
            string consultaSQL =
                "SELECT " +
                "M.DNI_Medico AS DNI, " +
                "M.Nombre_Medico AS Nombre, " +
                "M.Apellido_Medico AS Apellido, " +
                "M.Telefono_Medico AS Telefono, " +
                "M.Estado_Medico AS Estado, " +
                "E.Nombre_Especialidad AS Especialidad " +
                "FROM Medicos M INNER JOIN Especialidades E ON M.Codigo_Especialidad_Medico = E.Codigo_Especialidad";

            return ds.ObtenerTabla(consultaSQL);
        }

        public DataTable FiltrarMedicoPorDNI(int dniMedico)
        {
            string consultaSQL =
                "SELECT " +
                "M.DNI_MEDICO AS DNI, " +
                "M.Nombre_Medico AS Nombre, " +
                "M.Apellido_Medico AS Apellido, " +
                "M.Telefono_Medico AS Telefono, " +
                "M.Estado_Medico AS Estado " +
                "E.Nombre_Especialidad AS Especialidad" +
                "FROM Medicos M INNER JOIN Especialidades E ON M.Codigo_Especialidad_Medico=E.Codigo_Especialidad" +
                $"WHERE M.DNI_MEDICO = {dniMedico}";

            return ds.ObtenerTabla(consultaSQL);
        }

        public DataTable FiltrarMedicoPorID(string id)
        {
            string consultaSQL =
                 "SELECT " +
                 "M.ID_MEDICO AS ID, " +
                "M.DNI_MEDICO AS DNI, " +
                "M.Nombre_Medico AS Nombre, " +
                "M.Apellido_Medico AS Apellido, " +
                "M.Telefono_Medico AS Telefono, " +
                "M.Estado_Medico AS Estado, " +
                "E.Nombre_Especialidad AS Especialidad" +
                "FROM Medicos M INNER JOIN Especialidades E ON M.Codigo_Especialidad_Medico=E.Codigo_Especialidad" +
                $"WHERE M.ID_MEDICO = {id}";



            return ds.ObtenerTabla(consultaSQL);
        }

        private void ArmarParametrosEliminarMedico(ref SqlCommand Comando, Medicos medico)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@IdMedico", SqlDbType.Int);
            SqlParametros.Value = medico.IdMedico;
        }

        public bool EliminarMedico(Medicos medico)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            SqlConnection conexion = accesoDatos.ObtenerConexion();

            SqlCommand sqlCommand = new SqlCommand();

            ArmarParametrosEliminarMedico(ref sqlCommand, medico);

            int FilasInsertadas = accesoDatos.EjecutarComando("DELETE FROM Medicos WHERE ID_Medico = @IdMedico");
            if (FilasInsertadas == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public DataTable BuscarMedicoPorDNI(string dni)
        {
            string consulta = "SELECT * FROM Medicos WHERE DNI_Medicos = @dni";

            SqlCommand cmd = new SqlCommand(consulta);
            cmd.Parameters.AddWithValue("@dni", dni);

            AccesoDatos ds = new AccesoDatos();
            return ds.ObtenerTabla("Medicos", cmd);
        }

    }
}
