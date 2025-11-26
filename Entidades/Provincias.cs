namespace Entidades
{
    internal class Provincias
    {
        private int idProvincia;
        private string descripcionProvincia;

        public int getIdProvincia()
        {
            return idProvincia;
        }


        public void setIdProvincia(int id)
        {
            idProvincia = id;
        }


        public string getDescripcionProvincia()
        {
            return descripcionProvincia;
        }


        public void setDescripcionProvincia(string descripcion)
        {
            descripcionProvincia = descripcion;
        }
    }
}
