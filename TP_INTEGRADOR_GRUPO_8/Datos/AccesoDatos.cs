using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    internal class AccesoDatos
    {
        const string CadenaConexion = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ClinicaMedica;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

        public SqlConnection ObtenerConexion()
        {
            SqlConnection connection = new SqlConnection();

            try
            {
                connection.Open();
                return connection;
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


        public SqlDataReader completarDdl(string consultaSQL)
        {
            SqlConnection cn = ObtenerConexion();

            SqlCommand sqlCommand = new SqlCommand(consultaSQL, cn);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            return sqlDataReader;
        }

        public DataTable CompletarGridView(string consultaSQL)
        {
            SqlConnection cn = ObtenerConexion();
            using (cn)
            {


                SqlDataAdapter da = ObtenerAdaptador(consultaSQL,cn);
                DataTable tabla = new DataTable();
                da.Fill(tabla);

                return tabla;
            }
        }
    }
}

