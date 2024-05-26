namespace ProyectoAdmin_EmisoraCristalina.Models
{
    public class ContratoModel
    {
        public int Id { get; set; }
        public string? Nombre {  get; set; }
        public string? FechaInicio {  get; set; }
        public string? FechaFin {  get; set; }
        public string? FechaCreacion { get; set; }
        public int Valor {  get; set; }
        public int DocumentoVendedor { get; set; }
        public string? NombreVendedor { get; set; }
        public int DocumentoAnunciante { get; set; }
        public string? NombreAnunciante { get; set; }
        public List<CuniaModel>? Cunias {  get; set; }
    }
}
