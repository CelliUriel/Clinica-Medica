using Entidades;
using System;
using System.Data.SqlClient;

namespace Datos
{
    public class DaoUsuario
    {
        AccesoDatos ds = new AccesoDatos();
        public bool InsertarUsuario(Usuario usuario)
        {
            try
            {
                using (SqlConnection cn = ds.ObtenerConexion())
                {
                    cn.Open();

                    string consulta = @"
                INSERT INTO Usuarios 
                (Nombre_Usuario, Contraseña, Rol)
                VALUES
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

                    string consulta = @"
                SELECT ID_Usuario, Nombre_Usuario, [Contraseña], Rol
                FROM Usuarios
                WHERE Nombre_Usuario = @Nombre AND Contraseña = @Contrasenia";

                    using (SqlCommand cmd = new SqlCommand(consulta, cn))
                    {
                        cmd.Parameters.Add("@Nombre", System.Data.SqlDbType.NVarChar, 100).Value = nombreUsuario;
                        cmd.Parameters.Add("@Contrasenia", System.Data.SqlDbType.NVarChar, 100).Value = contrasenia;

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
            catch (Exception ex)
            {
                return null;
            }

            return usuario;
        }




        public void guardarUsuario(Usuario usuario)
        {
            DaoUsuario daoUsuario = new DaoUsuario();
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

                        // Ejecutamos el INSERT y obtenemos el ID generado
                        object result = cmd.ExecuteScalar();

                        return Convert.ToInt32(result);
                    }
                }
            }
            catch
            {
                return -1; // señal de error
            }


        }
    }
}