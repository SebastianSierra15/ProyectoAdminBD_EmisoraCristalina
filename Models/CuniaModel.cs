namespace ProyectoAdmin_EmisoraCristalina.Models
{
    public class CuniaModel
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public bool Estado { get; set; }
        public TarifaModel? Tarifa { get; set; }
    }
}
