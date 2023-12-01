using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class BD : MonoBehaviour
{

    public InputField nombreInput;
    public Text notificacionText;
    public Text textoTopPuntajes;

    public static string nombreJugador;

    void Start()
    {
       
    }

    public void GuardarDatosEnBD(int score)
    {
        string nombre = nombreInput.text; //Nombre
        nombreJugador = nombre;
        if (string.IsNullOrEmpty(nombre))
        {
            MostrarNotificacion("Por favor, ingresa un nombre.");
            return;
        }  
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

    
}