using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace TP_INTEGRADOR_GRUPO_8
{
    public partial class AltaMedicos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NegocioMedicos medico = new NegocioMedicos();
            
            if (Session["Usuario"] != null)
            {
                Usuario usuario = (Usuario)Session["Usuario"];
                lblNombre.Text = usuario.getNombre_usuario().ToString();
            
            }
            
            if (!IsPostBack)
            {   
                medico.CompletarDdlProvincias(ddlProvincia);
                medico.CompletarDdlSexo(ddlSexo);
                medico.CompletarDdlEspecialidades(ddlEspecialidad);
                medico.CompletarDdlHoras(ddlHoraInicio);
                medico.CompletarDdlHoras(ddlHoraFin);
            }
        }

        protected void DdlProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idProvincia = int.Parse(ddlProvincia.SelectedValue);
            NegocioMedicos negocio = new NegocioMedicos();
            negocio.CompletarDdlLocalidades(ddlLocalidad, idProvincia);
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {

            if (!Page.IsValid)
            {
                LimpiarCampos();
                return;
               
            }

            if (tbContrasenia.Text.Trim() != tbRepetirContrasenia.Text.Trim())
            {
                lblMensaje.Text = "Las contraseñas no coinciden.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                return;
            }

            Usuario usuarioMedico = new Usuario();
            NegocioUsuario usuarioNegocio = new NegocioUsuario();
            NegocioMedicos negocio = new NegocioMedicos();
            if (usuarioNegocio.usuarioExistente(tbUsuario.Text.Trim()))
            {
                lblMensaje.Text = "El usuario ya existe, intentalo de nuevo.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
               
                return;
            }
            usuarioMedico.setNombre_usuario(tbUsuario.Text.Trim());
            usuarioMedico.setContrasenia(tbContrasenia.Text.Trim());
            usuarioMedico.setRol(false);
            
            string dniIngresado = tbDNI.Text.Trim();

            if (negocio.ExisteDni(dniIngresado))
            {
                lblMensaje.Text = "Error al guardar el médico, el DNI no se puede repetir.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                LimpiarCampos();
                return;
            }

            NegocioUsuario negocioUsuarios = new NegocioUsuario();
            int idUsuarioCreado = negocioUsuarios.CrearUsuarioYDevolverID(usuarioMedico);

            if (idUsuarioCreado <= 0)
            {
                lblMensaje.Text = "Error al crear el usuario.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                return;
            }
            Medicos medico = new Medicos();

            medico.SetCodigo_Especialidad_Medico(int.Parse(ddlEspecialidad.SelectedValue));
            medico.SetDniMedico(tbDNI.Text);
            medico.SetNombre_Medico(tbNombre.Text);
            medico.SetApellido_Medico(TbApellido.Text);
            medico.SetSexo_Medico(ddlSexo.SelectedValue);
            medico.SetNacionalidad_Medico(tbNacionalidad.Text);
            medico.SetFecha_Nacimiento(DateTime.Parse(tbFechaNacimiento.Text));
            medico.SetDireccion_Medico(tbDireccion.Text);
            medico.SetId_Provincia_Medico(int.Parse(ddlProvincia.SelectedValue));
            medico.SetId_Localidad_Medico(int.Parse(ddlLocalidad.SelectedValue));
            medico.SetCorreo_Medico(tbCorreoElectronico.Text);
            medico.SetTelefono_Medico(tbTelefono.Text);
            medico.SetDiasAtencion_Medico(string.Join(", ", chkblDias.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Text)));
            medico.SetHorariosAtencion_Medico(ddlHoraInicio.SelectedValue + " - " + ddlHoraFin.SelectedValue);
            medico.SetEstado_Medico(true);
            medico.SetId_Usuario_Medico(idUsuarioCreado);
            bool exito = negocio.GuardarMedico(medico);

            if (exito)
            {
                lblMensaje.Text = "Médico y Usuario guardado correctamente";
                lblMensaje.ForeColor = System.Drawing.Color.Green;
               
            }
            else
            {
                lblMensaje.Text = "Error al guardar el médico";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
               
            }

            LimpiarCampos();
        
        }
    
    
        private void LimpiarCampos()
        {
            tbDNI.Text=string.Empty;
            tbNombre.Text=string.Empty;
            TbApellido.Text=string.Empty;
            tbNacionalidad.Text=string.Empty;
            tbDireccion.Text=string.Empty;    
            tbCorreoElectronico.Text=string.Empty;
            tbTelefono.Text=string.Empty;
            tbUsuario.Text=string.Empty;
            tbContrasenia.Text=string.Empty;
            ddlEspecialidad.SelectedIndex = 0;
            ddlLocalidad.SelectedIndex = 0;
            ddlProvincia.SelectedIndex = 0;
            ddlHoraFin.SelectedIndex = 0;
            ddlHoraInicio.SelectedIndex = 0;
            chkblDias.ClearSelection();
            ddlSexo.SelectedIndex = 0;
            tbFechaNacimiento.Text=string.Empty;
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = chkblDias.Items.Cast<ListItem>().Any(i => i.Selected);
        }
    }
}