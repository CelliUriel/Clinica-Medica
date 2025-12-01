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
    public class NegocioTurnos
    {
        DaoTurnos turnosDatos = new DaoTurnos();

        public bool CrearTurno(Turnos turno)
        {
            int filas = turnosDatos.InsertarTurno(turno);
            return filas == 1;
        }

        public DataTable ListarTurnos()
        {
            return turnosDatos.ListarTurnos();
        }

    }
}
