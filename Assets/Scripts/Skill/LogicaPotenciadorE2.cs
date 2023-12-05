using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaPotenciadorE2 : MonoBehaviour
{
    
    public bool destruirAutomatico;
    public PlayerControllerE2 logicaJazielE2;

    public int tipo;

    // Start is called before the first frame update
    void Start()
    {
        logicaJazielE2 = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControllerE2>();
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
            yield return new WaitForSeconds(0.3f); // Puedes ajustar la velocidad de parpadeo aquí
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
                logicaJazielE2.velocidadMovimiento += 10;
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
