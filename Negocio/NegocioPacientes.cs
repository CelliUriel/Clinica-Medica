using Datos;
using Entidades;
using System;
using System.Data;
using System.Web.UI.WebControls;


namespace Negocio
{
    public class NegocioPacientes
    {
        readonly DaoPacientes dao = new DaoPacientes();

        public DataTable ListarPacientes()
        {
            return dao.ListarPacientes();
        }

        public DataTable FiltrarPorDniPaciente(string dni)
        {
            return dao.FiltrarPacientesPorDNI(dni);
        }

        public void CompletarDdlProvincias(DropDownList ddlProvincias)
        {
            dao.CompletarDdlProvincias(ddlProvincias);
        }

        public void CompletarDdlLocalidades(DropDownList ddlLocalidad, int idProvincia)
        {
           dao.CompletarDdlLocalidades(ddlLocalidad, idProvincia);
        }


        public void CompletarDdlSexo(DropDownList ddlSexo)
        {
            dao.CompletarDdlSexo(ddlSexo);
        }

        public bool GuardarPacientes(Pacientes pacientes)
        {
           return dao.InsertarPacientes(pacientes);
        }

        public bool ExistePaciente(string dni)
        {
            if (string.IsNullOrWhiteSpace(dni))
                return false;
            return dao.ExistePacientePorDni(dni);
        }
    }
}
