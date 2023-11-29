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
    void Start()
    {
        client = new MongoClient("mongodb+srv://unity:unity@cluster0.a53wvhf.mongodb.net/?retryWrites=true&w=majority");
        db = client.GetDatabase("unity");
        collection = db.GetCollection<BsonDocument>("player");
    }

    public void GuardarDatosEnBD(int score)
    {
        string nombre = nombreInput.text;

        // Verificar si el nombre está vacío
    if (string.IsNullOrEmpty(nombre))
    {
        MostrarNotificacion("Por favor, ingresa un nombre.");
        return; // Salir del método si no se proporciona un nombre
    }

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

        // Mostrar notificación
        MostrarNotificacion($"{nombre} se unió a la batalla.");
        
        // Limpiar el campo de entrada
        nombreInput.text = "";
    }

    // Método para mostrar la notificación y desvanecerla después de un tiempo
    private void MostrarNotificacion(string mensaje)
    {
        notificacionText.text = mensaje;
        StartCoroutine(EsconderNotificacion());
    }

    // Corrutina para esconder la notificación después de unos segundos
    private IEnumerator EsconderNotificacion()
    {
        yield return new WaitForSeconds(2f); // Ajusta el tiempo según tus necesidades
        notificacionText.text = "";
    }
}
