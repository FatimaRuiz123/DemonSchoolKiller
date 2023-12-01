using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarArmaPersonaje : MonoBehaviour
{
    public TomarArmas tomarArmas;
    public int numeroArma;

    // Start is called before the first frame update
    void Start()
    {
        // Corregido el nombre de la función GameObject.FindGameObjectWithTag
        tomarArmas = GameObject.FindGameObjectWithTag("Player").GetComponent<TomarArmas>();
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
            tomarArmas.ActivarArmas(numeroArma);
            Destroy(gameObject);
        }
    }
}