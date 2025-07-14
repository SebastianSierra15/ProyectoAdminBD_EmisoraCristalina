namespace RadioDemo.Models
{
    public class VendedorModel
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Contrasenia { get; set; }
        public bool Estado { get; set; }
        public PersonaModel? Persona { get; set; }
        public RolModel? Rol { get; set; }
    }
}
