using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

        public DataTable ListarTurnoPorFechaPresentes(DateTime desde, DateTime hasta)
        {
            return turnosDatos.ListarTurnoPorFechaPresentes(desde, hasta);
        }

        public DataTable ListarTurnoPorFechaAusentes(DateTime desde, DateTime hasta)
        {
            return turnosDatos.ListarTurnoPorFechaAusentes(desde, hasta);
        }

        public int TotalTurnosPresentes(DateTime desde, DateTime hasta)
        {
            return turnosDatos.TotalTurnosPresentes(desde, hasta);
        }

        public int TotalTurnosAusentes(DateTime desde, DateTime hasta)
        {
            return turnosDatos.TotalTurnosAusentes(desde, hasta);
        }
    }
}
