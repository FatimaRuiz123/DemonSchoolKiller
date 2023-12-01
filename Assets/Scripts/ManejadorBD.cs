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


    public void MostrarTopPuntajes()
    {
        var filter = Builders<BsonDocument>.Filter.Empty; // Filtro vacío para obtener todos los documentos
        var sort = Builders<BsonDocument>.Sort.Descending("score"); // Ordenar por puntaje de forma descendente

        var topJugadores = collection.Find(filter).Sort(sort).Limit(10).ToList(); // Obtener los 10 primeros jugadores ordenados por puntaje

        // Limpiar la pantalla de top de puntajes antes de mostrar la nueva información
        LimpiarPantallaTopPuntajes();

        // Mostrar los nombres y puntajes en la pantalla
        for (int i = 0; i < topJugadores.Count; i++)
        {
            string nombre = topJugadores[i]["nombre"].AsString;
            int score = topJugadores[i]["score"].AsInt32;

            MostrarPuntajeEnPantalla(i + 1, nombre, score);
        }
    }

    // Método para mostrar un puntaje en la pantalla
    private void MostrarPuntajeEnPantalla(int posicion, string nombre, int score)
    {
        // Asegúrate de que tienes un objeto Text asignado en el inspector de Unity
        if (textoTopPuntajes != null)
        {
            // Construye el texto que mostrarás
            string textoPuntaje = $"#{posicion}: {nombre} - Puntaje: {score}";

            // Asigna el texto al objeto Text
            textoTopPuntajes.text += textoPuntaje + "\n";
        }
        else
        {
            Debug.LogError("Objeto Text no asignado en el inspector de Unity.");
        }
    }

    // Método para limpiar la pantalla de top de puntajes
    private void LimpiarPantallaTopPuntajes()
    {
        // Asegúrate de que tienes un objeto Text asignado en el inspector de Unity
        if (textoTopPuntajes != null)
        {
            // Limpia el texto del objeto Text
            textoTopPuntajes.text = "";
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
