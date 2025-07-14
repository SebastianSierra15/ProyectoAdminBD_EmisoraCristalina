namespace RadioDemo.Models
{
    public class TarifaModel
    {
        public int Id { get; set; }
        public int ValorPublicado { get; set; }
        public int ValorEspecial { get; set; }
        public int RangoInicial { get; set; }
        public int RangoFinal { get; set; }
        public ProgramaModel? Programa { get; set; }
    }
}
