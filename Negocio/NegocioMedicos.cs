using Datos;
using Entidades;
using System;
using System.Data;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Web.UI.WebControls;

namespace Negocio
{
    public class NegocioMedicos
    {
        readonly DaoMedicos daoMedicos = new DaoMedicos();

        public void CompletarDdlProvincias(DropDownList ddlProvincias)
        {
            daoMedicos.CompletarDdlProvincias(ddlProvincias);
        }

        public void CompletarDdlLocalidades(DropDownList ddlLocalidad, int idProvincia)
        {
            daoMedicos.CompletarDdlLocalidades(ddlLocalidad, idProvincia);
        }

        public void CompletarDdlEspecialidades(DropDownList ddlEspecialidad)
        {
            daoMedicos.CompletarDdlEspecialidades(ddlEspecialidad);
        }

        public void CompletarDdlSexo(DropDownList ddlSexo)
        {
            daoMedicos.CompletarDdlSexo(ddlSexo);
        }

        public void CompletarDdlHoras(DropDownList ddlHoraInicio)
        {
            daoMedicos.CompletarDdlHoras(ddlHoraInicio);
        }

        public bool GuardarMedico(Medicos medico)
        {
            return daoMedicos.InsertarMedico(medico);
        }

        public DataTable ListarMedicos()
        {
            return daoMedicos.ListarMedicos();
        }

        public DataTable BuscarPorDNI(string dni)
        {
            return daoMedicos.BuscarMedicoPorDNI(dni);
        }

        public void CompletarDdlMedicos(DropDownList ddlMedicos, int idEspecialidad)
        {
            daoMedicos.CompletarDdlMedicos(ddlMedicos, idEspecialidad);
        }
        public void CompletarDdlPacientes(DropDownList ddlPacientes)
        {
            daoMedicos.CompletarDdlPacientes(ddlPacientes);
        }
        public DataTable ObtenerInformeMedicos(DateTime desde, DateTime hasta)
        {
            DaoMedicos dao = new DaoMedicos();
            return dao.InformeMedicosPorTurnos(desde, hasta);
        }

      
     
        public Medicos DiasHorarios(int id)
        {
            return daoMedicos.DiasHorarios(id);
        }
        public bool AtiendeEseDia(int id,DateTime fecha)
        {
            Medicos medicos = new Medicos();
            medicos=daoMedicos.DiasHorarios(id);

            string Dias = medicos.GetDiasAtencion_Medico();

            string[] DiasArray=Dias.Split(',');
            DayOfWeek diaFecha = fecha.DayOfWeek;
            foreach (string d in DiasArray)
            {
                string dia = d.Trim().ToLower();
                if (dia == "lunes" && diaFecha == DayOfWeek.Monday) return true;
                if (dia == "martes" && diaFecha == DayOfWeek.Tuesday) return true;
                if ((dia == "miércoles" || dia == "miercoles") && diaFecha == DayOfWeek.Wednesday) return true;
                if (dia == "jueves" && diaFecha == DayOfWeek.Thursday) return true;
                if (dia == "viernes" && diaFecha == DayOfWeek.Friday) return true;
                if ((dia == "sábado" || dia == "sabado") && diaFecha == DayOfWeek.Saturday) return true;
                if (dia == "domingo" && diaFecha == DayOfWeek.Sunday) return true;

            }
            return false;
        }

        public void ActualizarMedico(Medicos m)
        {
            daoMedicos.ActualizarMedico(m);
        }

        public bool EliminarMedico(Medicos medico)
        {
            return daoMedicos.EliminarMedico(medico);
        }

        public int Alta(string dni)
        {
            return daoMedicos.AltaLogica(dni);
        }

        public bool ExisteDni(string dni)
        {
            return daoMedicos.ExisteDniMedico(dni);
        }
    }
}
