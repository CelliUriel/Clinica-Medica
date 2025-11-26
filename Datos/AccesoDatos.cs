using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    internal class AccesoDatos
    {
        // Para desarrollo local: desactivar cifrado o confiar el certificado
        private const string CadenaConexion = "Data Source=localhost\\sqlexpress;Initial Catalog=ClinicaMedica;Integrated Security=True;Encrypt=False;TrustServerCertificate=True";


        public SqlConnection ObtenerConexion()
        {
            try
            {
                return new SqlConnection(CadenaConexion);
            }

            catch
            {
                return null;
            }
        }

        private SqlDataAdapter ObtenerAdaptador(string consultaSQL, SqlConnection cn)
        {
            SqlDataAdapter adapter;

            try
            {
                adapter = new SqlDataAdapter(consultaSQL, cn);
                return adapter;
            }
            catch
            {
                return null;
            }
        }


        // Metodo publico SELECT

        public DataTable ObtenerTabla(string consultaSQL)
        {
            SqlConnection cn = ObtenerConexion();
            if (cn == null) return null;

            SqlDataAdapter adapter = ObtenerAdaptador(consultaSQL, cn);
            if (adapter == null) return null;

            DataTable tabla = new DataTable();
            adapter.Fill(tabla);
            cn.Close();
            return tabla;
        }

        public DataTable ObtenerTabla(string nombreTabla, SqlCommand comando)
        {
            SqlConnection cn = ObtenerConexion();
            if (cn == null) return null;

            comando.Connection = cn;

            SqlDataAdapter adapter = new SqlDataAdapter(comando);

            DataTable tabla = new DataTable(nombreTabla);
            adapter.Fill(tabla);

            cn.Close();
            return tabla;
        }


        // Metodo pubico INSERT - UPDATE - DELETE

        public int EjecutarComando(string consultaSQL)
        {
            SqlConnection cn = ObtenerConexion();
            if (cn == null)
            {
                return 0;
            }
            

            try
            {
                SqlCommand cmd = new SqlCommand(consultaSQL, cn);
                int filas = cmd.ExecuteNonQuery();
                cn.Close();
                return filas;
            }
            catch
            {
                cn.Close();
                return 0;
            }
        }


        public DataTable CompletarDdl(string consultaSQL)
        {
            using (SqlConnection cn = ObtenerConexion())
            {
                cn.Open();
                using (SqlDataAdapter da = new SqlDataAdapter(consultaSQL, cn))
                {
                    DataTable tabla = new DataTable();
                    da.Fill(tabla);
                    return tabla;
                }
            }
        }

        public DataTable CompletarGridView(string consultaSQL)
        {
            SqlConnection cn = ObtenerConexion();
            using (cn)
            {


                SqlDataAdapter da = ObtenerAdaptador(consultaSQL, cn);
                DataTable tabla = new DataTable();
                da.Fill(tabla);

                return tabla;
            }
        }

       
    }
}

