using Datos;
using Entidades;
using System.Data;
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

    }
}
