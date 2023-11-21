using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator animator;
    float verInput;
    float horInput;
    bool isGrounded;
    bool isAttacking;

    public Camera playerCamera; // Referencia a la cámara que seguirá al jugador

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        isGrounded = true;
        isAttacking = false;
    }

    // Update is called once per frame
    void Update()
    {
        verInput = Input.GetAxis("Vertical");
        horInput = Input.GetAxis("Horizontal");

        // Si el jugador está en el suelo y presiona la tecla de salto, entonces salta
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * 10, ForceMode.Impulse);
            // Establece el estado a "Jumping"
            animator.SetInteger("Est", 2);
            isGrounded = false;
        }

        // Si el jugador presiona la tecla de ataque (por ejemplo, la tecla "Z"), entonces ataca
        if (Input.GetKeyDown(KeyCode.Z))
        {
            isAttacking = true;
            animator.SetTrigger("Atacar");
        }
        // Si el jugador deja de presionar la tecla de ataque, vuelve al estado "Idle"
        else if (isAttacking && Input.GetKeyUp(KeyCode.Z))
        {
            isAttacking = false;
            animator.SetInteger("Est", 0); // Idle
        }

        // Lógica de movimiento solo cuando no está atacando
        if (!isAttacking)
        {
            // Si no se está presionando ninguna tecla de movimiento y está en el suelo, establece el estado a "Idle"
            if (verInput == 0 && horInput == 0 && isGrounded)
            {
                animator.SetInteger("Est", 0); // Idle
            }
            else
            {
                // Mueve hacia adelante o atrás
                transform.Translate(Vector3.forward * Time.deltaTime * verInput * 10);
                animator.SetInteger("Est", 1); // Walking

                // Gira a la izquierda o derecha
                transform.Rotate(Vector3.up * horInput * 100 * Time.deltaTime);

                // Actualiza la posición y rotación de la cámara para que siga al jugador
                if (playerCamera != null)
                {
                    playerCamera.transform.position = new Vector3(transform.position.x, transform.position.y + 8f, transform.position.z + (-5f)) - transform.forward * 5;
                    playerCamera.transform.LookAt(transform.position);
                }
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Verifica si el jugador está en el suelo al entrar en contacto con un objeto etiquetado como "Ground".
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true; // Cambia a true cuando el jugador toca el suelo
        }
    }
}
