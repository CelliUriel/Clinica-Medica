using Entidades;
using Negocio;
using System;

namespace TP_INTEGRADOR_GRUPO_8
{
    public partial class AltaPaciente : System.Web.UI.Page
    {
        readonly NegocioPacientes negocio= new NegocioPacientes();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                //negocio.CompletarDdlLocalidades(ddlLocalidades);
                negocio.CompletarDdlProvincias(ddlProvincias);
                negocio.CompletarDdlSexo(ddlSexo);
            }
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            NegocioPacientes negocio = new NegocioPacientes();

            bool existe = negocio.ExistePaciente(tbxDNI.Text);

            if (string.IsNullOrWhiteSpace(tbxDNI.Text))
            {
                lblMensaje.Text = "Debe ingresar un DNI.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (existe)
            {
                lblMensaje.Text = "El paciente ya existe.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                return;
            }

            Pacientes pacientes = new Pacientes();

            pacientes.SetDni_Paciente(tbxDNI.Text);
            pacientes.SetNombre_Paciente(tbxNombre.Text);
            pacientes.SetApellido_Paciente(tbxApellido.Text);
            pacientes.SetSexo_Paciente(ddlSexo.SelectedValue);
            pacientes.SetNacionalidad_Paciente(tbxNacionalidad.Text);
            pacientes.SetFecha_Nacimiento(DateTime.Parse(tbxFechaNacimiento.Text));
            pacientes.SetDireccion_Paciente(tbxDireccion.Text);
            pacientes.SetIdLocalidad_Paciente(int.Parse(ddlLocalidades.SelectedValue));
            pacientes.SetIdProvincia_Paciente(int.Parse(ddlProvincias.SelectedValue));
            pacientes.SetCorreo_Paciente(tbxCorreo.Text);
            pacientes.SetTelefono_Paciente(tbxTelefono.Text);
            pacientes.SetEstado_Paciente(true);

            bool exito = negocio.GuardarPacientes(pacientes);

            if (exito)
            {
                lblMensaje.Text = "Paciente guardado correctamente";
                lblMensaje.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblMensaje.Text = "Error al guardar el paciente.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void DdlProvincias_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idProvincia = int.Parse(ddlProvincias.SelectedValue);
            NegocioPacientes negocio = new NegocioPacientes();
            negocio.CompletarDdlLocalidades(ddlLocalidades, idProvincia);
        }
    }
}