using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ProyectoAdmin_EmisoraCristalina.Models
{
    public class PdfModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? Contrato { get; set; }
        public IFormFile? Pdf { get; set; }

    }
}
