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
    public class NegocioMedicos
    {
        DaoMedicos dao = new DaoMedicos();

        public DataTable ListarMedicos()
        {
            return dao.ListarMedicos();
        }
    
        public DataTable BuscarPorDNI(string dni)
        {
            return dao.BuscarMedicoPorDNI(dni);
        }

    }
}
