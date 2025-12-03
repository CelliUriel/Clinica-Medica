using System;

namespace Entidades
{
    public class Medicos
    {
        private int ID_Medico;
        private int Codigo_Especialidad_Medico;
        private string Legajo_Medico;
        private string dniMedico;
        private string Nombre_Medico;
        private string Apellido_Medico;
        private string Sexo_Medico;
        private string Nacionalidad_Medico;
        private DateTime FechaNacimiento_Medico;
        private string Direccion_Medico;
        private int Id_Localidad_Medico;
        private int Id_Provincia_Medico;
        private string Correo_Medico;
        private string Telefono_Medico;
        private string DiasAtencion_Medico;
        private string HorarioaAtencion_Medico;
        private bool Estado_Medico;
        private int ID_Usuario;

        public int GetId_Usuario_Medico()
        {
            return ID_Usuario;
        }
        public void SetId_Usuario_Medico(int id)
        {
            ID_Usuario = id;
        }
        public int GetId_Medico()
        {
            return ID_Medico;
        }
        public void SetId_Medico(int id)
        {
            ID_Medico = id;
        }

        public int GetCodigo_Especialidad_Medico()
        {
            return Codigo_Especialidad_Medico;
        }
        public void SetCodigo_Especialidad_Medico(int Codigo)
        {
            Codigo_Especialidad_Medico = Codigo;
        }
        public string GetLegajo_Medico()
        {
            return Legajo_Medico;
        }

        public void SetLegajo_Medico(string LegajoM)
        {
            Legajo_Medico = LegajoM;
        }
        public string GetNombre_Medico()
        {
            return Nombre_Medico;
        }

        public string GetDniMedico()
        {
            return dniMedico;
        }

        public void SetDniMedico(string dni)
        {
            dniMedico = dni;
        }

        public void SetNombre_Medico(string NombreMedico)
        {
            Nombre_Medico = NombreMedico;
        }
        public string GetApellido_Medico()
        {
            return Apellido_Medico;
        }
        public void SetApellido_Medico(string Apellido)
        {
            Apellido_Medico = Apellido;
        }
        public string GetSexo_Medico()
        {
            return Sexo_Medico;
        }
        public void SetSexo_Medico(string sexo)
        {
            Sexo_Medico = sexo;
        }
        public string GetNacionalidad_Medico()
        {
            return Nacionalidad_Medico;
        }
        public void SetNacionalidad_Medico(string Nacionalidad)
        {
            Nacionalidad_Medico = Nacionalidad;
        }
        public string GetDireccion_Medico()
        {
            return Direccion_Medico;
        }
        public void SetDireccion_Medico(string Direccion)
        {
            Direccion_Medico = Direccion;
        }
        public string GetCorreo_Medico()
        {
            return Correo_Medico;
        }
        public void SetCorreo_Medico(string Correo)
        {
            Correo_Medico = Correo;
        }
        public string GetTelefono_Medico()
        {
            return Telefono_Medico;
        }
        public void SetTelefono_Medico(string telefono)
        {
            Telefono_Medico = telefono;
        }
        public int GetId_Localidad_Medico()
        {
            return Id_Localidad_Medico;
        }
        public void SetId_Localidad_Medico(int idLocalidaad)
        {
            Id_Localidad_Medico = idLocalidaad;
        }
        public int GetId_Provincia_Medico()
        {
            return Id_Provincia_Medico;
        }
        public void SetId_Provincia_Medico(int idProvinica)
        {
            Id_Provincia_Medico = idProvinica;
        }
        public DateTime GetFecha_Nacimiento_Medico()
        {
            return FechaNacimiento_Medico.Date;
        }
        public void SetFecha_Nacimiento(DateTime fecha)
        {
            FechaNacimiento_Medico = fecha;
        }
        public string GetDiasAtencion_Medico()
        {
            return DiasAtencion_Medico;
        }
        public void SetDiasAtencion_Medico(string DiasAtencion)
        {
            DiasAtencion_Medico = DiasAtencion;
        }
        public string GetHorariosAtencion_Medico()
        {
            return HorarioaAtencion_Medico;
        }
        public void SetHorariosAtencion_Medico(string HorariosAtencion)
        {
            HorarioaAtencion_Medico = HorariosAtencion;
        }
        public bool GetEstado_Medico()
        {
            return Estado_Medico;
        }

        public void SetEstado_Medico(bool estadoM)
        {
            Estado_Medico = estadoM;
        }
    }
}