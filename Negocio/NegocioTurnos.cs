using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioTurnos
    {
        TurnosDatos turnosDatos = new TurnosDatos();

        public bool CrearTurno(Turnos turno)
        {
            int filas = turnosDatos.InsertarTurno(turno);
            return filas == 1;
        }
    }
}
