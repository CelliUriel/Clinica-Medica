using System;

namespace Entidades
{
    public class Turnos
    {
        private string ID_Turno;
        private string DNI_Paciente_Turno;
        private string Id_Medico_Turno;
        private string Codigo_Especialidad_Turno;
        private DateTime Fecha_Turno;
        private string Hora_Turno;
        private int Estado_Turno;
        private string Observacion_Turno;

        public Turnos() { }

        public string GetID_Turno()
        {
            return ID_Turno;
        }

        public void SetID_Turno(string IdT)
        {
            ID_Turno = IdT;
        }
        public string GetDNI_Paciente_Turno()
        {
            return DNI_Paciente_Turno;
        }

        public void SetDNI_Paciente_Turno(string DniPacT)
        {
            DNI_Paciente_Turno = DniPacT;
        }
        public string GetId_Medico_Turno()
        {
            return Id_Medico_Turno;
        }

        public void SetId_Medico_Turno(string IdMedT)
        {
            Id_Medico_Turno = IdMedT;
        }
        public string GetCodigo_Especialidad_Turno()
        {
            return Codigo_Especialidad_Turno;
        }

        public void SetCodigo_Especialidad_Turno(string CodEspT)
        {
            Codigo_Especialidad_Turno = CodEspT;
        }
        public DateTime GetFecha_Turno()
        {
            return Fecha_Turno;
        }

        public void SetFecha_Turno(DateTime Fecha)
        {
            Fecha_Turno = Fecha;
        }
        public string GetHora_Turno()
        {
            return Hora_Turno;
        }

        public void SetHora_Turno(string HoraT)
        {
            Hora_Turno = HoraT;
        }
        public string GetEstado_Turno()
        {
            return Estado_Turno;
        }

        public void SetEstado_Turno(string EstadoT)
        {
            Estado_Turno = EstadoT;
        }
        public string GetObservacion_Turno()
        {
            return Observacion_Turno;
        }

        public void SetObservacion_Turno(string ObservacionT)
        {
            Observacion_Turno = ObservacionT;
        }
    }

}
