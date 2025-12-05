using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DaoUsuarios
    {
        static readonly AccesoDatos ds = new AccesoDatos();
        readonly SqlConnection conexion = ds.ObtenerConexion();
        readonly SqlParameter SqlParametros = new SqlParameter();

        public bool InsertarUsuario(Usuario usuario)
        {
            try
            {
                using (SqlConnection cn = ds.ObtenerConexion())
                {
                    cn.Open();

                    string consulta = @"INSERT INTO Usuarios (Nombre_Usuario, Contraseña, Rol) VALUES
                                      (@Nombre, @Contrasenia, @Rol)";

                    using (SqlCommand cmd = new SqlCommand(consulta, cn))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", usuario.getNombre_usuario());
                        cmd.Parameters.AddWithValue("@Contrasenia", usuario.getContrasenia());
                        cmd.Parameters.AddWithValue("@Rol", usuario.getRol());

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

        public Usuario InicioSesion(string nombreUsuario, string contrasenia)
        {
            Usuario usuario = null;

            try
            {
                using (SqlConnection cn = ds.ObtenerConexion())
                {
                    cn.Open();

                    string consulta = @"SELECT ID_Usuario, Nombre_Usuario, [Contraseña], Rol
                                      FROM Usuarios
                                      WHERE Nombre_Usuario = @Nombre AND Contraseña = @Contrasenia";

                    using (SqlCommand cmd = new SqlCommand(consulta, cn))
                    {
                        cmd.Parameters.Add("@Nombre", SqlDbType.NVarChar, 100).Value = nombreUsuario;
                        cmd.Parameters.Add("@Contrasenia", SqlDbType.NVarChar, 100).Value = contrasenia;

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                usuario = new Usuario();
                                usuario.setId_usuario(Convert.ToInt32(dr["ID_Usuario"]));
                                usuario.setNombre_usuario(Convert.ToString(dr["Nombre_Usuario"]));
                                usuario.setContrasenia(Convert.ToString(dr["Contraseña"]));
                                usuario.setRol(ConvertirBit(dr["Rol"]));
                            }
                        }
                    }
                }
            }
            catch
            {
                return null;
            }

            return usuario;
        }

        public void GuardarUsuario(Usuario usuario)
        {
            DaoUsuarios daoUsuario = new DaoUsuarios();
            daoUsuario.InsertarUsuario(usuario);
        }

        private bool ConvertirBit(object valor)
        {
            if (valor is bool b) return b;

            string s = Convert.ToString(valor);
            if (bool.TryParse(s, out bool bol)) return bol;

            if (int.TryParse(s, out int iv)) return iv != 0;

            return false;
        }

        public int InsertarUsuarioYDevolverID(Usuario usuario)
        {
            try
            {
                using (SqlConnection cn = ds.ObtenerConexion())
                {
                    cn.Open();

                    string consulta = @"INSERT INTO Usuarios (Nombre_Usuario, Contraseña, Rol)
                                      VALUES (@Nombre, @Contrasenia, @Rol);
                                      SELECT SCOPE_IDENTITY();";

                    using (SqlCommand cmd = new SqlCommand(consulta, cn))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", usuario.getNombre_usuario());
                        cmd.Parameters.AddWithValue("@Contrasenia", usuario.getContrasenia());
                        cmd.Parameters.AddWithValue("@Rol", usuario.getRol());

                        object result = cmd.ExecuteScalar();

                        return Convert.ToInt32(result);
                    }
                }
            }
            catch
            {
                return -1;
            }
        }

        public bool UsuarioCorrecto(string usuario)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("TU_CONNECTION"))
                {
                    string query = "SELECT COUNT(*) FROM Usuarios WHERE Nombre_Usuario = @u";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@u", usuario);

                    conn.Open();
                    int count = (int)cmd.ExecuteScalar();

                    return count > 0;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool ContraseñaCorrecta(string usuario, string pass)
        {
            try
            {
                using (SqlConnection cn = ds.ObtenerConexion())
                {
                    string query = "SELECT Contraseña FROM Usuarios WHERE Nombre_Usuario = @u";
                    SqlCommand cmd = new SqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@u", usuario);

                    cn.Open();
                    object result = cmd.ExecuteScalar();

                    if (result == null)
                        return false;

                    string passReal = result.ToString();
                    return passReal == pass;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool ExisteUsuario(string usuario)
        {
            try
            {
                using (SqlConnection conn = ds.ObtenerConexion())
                {
                    conn.Open(); // importante abrir la conexión
                    string query = "SELECT COUNT(*) FROM Usuarios WHERE Nombre_Usuario = @usuario";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool ContraseniaCorrectaLogin(string usuario, string pass)
        {
            try
            {
                using (SqlConnection conn = ds.ObtenerConexion())
                {
                    conn.Open(); // importante abrir la conexión
                    string query = "SELECT Contraseña FROM Usuarios WHERE Nombre_Usuario = @usuario";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@usuario", usuario);

                    object result = cmd.ExecuteScalar();
                    if (result == null)
                        return false;

                    return result.ToString() == pass;
                }
            }
            catch
            {
                return false;
            }
        }

        public int ValidarLogin(string usuario, string pass)
        {
            bool existe = ExisteUsuario(usuario);

            if (!existe)
                return 0;

            bool passOk = ContraseniaCorrectaLogin(usuario, pass);

            if (!passOk)
                return 1;

            return 2;
        }
    }
}
