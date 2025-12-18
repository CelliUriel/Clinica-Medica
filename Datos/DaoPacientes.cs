using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;


namespace Datos
{
    public class DaoPacientes
    {
        static readonly AccesoDatos ds = new AccesoDatos();
        SqlParameter SqlParametros = new SqlParameter();
        readonly SqlConnection conexion = ds.ObtenerConexion();
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


        public void CompletarDdlPacientes(DropDownList ddlPaciente)
        {
            ddlPaciente.Items.Clear();
            ddlPaciente.Items.Add(new ListItem("---Seleccionar---", "0"));

            DataTable tabla = new AccesoDatos().CompletarDdl("SELECT * FROM Pacientes ORDER BY Apellido_Paciente");

            foreach (DataRow fila in tabla.Rows)
            {
                ddlPaciente.Items.Add(new ListItem(fila["Apellido_Paciente " + "Nombre_Paciente"].ToString()));
            }
        }

        public DataTable ListarPacientes()
        {
            string consultaSQL =
                      "SELECT " +
                      "P.DNI_Paciente AS DNI, " +
                      "P.Nombre_Paciente AS Nombre, " +
                      "P.Apellido_Paciente AS Apellido, " +
                      "P.Sexo_Paciente AS Sexo, " +
                      "P.Nacionalidad_Paciente AS Nacionalidad, " +
                      "CONVERT(VARCHAR(10), P.FechaNacimiento_Paciente, 103) AS FechaNacimiento, " +
                      "P.Direccion_Paciente AS Direccion, " +
                      "L.ID_Localidad AS ID_Localidad, " +
                      "L.Descripcion_Localidad AS Localidad, " +
                      "PR.ID_Provincia AS ID_Provincia, " +
                      "PR.Descripcion_Provincia AS Provincia, " +
                      "P.Correo_Paciente AS Correo, " +
                      "P.Telefono_Paciente AS Telefono, " +
                      "P.Estado_Paciente AS Estado " +
                      "FROM Pacientes P " +
                      "JOIN Localidades L ON P.ID_Localidad_Paciente = L.ID_Localidad " +
                      "JOIN Provincias PR ON P.ID_Provincia_Paciente = PR.ID_Provincia " +
                      "WHERE P.Estado_Paciente = 1";

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
                "P.FechaNacimiento_Paciente AS FechaNacimiento, " +
                "P.Direccion_Paciente AS Direccion, " +
                "P.ID_Localidad_Paciente AS Localidad, " +
                "P.ID_Provincia_Paciente AS Provincia, " +
                "P.Correo_Paciente AS Correo, " +
                "P.Telefono_Paciente AS Telefono," +
                "P.Estado_Paciente AS Estado " +
                 "FROM Pacientes P " +
                 $"WHERE RTRIM(P.DNI_Paciente) LIKE '%{dni}%'";




            return ds.ObtenerTabla(consultaSQL);

        }
        private void ArmarParametrosEliminarPaciente(ref SqlCommand Comando, Pacientes pacientes)
        {
            SqlParametros = Comando.Parameters.Add("@DNIPaciente", SqlDbType.Char, 8);
            SqlParametros.Value = pacientes.Dni_Paciente;
        }



        public bool EliminarPaciente(Pacientes paciente)
        {
            using (SqlConnection cn = ds.ObtenerConexion())
            {
                cn.Open();
                string consulta = "UPDATE Pacientes SET Estado_Paciente = 0 WHERE DNI_Paciente = @DNIPaciente";
                using (SqlCommand cmd = new SqlCommand(consulta, cn))
                {
                    cmd.Parameters.AddWithValue("@DNIPaciente", paciente.Dni_Paciente);
                    int filas = cmd.ExecuteNonQuery();
                    return filas > 0;
                }
            }
        }

