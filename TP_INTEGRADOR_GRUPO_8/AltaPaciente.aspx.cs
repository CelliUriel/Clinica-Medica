using Entidades;
using Negocio;
using System;

namespace TP_INTEGRADOR_GRUPO_8
{
    public partial class AltaPaciente : System.Web.UI.Page
    {
        NegocioPacientes negocio= new NegocioPacientes();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["Usuario"] != null)
            {
                Usuario usuario = (Usuario)Session["Usuario"];
                lblNombre.Text = usuario.getNombre_usuario().ToString();
            }

            if (!IsPostBack)
            {

                //negocio.CompletarDdlLocalidades(ddlLocalidades);
                negocio.CompletarDdlProvincias(ddlProvincias);
                negocio.CompletarDdlSexo(ddlSexo);


            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
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



            NegocioPacientes negocio=new NegocioPacientes();

            bool exito=negocio.GuardarPacientes(pacientes);

            if (exito)
            {

                lblMensaje.Text = "Paciente guardado correctamente";
                lblMensaje.ForeColor = System.Drawing.Color.Green;

            } else
            {
                lblMensaje.Text = "Error al guardar el Paciente";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }

        }

        protected void ddlProvincias_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idProvincia = int.Parse(ddlProvincias.SelectedValue);
            NegocioPacientes negocio = new NegocioPacientes();
            negocio.CompletarDdlLocalidades(ddlLocalidades, idProvincia);
        }
    }
}