using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using System.Text.Json;
using RadioDemo.Models;

namespace WebReservas.Data
{
    public class ConexionMongo
    {
        private IMongoDatabase cnm;
        private IMongoCollection<BsonDocument> documentoCollection;

        public ConexionMongo()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            cnm = client.GetDatabase("radio_demo");
            documentoCollection = cnm.GetCollection<BsonDocument>("Documento");
        }

        public ObjectId InsertarPDF(byte[] pdfBytes, string nombreArchivo)
        {
            var documento = new BsonDocument
            {
                { "nombre", nombreArchivo },
                { "contenido", pdfBytes }
            };

            documentoCollection.InsertOne(documento);

            ObjectId idArchivo = documento["_id"].AsObjectId;

            return idArchivo;
        }

        public byte[] ObtenerPDF(ObjectId idPDF)
        {
            var filtro = Builders<BsonDocument>.Filter.Eq("_id", idPDF);
            var documento = documentoCollection.Find(filtro).FirstOrDefault();

            if (documento != null)
            {
                return documento["contenido"].AsByteArray;
            }
            else
            {
                throw new InvalidOperationException("El PDF con el ID especificado no se encontró en la base de datos.");
            }
        }
    }
}