        public bool InsertarPacientes(Pacientes pacientes)
        {
            try
            {
                using (SqlConnection cn = ds.ObtenerConexion())
                {
                    cn.Open();

                    string consulta = @"INSERT INTO Pacientes 
                        ( DNI_Paciente, Nombre_Paciente, Apellido_Paciente,
                         Sexo_Paciente, Nacionalidad_Paciente, FechaNacimiento_Paciente, Direccion_Paciente,
                         ID_Localidad_Paciente, ID_Provincia_Paciente, Correo_Paciente, Telefono_Paciente,
                          Estado_Paciente)
                        VALUES
                        ( @DNI, @Nombre, @Apellido,
                         @Sexo, @Nacionalidad, @FechaNacimiento, @Direccion,
                         @IdLocalidad, @IdProvincia, @Correo, @Telefono,
                          @Estado)";

                    using (SqlCommand cmd = new SqlCommand(consulta, cn))
                    {
                        
                        
                        cmd.Parameters.AddWithValue("@DNI",pacientes.GetDni_Paciente() );
                        cmd.Parameters.AddWithValue("@Nombre",pacientes.GetNombre_Paciente() );
                        cmd.Parameters.AddWithValue("@Apellido",pacientes.GetApellido_Paciente() );
                        cmd.Parameters.AddWithValue("@Sexo",pacientes.GetSexo_Paciente() );
                        cmd.Parameters.AddWithValue("@Nacionalidad",pacientes.GetNacionalidad_Paciente());
                        cmd.Parameters.AddWithValue("@FechaNacimiento",pacientes.GetFecha_Nacimiento_Paciente() );
                        cmd.Parameters.AddWithValue("@Direccion",pacientes.GetDireccion_Paciente() );
                        cmd.Parameters.AddWithValue("@IdLocalidad",pacientes.GetIdLocalidad_Paciente() );
                        cmd.Parameters.AddWithValue("@IdProvincia",pacientes.GetIdProvincia_Paciente());
                        cmd.Parameters.AddWithValue("@Correo", pacientes.GetCorreo_Paciente());
                        cmd.Parameters.AddWithValue("@Telefono", pacientes.GetTelefono_Paciente());
                        cmd.Parameters.AddWithValue("@Estado", pacientes.GetEstado_Paciente());
                        int filas = cmd.ExecuteNonQuery();
                        return filas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
               return false;
            }
        }

        public void GuardarPacientes(Pacientes pacientes)
        {
            DaoPacientes daoPacientes = new DaoPacientes();
            //DaoMedicos daoMedicos = new DaoMedicos();
            //daoMedicos.InsertarMedico(medico);
            daoPacientes.InsertarPacientes(pacientes);
        }

        public int AltaLogica(string dni)
        {
            using (SqlConnection conn = ds.ObtenerConexion())
            {
                conn.Open();

                string query = "UPDATE Pacientes SET Estado_Paciente=@Estado WHERE DNI_Paciente=@dni AND Estado_Paciente=0";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Estado", 1);
                cmd.Parameters.AddWithValue("@dni", dni);
                int filas = cmd.ExecuteNonQuery();
                conn.Close();
                return filas;

            }
        }

        public bool ActualizarPaciente(Pacientes p)
        {
            try
            {
                using (SqlConnection cn = ds.ObtenerConexion())
                {

                    string sql = @"UPDATE Pacientes SET 
                            Nombre_Paciente = @Nombre,
                            Apellido_Paciente = @Apellido,
                            Sexo_Paciente = @Sexo,
                            Nacionalidad_Paciente = @Nacionalidad,
                            ID_Provincia_Paciente = @IdProvincia,
                            ID_Localidad_Paciente = @IdLocalidad,
                            Direccion_Paciente = @Direccion,
                            Correo_Paciente = @Correo,
                            Telefono_Paciente = @Telefono,
                            Estado_Paciente = @Estado
                           WHERE DNI_Paciente = @DNI";

                    using (SqlCommand cmd = new SqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@DNI", p.GetDni_Paciente());
                        cmd.Parameters.AddWithValue("@Nombre", p.GetNombre_Paciente());
                        cmd.Parameters.AddWithValue("@Apellido", p.GetApellido_Paciente());
                        cmd.Parameters.AddWithValue("@Sexo", p.GetSexo_Paciente());
                       // cmd.Parameters.AddWithValue("@FechaNacimiento", p.GetFecha_Nacimiento_Paciente());
                        cmd.Parameters.AddWithValue("@Nacionalidad", p.GetNacionalidad_Paciente());
                        cmd.Parameters.AddWithValue("@IdProvincia", p.GetIdProvincia_Paciente());
                        cmd.Parameters.AddWithValue("@IdLocalidad", p.GetIdLocalidad_Paciente());
                        cmd.Parameters.AddWithValue("@Direccion", p.GetDireccion_Paciente());
                        cmd.Parameters.AddWithValue("@Correo", p.GetCorreo_Paciente());
                        cmd.Parameters.AddWithValue("@Telefono", p.GetTelefono_Paciente());

                        // Bit (bool) → entero
                        cmd.Parameters.AddWithValue("@Estado", p.GetEstado_Paciente() ? 1 : 0);

                        cn.Open();
                        int filas = cmd.ExecuteNonQuery();

                        return filas > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                string msg = "Error SQL en ActualizarPaciente: " + ex.Message;
                throw new Exception(msg, ex);
            }
            catch (Exception ex)
            {
                string msg = "Error en ActualizarPaciente: " + ex.Message;
                throw new Exception(msg, ex);
            }
        }

        public bool ExisteDni(string dni)
        {
            using (SqlConnection cn = ds.ObtenerConexion())
            {
                cn.Open();

                string query = "SELECT COUNT(*) FROM Pacientes WHERE DNI_Paciente = @dni";
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@dni", dni);
                    int cantidad = (int)cmd.ExecuteScalar();
                    return cantidad > 0;
                }
            }
        }
    }
}
