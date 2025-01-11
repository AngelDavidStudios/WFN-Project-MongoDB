using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Test.Models;

public class Banco
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string nombre { get; set; }
    public string swift { get; set; }
    public string pais { get; set; }
    public string sucursal { get; set; }
    public string telefono { get; set; }
}