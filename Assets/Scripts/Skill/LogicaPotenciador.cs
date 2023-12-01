using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class LogicaPotenciador : MonoBehaviour
{
    public bool destruirAutomatico;
    public PlayerController logicaJaziel;

    public int tipo;

    // Start is called before the first frame update
    void Start()
    {
        logicaJaziel = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        StartCoroutine(Parpadeo(15f)); // Inicia la corrutina de parpadeo
    }

    // Update is called once per frame
    void Update()
    {
        if (destruirAutomatico)
        {
            Destroy(gameObject, 15f); // Destruye el objeto después de 15 segundos
        }
    }

    IEnumerator Parpadeo(float duracion)
    {
        float tiempoInicio = Time.time;

        while (Time.time < tiempoInicio + duracion)
        {
            // Cambia el color del material del objeto entre transparente y opaco
            GetComponent<Renderer>().enabled = !GetComponent<Renderer>().enabled;

            // Espera un breve período de tiempo antes de cambiar nuevamente el color
            yield return new WaitForSeconds(0.5f); // Puedes ajustar la velocidad de parpadeo aquí
        }

        // Asegura que el objeto esté visible al final del parpadeo
        GetComponent<Renderer>().enabled = true;

        // Llama a la función Efecto al final del parpadeo
        Efecto();
    }

    public void Efecto()
    {
        switch (tipo)
        {
            case 1:
                logicaJaziel.velocidadMovimiento += 10;
                Debug.Log("Potenciador aplicado: Velocidad aumentada");
                break;
            default:
                Debug.Log("Sin potenciador");
                break;
        }

        // Destruye el objeto después de aplicar el efecto
        Destroy(gameObject);
    }
}
