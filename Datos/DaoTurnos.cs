using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Reflection.Emit;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

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

        
        public DataTable ListarTurnos(int idUsuario)
        {

                string consultaSQL =
                                 "SELECT " +
                                 "T.ID_Turno, " +
                                 "T.Fecha_Turno AS Fecha, " +
                                 "T.Hora_Turno AS Hora, " +
                                 "(P.Apellido_Paciente + ' ' + P.Nombre_Paciente) AS Paciente, " +
                                 "T.Estado_Turno AS Estado, " +
                                 "T.Observacion_Turno AS Observaciones " +
                                 "FROM Turnos T " +
                                 "INNER JOIN Pacientes P ON T.DNI_Paciente_Turno = P.DNI_Paciente " +
                                 "INNER JOIN Medicos M ON T.id_Medico_Turno=M.ID_Medico " +
                                 "WHERE M.ID_Usuario = @id " +
                                 " ORDER BY T.Fecha_Turno, T.Hora_Turno";
                SqlCommand cmd = new SqlCommand(consultaSQL);
                cmd.Parameters.AddWithValue("@id", idUsuario);
                return ds.ObtenerTabla("Turnos", cmd);
            
        }


        public DataTable FiltroEstadoYFecha(DateTime? fecha,string estado,int id)
        {
            using (SqlConnection conn = ds.ObtenerConexion())
            {
                conn.Open();
                string consultaSQL =
                    "SELECT " +
                    "T.ID_Turno, " +
                    "T.Fecha_Turno AS Fecha, " +
                    "T.Hora_Turno AS Hora, " +
                    "(P.Apellido_Paciente + ' ' + P.Nombre_Paciente) AS Paciente, " +
                    "T.Estado_Turno AS Estado, " +
                    "T.Observacion_Turno AS Observaciones " +
                    "FROM Turnos T " +
                    "INNER JOIN Pacientes P ON T.DNI_Paciente_Turno = P.DNI_Paciente " +
                    "INNER JOIN Medicos M ON T.ID_Medico_Turno = M.ID_Medico " +
                    "WHERE M.ID_Usuario = @id ";


                if (fecha.HasValue)
                {
                    consultaSQL += "AND Fecha_Turno=@Fecha";
                   
                }
                
                if (estado != "Todos")
                {
                    consultaSQL += " AND Estado_Turno=@Estado";
                    
                }
                consultaSQL += " ORDER BY T.Fecha_Turno, T.Hora_Turno";

                SqlCommand cmd = new SqlCommand(consultaSQL, conn);
                cmd.Parameters.AddWithValue("@id", id);
                if (fecha.HasValue)
                {
                    cmd.Parameters.AddWithValue("@Fecha", fecha);
                }
                if (estado != "Todos")
                {
                    cmd.Parameters.AddWithValue("@Estado", estado);
                }


                conn.Close();

                return ds.ObtenerTabla("Turnos", cmd); ;
            }

            
        }

        public DataTable ListarTurnoPorFechaPresentes(DateTime desde, DateTime hasta)
        {
            string consultaSQL = "SELECT Nombre_Paciente + ' ' + Apellido_Paciente AS 'Nombre completo'," +
                                 "DNI_Paciente, Fecha_Turno FROM Turnos JOIN Pacientes ON DNI_Paciente = " +
                                 $"DNI_Paciente_Turno WHERE Fecha_Turno BETWEEN @Desde AND @Hasta " +
                                 "AND Estado_Turno = 'Presente'";

            conexion.Open();
            SqlCommand comandoSQL = new SqlCommand(consultaSQL, conexion);
            comandoSQL.Parameters.AddWithValue("@Desde", desde);
            comandoSQL.Parameters.AddWithValue("@Hasta", hasta);
            DataTable tabla = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(comandoSQL);
            adapter.Fill(tabla);
            conexion.Close();

            return tabla;
        }

        public DataTable ListarTurnoPorFechaAusentes(DateTime desde, DateTime hasta)
        {
            string consultaSQL = "SELECT Nombre_Paciente + ' ' + Apellido_Paciente AS 'Nombre completo'," +
                                 "DNI_Paciente, Fecha_Turno FROM Turnos JOIN Pacientes ON DNI_Paciente = " +
                                 $"DNI_Paciente_Turno WHERE Fecha_Turno BETWEEN @Desde AND @Hasta " +
                                 "AND Estado_Turno = 'Ausente'";

            conexion.Open();
            SqlCommand comandoSQL = new SqlCommand(consultaSQL, conexion);
            comandoSQL.Parameters.AddWithValue("@Desde", desde);
            comandoSQL.Parameters.AddWithValue("@Hasta", hasta);
            DataTable tabla = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(comandoSQL);
            adapter.Fill(tabla);
            conexion.Close();

            return tabla;
        }

        public int TotalTurnosPresentes(DateTime desde, DateTime hasta)
        {
            string consultaSql =
        "SELECT COUNT(ID_Turno) " +
        "FROM Turnos " +
        "JOIN Pacientes ON Pacientes.DNI_Paciente = Turnos.DNI_Paciente_Turno " +
        "WHERE Fecha_Turno BETWEEN @Desde AND @Hasta " +
        "AND Estado_Turno = 'Presente'";

            conexion.Open();
            SqlCommand comandoSQL = new SqlCommand(consultaSql, conexion);
            comandoSQL.Parameters.AddWithValue("@Desde", desde);
            comandoSQL.Parameters.AddWithValue("@Hasta", hasta);

            int total = Convert.ToInt32(comandoSQL.ExecuteScalar());
            conexion.Close();

            return total;
        }

        public int TotalTurnosAusentes(DateTime desde, DateTime hasta)
        {
            string consultaSql =
         "SELECT COUNT(ID_Turno) " +
         "FROM Turnos " +
         "JOIN Pacientes ON Pacientes.DNI_Paciente = Turnos.DNI_Paciente_Turno " +
         "WHERE Fecha_Turno BETWEEN @Desde AND @Hasta " +
         "AND Estado_Turno = 'Ausente'";

            conexion.Open();
            SqlCommand comandoSQL = new SqlCommand(consultaSql, conexion);
            comandoSQL.Parameters.AddWithValue("@Desde", desde);
            comandoSQL.Parameters.AddWithValue("@Hasta", hasta);

            int total = Convert.ToInt32(comandoSQL.ExecuteScalar());
            conexion.Close();

            return total;
        }

        public void ddlHoras(DropDownList ddlHora, string horarios)
        {
            ddlHora.Items.Clear();
            ddlHora.Items.Add(new ListItem("---Seleccionar---", "0"));

            if (string.IsNullOrWhiteSpace(horarios))
                return;

            string[] partes = horarios.Split('-');
            if (partes.Length != 2)
                return;

            TimeSpan horaInicio, horaFin;

            if (!TimeSpan.TryParse(partes[0].Trim(), out horaInicio) ||
                !TimeSpan.TryParse(partes[1].Trim(), out horaFin))
                return;

            TimeSpan hora = horaInicio;
            string valor;

            // horario normal (ej: 08:00 - 16:00)
            if (horaInicio < horaFin)
            {
                while (hora < horaFin)
                {
                    valor = hora.ToString(@"hh\:mm");
                    ddlHora.Items.Add(new ListItem(valor, valor));
                    hora = hora.Add(TimeSpan.FromHours(1));
                }
            }
            // horario nocturno (ej: 22:00 - 06:00)
            else
            {
                // desde horaInicio hasta 24:00
                while (hora < TimeSpan.FromHours(24))
                {
                    valor = hora.ToString(@"hh\:mm");
                    ddlHora.Items.Add(new ListItem(valor, valor));
                    hora = hora.Add(TimeSpan.FromHours(1));
                }

                // desde 00:00 hasta horaFin
                hora = TimeSpan.Zero;
                while (hora < horaFin)
                {
                    valor = hora.ToString(@"hh\:mm");
                    ddlHora.Items.Add(new ListItem(valor, valor));
                    hora = hora.Add(TimeSpan.FromHours(1));
                }
            }
        }





        public bool VerificarTurno(Turnos turnos)
        {
            string id = turnos.GetId_Medico_Turno().Trim();
            string hora=turnos.GetHora_Turno().Trim();
            DateTime fecha = turnos.GetFecha_Turno().Date;
            string query = "SELECT COUNT(*) FROM Turnos WHERE Id_Medico_Turno=@id AND Fecha_Turno=@fecha AND Hora_Turno=@hora";

            SqlConnection conn = ds.ObtenerConexion();
            conn.Open();
            SqlCommand cmd = new SqlCommand(query,conn);
            cmd.Parameters.AddWithValue("@id",id);
            cmd.Parameters.AddWithValue("@fecha",fecha);
            cmd.Parameters.AddWithValue("@hora", hora);


            int cantidad=Convert.ToInt32(cmd.ExecuteScalar());
            conn.Close();
            bool resultado = cantidad > 0;
            return resultado;
        }




        public void ActualizarEstadoTurno(Turnos t)
        {
            using (SqlConnection conn = ds.ObtenerConexion())
            {
                string sql = @"UPDATE Turnos SET 
                        Estado_Turno = @Estado, 
                        Observacion_Turno = @Observacion
                        WHERE ID_Turno = @id";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Estado",t.GetEstado_Turno());
                cmd.Parameters.AddWithValue("@Observacion", t.GetObservacion_Turno());
                cmd.Parameters.AddWithValue("@id", t.GetID_Turno());
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

       




    }
}
