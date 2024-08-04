namespace ProyectoAdmin_EmisoraCristalina.Models
{
    public class RolModel
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public bool Estado { get; set; }
        public List<PermisoModel>? Permisos { get; set; }
    }
}
