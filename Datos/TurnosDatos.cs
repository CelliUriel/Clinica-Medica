using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Datos
{
    public class TurnosDatos
    {
        AccesoDatos acceso = new AccesoDatos();

        public int InsertarTurno(Turnos turno)
        {
            string consulta = "INSERT INTO Turnos " +
                "(DNI_Paciente_Turno, Id_Medico_Turno, Codigo_Especialidad_Turno, Fecha_Turno, Hora_Turno, Estado_Turno, Observacion_Turno) " + "VALUES (@dni, @medico, @especialidad, @fecha, @hora, @estado, @obs)";

            SqlConnection cn = acceso.ObtenerConexion();
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
    }
}
