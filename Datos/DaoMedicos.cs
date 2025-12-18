using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace Datos
{
    public class DaoMedicos
    {
        static readonly AccesoDatos ds = new AccesoDatos();
        readonly SqlConnection conexion = ds.ObtenerConexion();
        SqlParameter SqlParametros = new SqlParameter();
        BaseDao BaseDao = new BaseDao();

        public void CompletarDdlProvincias(DropDownList ddlProvincia)
        {
            BaseDao.CompletarDdlProvincias(ddlProvincia);
        }

        public void CompletarDdlLocalidades(DropDownList ddlLocalidad, int idProvincia)
        {
            
            BaseDao.CompletarDdlLocalidades(ddlLocalidad, idProvincia);
        }

        public void CompletarDdlSexo(DropDownList ddlSexo)
        {
            BaseDao.CompletarDdlSexo(ddlSexo);
        }

        public void CompletarDdlEspecialidades(DropDownList ddlEspecialidad)
        {
            DataTable dt = ds.CompletarDdl("SELECT * FROM Especialidades");

            ddlEspecialidad.DataSource = dt;
            ddlEspecialidad.DataTextField = "Nombre_Especialidad";
            ddlEspecialidad.DataValueField = "Codigo_Especialidad";
            ddlEspecialidad.DataBind();
            ddlEspecialidad.Items.Insert(0, new ListItem("--- Seleccionar ---", "0"));
        }

        public void CompletarDdlHoras(DropDownList ddlHora)
        {
            ddlHora.Items.Clear();
            ddlHora.Items.Add(new ListItem("---Seleccionar---", "0"));

            for (int hora = 0; hora < 24; hora++)
            {
                string valor = $"{hora:D2}:00";
                ddlHora.Items.Add(new ListItem(valor, valor));
            }
        }

        public void CompletarDdlMedicos(DropDownList ddlMedicos, int idEspecialidad)
        {
            ddlMedicos.Items.Clear();
            ddlMedicos.Items.Add(new ListItem("---Seleccionar---", "0"));

            if (idEspecialidad == 0) return;

            DataTable tabla = new AccesoDatos().CompletarDdl(
                $"SELECT ID_Medico, (Nombre_Medico + ' ' + Apellido_Medico) AS NombreCompleto " +
                $"FROM Medicos WHERE Codigo_Especialidad_Medico = {idEspecialidad} " +
                $"ORDER BY Apellido_Medico, Nombre_Medico"
            );

            foreach (DataRow fila in tabla.Rows)
            {
                ddlMedicos.Items.Add(
                    new ListItem(
                        fila["NombreCompleto"].ToString(),
                        fila["ID_Medico"].ToString()
                    )
                );
            }
        }

        public void CompletarDdlPacientes(DropDownList ddlPacientes)
        {
            ddlPacientes.Items.Clear();
            ddlPacientes.Items.Add(new ListItem("---Seleccionar---", "0"));

            DataTable tabla = new AccesoDatos().CompletarDdl(
                "SELECT DNI_Paciente, Nombre_Paciente, Apellido_Paciente " +
                "FROM Pacientes " +
                "ORDER BY Apellido_Paciente, Nombre_Paciente"
            );

            foreach (DataRow fila in tabla.Rows)
            {
                string nombreCompleto = fila["Apellido_Paciente"] + " " + fila["Nombre_Paciente"];

                ddlPacientes.Items.Add(
                    new ListItem(
                        nombreCompleto,
                        fila["DNI_Paciente"].ToString()
                    )
                );
            }
        }


        public bool InsertarMedico(Medicos medico)
        {
            try
            {
                using (SqlConnection cn = ds.ObtenerConexion())
                {
                    cn.Open();

                    string consulta = @"INSERT INTO Medicos 
                        (Codigo_Especialidad_Medico, DNI_MEDICO, Nombre_Medico, Apellido_Medico,
                         Sexo_Medico, Nacionalidad_Medico, FechaNacimiento_Medico, Direccion_Medico,
                         ID_Localidad_Medico, ID_Provincia_Medico, Correo_Medico, Telefono_Medico,
                         DiasAtencion_Medico, HorariosAtencion_Medico, ID_Usuario, Estado_Medico)
                        VALUES
                        (@Codigo, @DNI, @Nombre, @Apellido,
                         @Sexo, @Nacionalidad, @FechaNacimiento, @Direccion,
                         @IdLocalidad, @IdProvincia, @Correo, @Telefono,
                         @DiasAtencion, @Horario, @IdUsuario,@Estado)";

                    using (SqlCommand cmd = new SqlCommand(consulta, cn))
                    {
                        cmd.Parameters.AddWithValue("@Codigo", medico.GetCodigo_Especialidad_Medico());
                        cmd.Parameters.AddWithValue("@DNI", medico.GetDniMedico());
                        cmd.Parameters.AddWithValue("@Nombre", medico.GetNombre_Medico());
                        cmd.Parameters.AddWithValue("@Apellido", medico.GetApellido_Medico());
                        cmd.Parameters.AddWithValue("@Sexo", medico.GetSexo_Medico());
                        cmd.Parameters.AddWithValue("@Nacionalidad", medico.GetNacionalidad_Medico());
                        cmd.Parameters.AddWithValue("@FechaNacimiento", medico.GetFecha_Nacimiento_Medico());
                        cmd.Parameters.AddWithValue("@Direccion", medico.GetDireccion_Medico());
                        cmd.Parameters.AddWithValue("@IdLocalidad", medico.GetId_Localidad_Medico());
                        cmd.Parameters.AddWithValue("@IdProvincia", medico.GetId_Provincia_Medico());
                        cmd.Parameters.AddWithValue("@Correo", medico.GetCorreo_Medico());
                        cmd.Parameters.AddWithValue("@Telefono", medico.GetTelefono_Medico());
                        cmd.Parameters.AddWithValue("@DiasAtencion", medico.GetDiasAtencion_Medico());
                        cmd.Parameters.AddWithValue("@Horario", medico.GetHorariosAtencion_Medico());
                        cmd.Parameters.AddWithValue("@Estado", medico.GetEstado_Medico());
                        var idUsuario = medico.GetId_Usuario_Medico();

                        if (idUsuario <= 0)
                            cmd.Parameters.AddWithValue("@IdUsuario", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
                        int filas = cmd.ExecuteNonQuery();
                        return filas > 0;
                    }
                }
            }
            catch(Exception ex)
            {
                throw new Exception("error en medico.", ex);
            }
        }

        public bool GuardarMedico(Medicos medico)
        {
            DaoMedicos daoMedicos = new DaoMedicos();
            return daoMedicos.InsertarMedico(medico);
        }

        public DataTable ListarMedicos()
        {
            string consultaSQL =
                "SELECT " +
                "M.ID_Medico AS ID, " +
                "M.DNI_MEDICO AS DNI, " +
                "M.Nombre_Medico AS Nombre, " +
                "M.Apellido_Medico AS Apellido, " +
                "M.Sexo_Medico AS Sexo, " +
                "M.Nacionalidad_Medico AS Nacionalidad, " +
                "CONVERT(VARCHAR(10), M.FechaNacimiento_Medico, 103) AS FechaNacimiento, " +
                "M.Direccion_Medico AS Direccion, " +
                "L.ID_Localidad AS ID_Localidad, " +
                "L.Descripcion_Localidad AS Localidad, " +
                "P.ID_Provincia AS ID_Provincia, " +
                "P.Descripcion_Provincia AS Provincia, " +
                "M.Codigo_Especialidad_Medico AS ID_Especialidad, " +
                "E.Nombre_Especialidad AS Especialidad, " +
                "M.Correo_Medico AS Correo, " +
                "M.Telefono_Medico AS Telefono, " +
                "M.DiasAtencion_Medico AS DiasAtencion, " +
                "M.HorariosAtencion_Medico AS HorarioAtencion, " +
                "M.Estado_Medico AS Estado " +
                "FROM Medicos M " +
                "JOIN Especialidades E ON M.Codigo_Especialidad_Medico = E.Codigo_Especialidad " +
                "JOIN Localidades L ON M.ID_Localidad_Medico = L.ID_Localidad " +
                "JOIN Provincias P ON M.ID_Provincia_Medico = P.ID_Provincia " +
                "WHERE M.Estado_Medico = 1";

            return ds.ObtenerTabla(consultaSQL);
        }




        public DataTable FiltrarMedicoPorDNI(int dniMedico)
        {
          
            string consultaSQL =
                 "SELECT " +
                 "M.ID_Medico AS ID, " +
                 "M.DNI_MEDICO AS DNI, " +
                 "M.Nombre_Medico AS Nombre, " +
                 "M.Apellido_Medico AS Apellido, " +
                 "M.Sexo_Medico AS Sexo, " +
                 "M.Nacionalidad_Medico AS Nacionalidad, " +
                 "CONVERT(VARCHAR(10), M.FechaNacimiento_Medico, 103) AS FechaNacimiento, " +
                 "M.Direccion_Medico AS Direccion, " +
                 "L.ID_Localidad AS ID_Localidad, " +
                 "L.Descripcion_Localidad AS Localidad, " +
                 "P.ID_Provincia AS ID_Provincia, " +
                 "P.Descripcion_Provincia AS Provincia, " +
                 "M.Codigo_Especialidad_Medico AS ID_Especialidad, " +
                 "E.Nombre_Especialidad AS Especialidad, " +
                 "M.Correo_Medico AS Correo, " +
                 "M.Telefono_Medico AS Telefono, " +
                 "M.DiasAtencion_Medico AS DiasAtencion, " +
                 "M.HorariosAtencion_Medico AS HorarioAtencion, " +
                 "M.Estado_Medico AS Estado " +
                 "FROM Medicos M " +
                 "JOIN Especialidades E ON M.Codigo_Especialidad_Medico = E.Codigo_Especialidad " +
                 "JOIN Localidades L ON M.ID_Localidad_Medico = L.ID_Localidad " +
                 "JOIN Provincias P ON M.ID_Provincia_Medico = P.ID_Provincia " +
                 $"WHERE M.DNI_MEDICO={dniMedico} AND M.Estado_Medico = 1 ";

            return ds.ObtenerTabla(consultaSQL);
        }

        public bool EliminarMedico(Medicos medico)
        {
            using (SqlConnection cn = ds.ObtenerConexion())
            {
                cn.Open();
                string consulta = "UPDATE Medicos SET Estado_Medico = 0 WHERE ID_Medico = @IdMedico";
                using (SqlCommand cmd = new SqlCommand(consulta, cn))
                {
                    cmd.Parameters.AddWithValue("@IdMedico", medico.GetId_Medico());
                    int filas = cmd.ExecuteNonQuery();
                    return filas > 0;
                }
            }
        }




        public DataTable BuscarMedicoPorDNI(string dni)
        {
           
                string consulta =
                 "SELECT " +
                 "M.ID_Medico AS ID, " +
                 "M.DNI_MEDICO AS DNI, " +
                 "M.Nombre_Medico AS Nombre, " +
                 "M.Apellido_Medico AS Apellido, " +
                 "M.Sexo_Medico AS Sexo, " +
                 "M.Nacionalidad_Medico AS Nacionalidad, " +
                 "CONVERT(VARCHAR(10), M.FechaNacimiento_Medico, 103) AS FechaNacimiento, " +
                 "M.Direccion_Medico AS Direccion, " +
                 "L.ID_Localidad AS ID_Localidad, " +
                 "L.Descripcion_Localidad AS Localidad, " +
                 "P.ID_Provincia AS ID_Provincia, " +
                 "P.Descripcion_Provincia AS Provincia, " +
                 "M.Codigo_Especialidad_Medico AS ID_Especialidad, " +
                 "E.Nombre_Especialidad AS Especialidad, " +
                 "M.Correo_Medico AS Correo, " +
                 "M.Telefono_Medico AS Telefono, " +
                 "M.DiasAtencion_Medico AS DiasAtencion, " +
                 "M.HorariosAtencion_Medico AS HorarioAtencion, " +
                 "M.Estado_Medico AS Estado " +
                 "FROM Medicos M " +
                 "JOIN Especialidades E ON M.Codigo_Especialidad_Medico = E.Codigo_Especialidad " +
                 "JOIN Localidades L ON M.ID_Localidad_Medico = L.ID_Localidad " +
                 "JOIN Provincias P ON M.ID_Provincia_Medico = P.ID_Provincia " +
                 "WHERE RTRIM(M.DNI_MEDICO) LIKE @dni " + "AND M.Estado_Medico = 1";
                  SqlCommand cmd = new SqlCommand(consulta);
                  cmd.Parameters.AddWithValue("@dni","%" + dni + "%");
            
                  AccesoDatos ds = new AccesoDatos();
                  return ds.ObtenerTabla("Medicos", cmd);
                }

        public DataTable InformeMedicosPorTurnos(DateTime fechaDesde, DateTime fechaHasta)
        {
            AccesoDatos datos = new AccesoDatos();

            string sql = @"
        SELECT 
            M.ID_Medico,
            M.Nombre_Medico,
            M.Apellido_Medico,
            E.Nombre_Especialidad,
            COUNT(T.ID_Turno) AS CantidadTurnos
        FROM Medicos M
        LEFT JOIN Turnos T ON M.ID_Medico = T.Id_Medico_Turno
               AND T.Fecha_Turno BETWEEN @FechaDesde AND @FechaHasta
        LEFT JOIN Especialidades E 
               ON M.Codigo_Especialidad_Medico = E.Codigo_Especialidad
        WHERE M.Estado_Medico = 1
        GROUP BY 
            M.ID_Medico,
            M.Nombre_Medico,
            M.Apellido_Medico,
            E.Nombre_Especialidad
        ORDER BY CantidadTurnos DESC;
    ";

            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@FechaDesde", fechaDesde);
            cmd.Parameters.AddWithValue("@FechaHasta", fechaHasta);

            return datos.ObtenerTabla("InformeMedicos", cmd);
        }

        public Medicos DiasHorarios(int id)
        {

            Medicos medicos = new Medicos();
            SqlConnection conn = ds.ObtenerConexion();
            conn.Open();

            string Query = "SELECT DiasAtencion_Medico, HorariosAtencion_Medico FROM Medicos WHERE ID_Medico=@id";

            SqlCommand cmd = new SqlCommand(Query);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Connection = conn;

            SqlDataReader dataReader = cmd.ExecuteReader();

            if (dataReader.Read())
            {

                medicos.SetDiasAtencion_Medico(dataReader["DiasAtencion_Medico"].ToString());
                medicos.SetHorariosAtencion_Medico(dataReader["HorariosAtencion_Medico"].ToString());

            }
            conn.Close();
            return medicos;

        }
   
  

        public void ActualizarMedico(Medicos m)
        {
            using (SqlConnection conn = new SqlConnection(conexion.ConnectionString))
            {
                string sql = @"UPDATE Medicos SET 
                        Nombre_Medico = @Nombre,
                        Apellido_Medico = @Apellido,
                        Sexo_Medico = @Sexo,
                        Nacionalidad_Medico = @Nacionalidad,
                        ID_Provincia_Medico = @IdProvincia,
                        ID_Localidad_Medico = @IdLocalidad,
                        Direccion_Medico = @Direccion,
                        Correo_Medico = @Correo,
                        Telefono_Medico = @Telefono,
                        DiasAtencion_Medico = @DiasAtencion,
                        HorariosAtencion_Medico = @HorarioAtencion,
                        Codigo_Especialidad_Medico = @CodigoEspecialidad,
                        Estado_Medico = @Estado
                        WHERE DNI_MEDICO = @DNI";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@DNI", m.GetDniMedico());
                cmd.Parameters.AddWithValue("@Nombre", m.GetNombre_Medico());
                cmd.Parameters.AddWithValue("@Apellido", m.GetApellido_Medico());
                cmd.Parameters.AddWithValue("@Sexo", m.GetSexo_Medico());
                cmd.Parameters.AddWithValue("@Nacionalidad", m.GetNacionalidad_Medico());
                cmd.Parameters.AddWithValue("@IdProvincia", m.GetId_Provincia_Medico());
                cmd.Parameters.AddWithValue("@IdLocalidad", m.GetId_Localidad_Medico());
                cmd.Parameters.AddWithValue("@Direccion", m.GetDireccion_Medico());
                cmd.Parameters.AddWithValue("@Correo", m.GetCorreo_Medico());
                cmd.Parameters.AddWithValue("@Telefono", m.GetTelefono_Medico());
                cmd.Parameters.AddWithValue("@DiasAtencion", m.GetDiasAtencion_Medico());
                cmd.Parameters.AddWithValue("@HorarioAtencion", m.GetHorariosAtencion_Medico());
                cmd.Parameters.AddWithValue("@CodigoEspecialidad", m.GetCodigo_Especialidad_Medico());
                cmd.Parameters.AddWithValue("@Estado", m.GetEstado_Medico());

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }


        public int AltaLogica(string dni)
        {
            using (SqlConnection conn = ds.ObtenerConexion())
            {
                conn.Open();

                string query = "UPDATE Medicos SET Estado_Medico=@Estado WHERE DNI_MEDICO=@dni AND Estado_Medico=0";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Estado", 1);
                cmd.Parameters.AddWithValue("@dni", dni);
                int filas = cmd.ExecuteNonQuery();
                conn.Close();
                return filas;

            }
        }

        public bool ExisteDniMedico(string dni)
        {
            using (SqlConnection cn = ds.ObtenerConexion())
            {
                cn.Open();
                string sql = "SELECT COUNT(*) FROM Medicos WHERE DNI_MEDICO = @dni";
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@dni", dni);

                int cantidad = (int)cmd.ExecuteScalar();
                return cantidad > 0;
            }
        }
    }

}
