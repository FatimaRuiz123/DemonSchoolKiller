using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator animator;
    float verInput;
    float horInput;
    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        isGrounded = true; 
    }

    // Update is called once per frame
    void Update()
    {
        verInput = Input.GetAxis("Vertical");
        horInput = Input.GetAxis("Horizontal");

        // Si no se está presionando ninguna tecla de movimiento y está en el suelo, establece el estado a "Idle"
        if (verInput == 0 && horInput == 0 && isGrounded)
        {
            animator.SetInteger("Est", 0); // Idle
        }
        else
        {
            // Mueve hacia adelante o atrás
            transform.Translate(Vector3.forward * Time.deltaTime * verInput * 10);
                animator.SetInteger("Est", 1); // Idle
            // Gira a la izquierda o derecha
            transform.Rotate(Vector3.up * horInput * 100 * Time.deltaTime);
                    Debug.Log("caminando");
            // Si el jugador está en el suelo y presiona la tecla de salto, entonces salta
            if (isGrounded && Input.GetKeyDown(KeyCode.Space))
            {
                GetComponent<Rigidbody>().AddForce(Vector3.up * 10, ForceMode.Impulse);
                // Establece el estado a "Jumping"
                animator.SetInteger("Est", 2);
                isGrounded = false;
                Debug.Log("saltoo");
            }
            else
            {
                // Configura el estado de animación solo si no está en el aire
                if (!isGrounded)
                {
                    animator.SetInteger("Est", 0); // Idle
                }
                else
                {
                    animator.SetFloat("Estado", 1); // Walking
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
