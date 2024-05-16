namespace ProyectoAdmin_EmisoraCristalina.Models
{
    public class PersonaModel
    {
        public int Documento { get; set; }
        public string? Nombre1 { get; set; }
        public string? Nombre2 {  get; set; }
        public string? Apellido1 { get; set; }
        public string? Apellido2 { get; set; }
        public string? FechaNacimiento { get; set; }
        public string? Correo { get; set; }
        public int Id_TipoDocumento { get; set; }
        public int Id_Genero { get; set; }
        public TipoDocumentoModel? TipoDocumento { get; set; }
        public GeneroModel? Genero { get; set; }
    }
}
