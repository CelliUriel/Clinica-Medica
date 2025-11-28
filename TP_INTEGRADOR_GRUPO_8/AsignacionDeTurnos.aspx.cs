using Entidades;
using System;
using Negocio;

namespace TP_INTEGRADOR_GRUPO_8
{
    public partial class AsignacionDeTurnos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAsignarTurno_Click(object sender, EventArgs e)
        {
            {
                Turnos turno = new Turnos();

                turno.SetDNI_Paciente_Turno(ddlPaciente.SelectedValue);
                turno.SetId_Medico_Turno(ddlMedico.SelectedValue);
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
    }
}