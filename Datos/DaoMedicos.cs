using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace Datos
{
    public class DaoMedicos
    {
        AccesoDatos ds = new AccesoDatos();
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
            ddlSexo.Items.Add(new ListItem("Masculino", "Masculino"));
            ddlSexo.Items.Add(new ListItem("Femenino", "Femenino"));
            ddlSexo.Items.Add(new ListItem("Otro", "Otro"));
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
                        cmd.Parameters.AddWithValue("@Estado",medico.GetEstado_Medico());
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
            catch
            {
                return false;
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
                "M.DNI_MEDICO AS DNI , " +
                "M.Nombre_Medico AS Nombre, " +
                "M.Apellido_Medico AS Apellido, " +
                "M.Telefono_Medico AS  Telefono, " +
                "M.Estado_Medico AS Estado, " +
                "E.Nombre_Especialidad AS NombreEspecialidad, " +
                "M.Codigo_Especialidad_Medico  " +
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

       /* public DataTable FiltrarMedicoPorID(string id)
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
        }*/

        private void ArmarParametrosEliminarMedico(ref SqlCommand Comando, Medicos medico)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@IdMedico", SqlDbType.Int);
            SqlParametros.Value = medico.GetId_Medico();
        }

        public bool EliminarMedico(Medicos medico)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            SqlConnection conexion = accesoDatos.ObtenerConexion();

            SqlCommand sqlCommand = new SqlCommand();

            ArmarParametrosEliminarMedico(ref sqlCommand, medico);

            int FilasInsertadas = accesoDatos.EjecutarComando("UPDATE Medicos SET Estado_Medico=0 WHERE ID_Medico = @IdMedico");
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
           // string consulta = "SELECT * FROM Medicos WHERE DNI_MEDICO AS DNI = @dni";


            string consulta =
            "SELECT " +
            "DNI_MEDICO AS DNI , " +
            "Nombre_Medico AS Nombre, " +
            "Apellido_Medico AS Apellido, " +
            "Telefono_Medico AS  Telefono, " +
            "Estado_Medico AS Estado, " +
            "Codigo_Especialidad_Medico  " +
            "FROM Medicos WHERE DNI_MEDICO  = @dni";

            SqlCommand cmd = new SqlCommand(consulta);
            cmd.Parameters.AddWithValue("@dni", dni);

            AccesoDatos ds = new AccesoDatos();
            return ds.ObtenerTabla("Medicos", cmd);
        }

    }
}
