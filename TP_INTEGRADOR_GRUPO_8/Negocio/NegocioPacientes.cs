using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioPacientes
    {
        DaoPacientes Dao = new DaoPacientes();

        public DataTable ListarPacientes()
        {
            return Dao.ListarPacientes();
            
        }

        public DataTable BuscarPorDNI(string dni)
        {
            return Dao.FiltrarPacientesPorDNI(dni);
        }
    }
}
