using Entidades;
using System;
using Negocio;
using System.Web.UI.WebControls;

namespace TP_INTEGRADOR_GRUPO_8
{
    public partial class AsignacionDeTurnos : System.Web.UI.Page
    {
        readonly NegocioMedicos medicos = new NegocioMedicos();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] != null)
            {
                Usuario usuario = (Usuario)Session["Usuario"];
                lblNombre.Text = usuario.getNombre_usuario().ToString();
            }
            
            if (!IsPostBack)
            {
                medicos.CompletarDdlEspecialidades(ddlEspecialidad);
                medicos.CompletarDdlPacientes(ddlPaciente);
                medicos.CompletarDdlHoras(ddlHora);
            }
        }

        protected void BtnAsignarTurno_Click(object sender, EventArgs e)
        
         {
            //DateTime fecha = DateTime.Parse(tbxFecha.Text);
            

          NegocioMedicos negocioMedicos=new NegocioMedicos();  
           Medicos medicos=new Medicos();

           bool exito= negocioMedicos.AtiendeEseDia(int.Parse(ddlMedicos.SelectedValue),DateTime.Parse(tbxFecha.Text));
            if (!exito)
            {
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Text = "El médico no trabaja ese día.";
                LimpiarCampos();
                return;
            }
            
                Turnos turno = new Turnos();

                turno.SetDNI_Paciente_Turno(ddlPaciente.SelectedValue);
                turno.SetId_Medico_Turno(ddlMedicos.SelectedValue);
                turno.SetCodigo_Especialidad_Turno(ddlEspecialidad.SelectedValue);

                turno.SetFecha_Turno(DateTime.Parse(tbxFecha.Text));
                turno.SetHora_Turno(ddlHora.SelectedValue);

                turno.SetEstado_Turno("Pendiente");
                turno.SetObservacion_Turno("");

                NegocioTurnos negocio = new NegocioTurnos();

                if (!negocio.CrearTurno(turno))
                {
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Text = "Error al asignar turno.";
                LimpiarCampos();
                    return;
                }

                lblMensaje.ForeColor = System.Drawing.Color.Green;
                lblMensaje.Text = "Turno asignado correctamente.";

            LimpiarCampos();
        }

         
        

        protected void DdlEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idEspecialidad = int.Parse(ddlEspecialidad.SelectedValue);

            NegocioMedicos negocio = new NegocioMedicos();
            negocio.CompletarDdlMedicos(ddlMedicos, idEspecialidad);

            lblDYH.Text=string.Empty;
        }

        protected void ddlPaciente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlMedicos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = int.Parse(ddlMedicos.SelectedValue);
            Medicos medicos = new Medicos();

            NegocioMedicos negocio = new NegocioMedicos();
            medicos = negocio.DiasHorarios(id);
            lblDYH.Text = "Dias: "+medicos.GetDiasAtencion_Medico()+" Horarios: "+medicos.GetHorariosAtencion_Medico();

           NegocioTurnos turnos = new NegocioTurnos();

            turnos.CompletarddlHoras(ddlHora, medicos.GetHorariosAtencion_Medico());
        }
    
        public void LimpiarCampos()
        {
            ddlHora.SelectedIndex=0;
            ddlEspecialidad.SelectedIndex=0;
            ddlMedicos.SelectedIndex=0; 
            ddlPaciente.SelectedIndex=0;        
            tbxFecha.Text=string.Empty;
            lblDYH.Text = string.Empty;

        }
    
    }
}