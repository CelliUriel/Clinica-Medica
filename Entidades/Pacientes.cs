using System;

namespace Entidades
{
    public class Pacientes
    {
        private string DNI_Paciente;
        private string Nombre_Paciente;
        private string Apellido_Paciente;
        private string Sexo_Paciente;
        private string Nacionalidad_Paciente;
        private DateTime FechaNacimiento_Paciente;
        private string Direccion_Paciente;
        private int ID_Localidad_Paciente;
        private int ID_Provincia_Paciente;
        private string Correo_Paciente;
        private string Telefono_Paciente;
        private bool Estado_Paciente;

        public Pacientes()
        {

        }
        public Pacientes(string dni)
        {
            DNI_Paciente = dni;
        }

        public string Dni_Paciente
        {
            get
            {
                return DNI_Paciente;
            }
            set
            {
                DNI_Paciente = value;
            }
        }
        public string GetDni_Paciente()
        {
            return DNI_Paciente;
        }

        public void SetDni_Paciente(string dniP)
        {
            DNI_Paciente = dniP;
        }

        public string GetNombre_Paciente()
        {
            return Nombre_Paciente;
        }

        public void SetNombre_Paciente(string NombreP)
        {
            Nombre_Paciente = NombreP;
        }

        public string GetApellido_Paciente()
        {
            return Apellido_Paciente;
        }

        public void SetApellido_Paciente(string ApellidoP)
        {
            Apellido_Paciente = ApellidoP;
        }

        public string GetSexo_Paciente()
        {
            return Sexo_Paciente;
        }

        public void SetSexo_Paciente(string SexoP)
        {
            Sexo_Paciente = SexoP;
        }

        public string GetNacionalidad_Paciente()
        {
            return Nacionalidad_Paciente;
        }

        public void SetNacionalidad_Paciente(string NacionalidadP)
        {
            Nacionalidad_Paciente = NacionalidadP;
        }

        public DateTime GetFecha_Nacimiento_Paciente()
        {
            return FechaNacimiento_Paciente.Date;
        }

        public void SetFecha_Nacimiento(DateTime fecha)
        {
            FechaNacimiento_Paciente = fecha;
        }

        public string GetDireccion_Paciente()
        {
            return Direccion_Paciente;
        }

        public void SetDireccion_Paciente(string direccionP)
        {
            Direccion_Paciente = direccionP;
        }

        public int GetIdLocalidad_Paciente()
        {
            return ID_Localidad_Paciente;
        }

        public void SetIdLocalidad_Paciente(int idLocalidadP)
        {
            ID_Localidad_Paciente = idLocalidadP;
        }

        public int GetIdProvincia_Paciente()
        {
            return ID_Provincia_Paciente;
        }

        public void SetIdProvincia_Paciente(int idProvinciaP)
        {
            ID_Provincia_Paciente = idProvinciaP;
        }

        public string GetCorreo_Paciente()
        {
            return Correo_Paciente;
        }

        public void SetCorreo_Paciente(string correo)
        {
            Correo_Paciente = correo;
        }

        public string GetTelefono_Paciente()
        {
            return Telefono_Paciente;
        }

        public void SetTelefono_Paciente(string telefono)
        {
            Telefono_Paciente = telefono;
        }

        public bool GetEstado_Paciente()
        {
            return Estado_Paciente;
        }

        public void SetEstado_Paciente(bool estadoP)
        {
            Estado_Paciente = estadoP;
        }
    }
}