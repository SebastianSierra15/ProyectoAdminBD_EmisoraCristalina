namespace ProyectoAdmin_EmisoraCristalina.Models
{
    public class AnuncianteModel
    {
        public int Nit {  get; set; }
        public string? Nombre {  get; set; }
        public string? Direccion {  get; set; }
        public string? Telefono {  get; set; }
        public PersonaModel? Persona { get; set; }
    }
}
