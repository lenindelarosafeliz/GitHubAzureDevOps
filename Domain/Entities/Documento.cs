namespace Domain.Entities
{
    public class Documento
    {
        public int Id { get; set; }
        public int PersonaId { get; set; }
        public int DocumentoTipoId { get; set; }
        public string Numero { get; set; }
        public Persona Persona { get; set; }
        public DocumentoTipo DocumentoTipo { get; set; }
    }
}