using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class PlayerData
{
    [BsonId]
    public ObjectId Id { get; set; }

    [BsonElement("Nombre")]
    public string Nombre { get; set; }

    [BsonElement("Score")]
    public int Score { get; set; }
}

