namespace Entidades
{
    internal class Especialidades
    {
        private int codigo_especialidad;
        private string nombre_especialidad;
        private string descripcion_especialidad;
        public int getCodigo_especialidad()
        {
            return codigo_especialidad;
        }

        public void setCodigo_especialidad(int codigo)
        {
            codigo_especialidad = codigo;
        }
        public string getNombre_especialidad()
        {
            return nombre_especialidad;
        }

        public void setNombre_especialidad(string nombre)
        {
            nombre_especialidad = nombre;
        }
        public string getDescripcion_especialidad()
        {
            return descripcion_especialidad;
        }
        public void setDescripcion_especialidad(string descripcion)
        {
            descripcion_especialidad = descripcion;
        }
    }
}
