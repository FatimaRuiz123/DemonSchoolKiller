using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaDemonioIris : MonoBehaviour
{
    public LogicaBarraVidaIris logicaBarraVidaIris;
    public float dañoD = 20.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto con el que colisiona es un enemigo.
        if (other.CompareTag("Arma"))
        {
            // Reduce la vida de Jaziel.
            // logicaBarraVidaJaziel.vidaActual -= 2.0f; // O el valor que desees.
            logicaBarraVidaIris.vidaActual -= dañoD;
        }
    }
}
