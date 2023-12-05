using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarArmaPersonajeE2 : MonoBehaviour
{
    public TomarArmasE2 tomarArmasE2;
    public int numeroArma;

    // Start is called before the first frame update
    void Start()
    {
        // Corregido el nombre de la función GameObject.FindGameObjectWithTag
        tomarArmasE2   = GameObject.FindGameObjectWithTag("Player").GetComponent<TomarArmasE2>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            // Corregido el nombre de la variable cogerArmas
            tomarArmasE2.ActivarArmas(numeroArma);
            Destroy(gameObject);
        }
    }
}
