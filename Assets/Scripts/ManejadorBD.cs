using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MongoDB.Bson;
using MongoDB.Driver;
using UnityEngine.UI;

public class ManejadorBD : MonoBehaviour
{
    private MongoClient client;
    private IMongoDatabase db;
    private IMongoCollection<BsonDocument> collection;

    public InputField nombreInput;
private static ManejadorBD instance;

  public static ManejadorBD Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject go = new GameObject("ManejadorBD");
                instance = go.AddComponent<ManejadorBD>();
            }
            return instance;
        }
    }
    void Start()
    {

        client = new MongoClient("mongodb+srv://unity:unity@cluster0.a53wvhf.mongodb.net/?retryWrites=true&w=majority");
        db = client.GetDatabase("unity");
        collection = db.GetCollection<BsonDocument>("player");
    }

    public void GuardarDatosEnBD(int score)
    {
        string nombre = nombreInput.text;

        // Buscar al jugador por nombre en la base de datos
        var filter = Builders<BsonDocument>.Filter.Eq("nombre", nombre);
        var jugadorExistente = collection.Find(filter).FirstOrDefault();

        if (jugadorExistente != null)
        {
            // Si el jugador existe, actualizar el puntaje
            var update = Builders<BsonDocument>.Update.Set("score", score);
            collection.UpdateOne(filter, update);
        }
        else
        {
            // Si el jugador no existe, crear un nuevo documento
            var nuevoJugador = new BsonDocument
            {
                { "nombre", nombre },
                { "score", score }
            };
            collection.InsertOne(nuevoJugador);
        }

        Debug.Log("Datos guardados en la base de datos.");
    }
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
