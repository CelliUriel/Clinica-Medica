using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DaoTurnos
    {
        static readonly AccesoDatos ds = new AccesoDatos();
        readonly SqlConnection conexion = ds.ObtenerConexion();
        readonly SqlParameter SqlParametros = new SqlParameter();

        public int InsertarTurno(Turnos turno)
        {
            string consulta = "INSERT INTO Turnos " +
                "(DNI_Paciente_Turno, Id_Medico_Turno, Codigo_Especialidad_Turno, Fecha_Turno, Hora_Turno, Estado_Turno, Observacion_Turno) " + "VALUES (@dni, @medico, @especialidad, @fecha, @hora, @estado, @obs)";

            SqlConnection cn = ds.ObtenerConexion();
            cn.Open();

            SqlCommand cmd = new SqlCommand(consulta, cn);

            cmd.Parameters.AddWithValue("@dni", turno.GetDNI_Paciente_Turno());
            cmd.Parameters.AddWithValue("@medico", turno.GetId_Medico_Turno());
            cmd.Parameters.AddWithValue("@especialidad", turno.GetCodigo_Especialidad_Turno());
            cmd.Parameters.AddWithValue("@fecha", turno.GetFecha_Turno());
            cmd.Parameters.AddWithValue("@hora", turno.GetHora_Turno());
            cmd.Parameters.AddWithValue("@estado", turno.GetEstado_Turno());
            cmd.Parameters.AddWithValue("@obs", turno.GetObservacion_Turno());

            int filas = cmd.ExecuteNonQuery();
            cn.Close();

            return filas;
        }

        public DataTable ListarTurnos()
        {
            string consultaSQL =
                "SELECT " +
                "T.Fecha_Turno AS Fecha, " +
                "T.Hora_Turno AS Hora, " +
                "(P.Apellido_Paciente + ' ' + P.Nombre_Paciente) AS Paciente, " +
                "T.Estado_Turno AS Estado, " +
                "T.Observacion_Turno AS Observaciones " +
                "FROM Turnos T " +
                "JOIN Pacientes P ON T.DNI_Paciente_Turno = P.DNI_Paciente " +
                "ORDER BY T.Fecha_Turno, T.Hora_Turno";

            return ds.ObtenerTabla(consultaSQL);
        }
    }
}
