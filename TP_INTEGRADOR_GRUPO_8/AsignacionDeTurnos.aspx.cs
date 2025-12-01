using Entidades;
using System;
using Negocio;

namespace TP_INTEGRADOR_GRUPO_8
{
    public partial class AsignacionDeTurnos : System.Web.UI.Page
    {
        readonly NegocioMedicos medicos = new NegocioMedicos();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                medicos.CompletarDdlEspecialidades(ddlEspecialidad);
                medicos.CompletarDdlPacientes(ddlPaciente);
                medicos.CompletarDdlHoras(ddlHora);
            }
        }

        protected void BtnAsignarTurno_Click(object sender, EventArgs e)
        {
            {
                Turnos turno = new Turnos();

                turno.SetDNI_Paciente_Turno(ddlPaciente.SelectedValue);
                turno.SetId_Medico_Turno(ddlMedicos.SelectedValue);
                turno.SetCodigo_Especialidad_Turno(ddlEspecialidad.SelectedValue);

                turno.SetFecha_Turno(DateTime.Parse(tbxFecha.Text));
                turno.SetHora_Turno (ddlHora.SelectedValue);

                turno.SetEstado_Turno("Pendiente"); 
                turno.SetObservacion_Turno ("");     

                NegocioTurnos negocio = new NegocioTurnos();

                if (negocio.CrearTurno(turno))
                {
                    lblMensaje.ForeColor = System.Drawing.Color.Green;
                    lblMensaje.Text = "Turno asignado correctamente.";
                }
                else
                {
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    lblMensaje.Text = "Error al asignar turno.";
                }
            }
        }

        protected void DdlEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idEspecialidad = int.Parse(ddlEspecialidad.SelectedValue);

            NegocioMedicos negocio = new NegocioMedicos();
            negocio.CompletarDdlMedicos(ddlMedicos, idEspecialidad);
        }
    }
}