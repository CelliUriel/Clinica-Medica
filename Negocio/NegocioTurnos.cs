using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Web.Management;
using System.Web.UI.WebControls;

namespace Negocio
{
    public class NegocioTurnos
    {
        DaoTurnos turnosDatos = new DaoTurnos();

        public bool CrearTurno(Turnos turno)
        {
            bool exito=turnosDatos.VerificarTurno(turno);
            if(!exito)
            {
                //no existe el usuario  exito=0
                int filas = turnosDatos.InsertarTurno(turno);
                return filas == 1;



            }  else
            {
                //existe el usuario exito >0 
                return false;
            }
      
        }
        
     

        public DataTable ListarTurnos(int idUsuario)
        {
            return turnosDatos.ListarTurnos(idUsuario);
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
        public void CompletarddlHoras(DropDownList ddl, string Horarios)
        {
            turnosDatos.ddlHoras(ddl,Horarios);
        }

        public void ActualizarTurno(Turnos t)
        {
            turnosDatos.ActualizarEstadoTurno(t);
        }
    
        public DataTable FiltroTurnos(DateTime? fecha,string estado,int id)
        {
            return turnosDatos.FiltroEstadoYFecha(fecha, estado,id);
        }
    }
}
