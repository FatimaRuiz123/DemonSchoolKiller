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
    public Text notificacionText;
    public Text textoTopPuntajes;

    void Start()
    {
        client = new MongoClient("mongodb+srv://unity:unity@cluster0.a53wvhf.mongodb.net/?retryWrites=true&w=majority");
        db = client.GetDatabase("unity");
        collection = db.GetCollection<BsonDocument>("player");
    }

    public void GuardarDatosEnBD(int score)
    {
        string nombre = nombreInput.text; //Nombre

        if (string.IsNullOrEmpty(nombre))
        {
            MostrarNotificacion("Por favor, ingresa un nombre.");
            return;
        }
        var filter = Builders<BsonDocument>.Filter.Eq("nombre", nombre);
        var jugadorExistente = collection.Find(filter).FirstOrDefault();

        if (jugadorExistente != null)
        {
            var update = Builders<BsonDocument>.Update.Set("score", score);
            collection.UpdateOne(filter, update);
        }
        else
        {
            var nuevoJugador = new BsonDocument
            {
                { "nombre", nombre },
                { "score", score }
            };
            collection.InsertOne(nuevoJugador);
        }

        Debug.Log("Datos guardados en la base de datos.");
        MostrarNotificacion($"{nombre} se unió a la batalla.");
        nombreInput.text = "";
    }

    private void MostrarNotificacion(string mensaje)
    {
        notificacionText.text = mensaje;
        StartCoroutine(EsconderNotificacion());
    }
    private IEnumerator EsconderNotificacion()
    {
        yield return new WaitForSeconds(2f);
        notificacionText.text = "";
    }

    public void MostrarTopPuntajes()
    {
        var filter = Builders<BsonDocument>.Filter.Empty;
        var sort = Builders<BsonDocument>.Sort.Descending("score");
        var topJugadores = collection.Find(filter).Sort(sort).Limit(10).ToList();
        for (int i = 0; i < topJugadores.Count; i++)
        {
            string nombre = topJugadores[i]["nombre"].AsString;
            int score = topJugadores[i]["score"].AsInt32;

            MostrarPuntajeEnPantalla(i + 1, nombre, score);
        }
    }
    private void MostrarPuntajeEnPantalla(int posicion, string nombre, int score)
    {
        if (textoTopPuntajes != null)
        {
            string textoPuntaje = $"#{posicion}: {nombre} - Puntaje: {score}";

            textoTopPuntajes.text += textoPuntaje + "\n";
        }
        else
        {
            Debug.LogError("Objeto Text no asignado en el inspector de Unity.");
        }
    }

    public void MostrarTopPuntajesBoton()
    {
        MostrarTopPuntajes();
    }


}