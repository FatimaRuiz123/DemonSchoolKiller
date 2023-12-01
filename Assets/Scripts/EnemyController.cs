using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float velocidadMovimiento = 3f; // Velocidad a la que se moverá el enemigo.
    public float distanciaAtaque = 2f; // Distancia a la que el enemigo atacará al jugador.
    private Transform jugador; // Referencia al transform del jugador.
    private Rigidbody rb;

    private void Start()
    {
        // Encuentra al jugador por su tag "Player".
        jugador = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Mueve al enemigo hacia el jugador.
        MoverHaciaJugador();

        // Verifica si el jugador está dentro de la distancia de ataque.
        if (Vector3.Distance(transform.position, jugador.position) < distanciaAtaque)
        {
            // Ataca al jugador (puedes implementar la lógica de ataque aquí).
            AtacarJugador();
        }
    }

    void MoverHaciaJugador()
    {
        Vector3 direccion = (jugador.position - transform.position).normalized;

        // Raycast para detectar colisiones y ajustar la dirección si es necesario.
        RaycastHit hit;
        if (Physics.Raycast(transform.position, direccion, out hit, distanciaAtaque))
        {
            if (hit.collider.tag != "Player")
            {
                // Ajusta la dirección si hay una colisión.
                direccion = Vector3.Reflect(direccion, hit.normal);
            }
        }

        // Aplica la rotación y mueve al enemigo.
        Quaternion rotacion = Quaternion.LookRotation(direccion);
        rb.MoveRotation(rotacion);
        rb.MovePosition(transform.position + direccion * velocidadMovimiento * Time.deltaTime);
    }




    void AtacarJugador()
    {
        // Implementa la lógica de ataque aquí.
        Debug.Log("¡Enemigo atacando!");
    }

    
}
