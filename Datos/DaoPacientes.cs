using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Entidades;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;


namespace Datos
{
    public class DaoPacientes
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
        public DataTable ListarPacientes()
        {
            string consultaSQL = "SELECT " +
                "P.DNI_Paciente AS DNI," +
                "P.Nombre_Paciente AS Nombre, " +
                "P.Apellido_Paciente AS Apellido, " +
                "P.Sexo_Paciente AS Sexo, " +
                "P.Nacionalidad_Paciente AS Nacionalidad, " +
                "P.FechaNacimiento_Paciente AS Fecha, " +
                "P.Direccion_Paciente AS Direccion, " +
                "P.ID_Localidad_Paciente AS Localidad, " +
                "P.ID_Provincia_Paciente AS Provincia, " +
                "P.Correo_Paciente AS Correo, " +
                "P.Telefono_Paciente AS Telefono," +
                "P.Estado_Paciente AS Estado " +
                 "FROM Pacientes P";




            return ds.ObtenerTabla(consultaSQL);

        }
        public DataTable FiltrarPacientesPorDNI(string dni)
        {
            string consultaSQL = "SELECT " +
                "P.DNI_Paciente AS DNI," +
                "P.Nombre_Paciente AS Nombre, " +
                "P.Apellido_Paciente AS Apellido, " +
                "P.Sexo_Paciente AS Sexo, " +
                "P.Nacionalidad_Paciente AS Nacionalidad, " +
                "P.FechaNacimiento_Paciente AS Fecha, " +
                "P.Direccion_Paciente AS Direccion, " +
                "P.ID_Localidad_Paciente AS Localidad, " +
                "P.ID_Provincia_Paciente AS Provincia, " +
                "P.Correo_Paciente AS Correo, " +
                "P.Telefono_Paciente AS Telefono," +
                "P.Estado_Paciente AS Estado " +
                 "FROM Pacientes P" +
                 $"WHERE P.DNI_Paciente={dni}";




            return ds.ObtenerTabla(consultaSQL);

        }
        private void ArmarParametrosEliminarPaciente(ref SqlCommand Comando, Pacientes pacientes)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@DNIPaciente", SqlDbType.Char, 8);
            SqlParametros.Value = pacientes.Dni_Paciente;
            SqlParameter estadoParam = Comando.Parameters.Add("@EstadoNuevo", SqlDbType.Bit);
            estadoParam.Value = false;
        }



        public bool EliminarPaciente(Pacientes pacientes)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            SqlConnection conexion = accesoDatos.ObtenerConexion();

            SqlCommand sqlCommand = new SqlCommand();

            ArmarParametrosEliminarPaciente(ref sqlCommand, pacientes);
            string consultaEliminar = "UPDATE Pacientes SET Estado_Paciente  = @EstadoNuevo WHERE DNI_Paciente = @DNIPaciente";
            int FilasInsertadas = accesoDatos.EjecutarComando(consultaEliminar);
            if (FilasInsertadas == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
