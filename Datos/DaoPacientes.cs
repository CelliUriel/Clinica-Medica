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
                 $" WHERE P.DNI_Paciente={dni}";




            return ds.ObtenerTabla(consultaSQL);

        }
        private void ArmarParametrosEliminarPaciente(ref SqlCommand Comando, Pacientes pacientes)
        {
            SqlParametros = Comando.Parameters.Add("@DNIPaciente", SqlDbType.Char, 8);
            SqlParametros.Value = pacientes.Dni_Paciente;
        }



        public bool EliminarPaciente(Pacientes pacientes)
        {
            AccesoDatos accesoDatos = new AccesoDatos();

            SqlCommand sqlCommand = new SqlCommand();

            ArmarParametrosEliminarPaciente(ref sqlCommand, pacientes);

            int FilasInsertadas = accesoDatos.EjecutarComando("UPDATE Pacientes SET Estado_Pacientes = 0 WHERE DNI_Paciente = @DNIPaciente");
            if (FilasInsertadas == 1)
            {
                return true;
            }
            else
            {
                return false;
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
                throw new Exception("Error al insertar el médico: " + ex.Message);
            }
        }

        public void GuardarPacientes(Pacientes pacientes)
        {
            DaoPacientes daoPacientes = new DaoPacientes();
            //DaoMedicos daoMedicos = new DaoMedicos();
            //daoMedicos.InsertarMedico(medico);
            daoPacientes.InsertarPacientes(pacientes);
        }





    }
}
